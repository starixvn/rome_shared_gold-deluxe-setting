namespace Fanex.GoldDeluxe.CoreSetting.Web.HtmlHelpers
{
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public static class JavascriptHelper
    {
        public static MvcHtmlString ToJavascriptObject(this HtmlHelper helper, object objConvertToJsObject, string javascriptObjectName)
        {
            var objectString = string.Empty;
            if (objConvertToJsObject != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                objectString = string.Format(
                    "var {0} = {1}; \n",
                    javascriptObjectName,
                    JsonConvert.SerializeObject(objConvertToJsObject, Formatting.Indented, settings));
            }

            return MvcHtmlString.Create(objectString);
        }
    }
}
