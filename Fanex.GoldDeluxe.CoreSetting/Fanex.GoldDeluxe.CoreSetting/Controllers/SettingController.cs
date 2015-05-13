namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using System.Web.Mvc;

    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;
        private const string EditSinglePagePath = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml";

        public SettingController()
            : this(null)
        {

        }

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService ?? new SettingService();
        }

        public ActionResult EditCustomerSetting(
            int custId,
            int upLineId,
            int level,
            int upLineLevel,
            int actorId,
            int subAccId,
            string language,
            FormType formType)
        {
            var model = new EditSettingViewModel
            {
                CustId = custId,
                UpLineId = upLineId,
                Level = (CustomerLevel)level,
                UpLineLevel = (CustomerLevel)upLineLevel,
                ActorId = actorId,
                SubAccId = subAccId,
                Language = language
            };

            model.Setting = _settingService.GetCustomerSetting(new GetCustomerSettingParameters
            {
                CustId = custId,
                UpLineId = upLineId,
                Level = (CustomerLevel)level,
                UpLineLevel = (CustomerLevel)upLineLevel,
            });

            return View(EditSinglePagePath, model);
        }

        [HttpPost]
        public ActionResult UpdateCustomerPTAndCom()
        {

        }

        public ActionResult UnAuthorized()
        {
            return View(GoldDeluxeSettings.Settings.UnAuthorizedPath);
        }
    }
}
