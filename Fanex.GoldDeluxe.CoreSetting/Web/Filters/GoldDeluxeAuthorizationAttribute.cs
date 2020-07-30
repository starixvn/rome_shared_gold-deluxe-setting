namespace Fanex.GoldDeluxe.CoreSetting.Web.Filters
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using Fanex.Common;
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Resources;
    using Fanex.GoldDeluxe.CoreSetting.Services;
 
    public class GoldDeluxeAuthorizationAttribute : AuthorizeAttribute
    {
        private const string AntiForgeryFormTokenName = "__RequestVerificationToken";

        public bool IsHost { get; set; }

        public IGoldDeluxeAuthorizationService GoldDeluxeAuthenticationService { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (!string.IsNullOrEmpty(GoldDeluxeSettings.Settings.AuthorizationServiceType))
            {
                var authorizationType = Type.GetType(GoldDeluxeSettings.Settings.AuthorizationServiceType);
                GoldDeluxeAuthenticationService = Activator.CreateInstance(authorizationType) as IGoldDeluxeAuthorizationService;

                var isAuthorized = false;
                if (filterContext.ActionDescriptor.ActionName.ToLower().Contains("multiple"))
                {
                    isAuthorized = IsHost ? IsAuthorizedHostMultiple(filterContext) : IsAuthorizedReadMultiple(filterContext);
                }
                else
                {
                    isAuthorized = IsHost ? IsAuthorizedHost(filterContext) : IsAuthorizedRead(filterContext);
                }

                if (IsHost && isAuthorized)
                {
                    isAuthorized = ValidateAntiXSRF();
                }

                if (!isAuthorized)
                {
                    UnAuthorizedAction(filterContext);
                }
            }
        }

        private bool ValidateAntiXSRF()
        {
            try
            {
                var request = HttpContext.Current.Request;

                var formToken = request.Headers[AntiForgeryFormTokenName];
                if (string.IsNullOrWhiteSpace(formToken))
                {
                    return false;
                }

                var cookieValue = request.Cookies[AntiForgeryConfig.CookieName];
                if (cookieValue != null
                    && !string.IsNullOrWhiteSpace(cookieValue.Value))
                {
                    AntiForgery.Validate(cookieValue.Value, formToken);
                }
            }
            catch (Exception ex)
            {
                Logging.LogService.Error(ex.ToString(), ex);

                return false;
            }

            return true;
        }

        private string GetActionParameterValue(IValueProvider valueProvider, string parameterName)
        {
            return valueProvider.GetValue(parameterName) != null
                                ? valueProvider.GetValue(parameterName).AttemptedValue
                                : string.Empty;
        }

        private bool IsAuthorizedHost(AuthorizationContext filterContext)
        {
            var valueProvider = filterContext.Controller.ValueProvider;
            var id = Converter.ToInt(GetActionParameterValue(valueProvider, "CustId"));

            return GoldDeluxeAuthenticationService.IsAuthorizedHost(filterContext, id);
        }

        private bool IsAuthorizedHostMultiple(AuthorizationContext filterContext)
        {
            var valueProvider = filterContext.Controller.ValueProvider;
            var usernames = GetActionParameterValue(valueProvider, "Usernames").Split(',').ToList();

            return GoldDeluxeAuthenticationService.IsAuthorizedHostMultiple(filterContext, usernames);
        }

        private bool IsAuthorizedRead(AuthorizationContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var id = Converter.ToInt(request["custId"]);

            return GoldDeluxeAuthenticationService.IsAuthorizedRead(filterContext, id);
        }

        private bool IsAuthorizedReadMultiple(AuthorizationContext filterContext)
        {
            var valueProvider = filterContext.Controller.ValueProvider;
            var usernames = GetActionParameterValue(valueProvider, "Usernames");

            return GoldDeluxeAuthenticationService.IsAuthorizedReadMultiple(filterContext, usernames.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void UnAuthorizedAction(AuthorizationContext filterContext)
        {
            HttpResponseBase response = filterContext.HttpContext.Response;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                response.Clear();
                response.Write(GoldDeluxeLang.UnauthorizeMsg);
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                response.End();
            }
            else
            {
                filterContext.Result = new RedirectResult("~/GoldDeluxeSetting/GoldDeluxe/UnAuthorized");
            }
        }
    }
}