namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using System.Web.Mvc;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController()
            : this(null)
        {

        }

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService ?? new SettingService();
        }

        public ActionResult EditSuperSetting(int superId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetSuperSetting(superId),
                Level = CustomerLevel.Super,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }

        public ActionResult EditMasterSetting(int masterId, int superId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetMasterSetting(masterId, superId),
                Level = CustomerLevel.Master,
                UplineLevel = CustomerLevel.Super,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }

        public ActionResult EditAgentSetting(int agentId, int masterId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetAgentSetting(agentId, masterId),
                Level = CustomerLevel.Agent,
                UplineLevel = CustomerLevel.Master,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }

        public ActionResult EditMemberSetting(int memberId, int agentId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetMemberSetting(memberId, agentId),
                Level = CustomerLevel.Member,
                UplineLevel = CustomerLevel.Agent,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }

        public ActionResult SuperEditMemberSetting(int memberId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetMemberSettingEditBySuper(memberId),
                Level = CustomerLevel.Member,
                UplineLevel = CustomerLevel.Super,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }

        public ActionResult MasterEditMemberSetting(int memberId)
        {
            var model = new EditSettingViewModel
            {
                Setting = _settingService.GetMemberSettingEditByMaster(memberId),
                Level = CustomerLevel.Member,
                UplineLevel = CustomerLevel.Master,
                System = GoldDeluxe.CoreSetting.Configuration.GoldDeluxeSettings.Settings.System
            };

            return View("~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml", model);
        }
    }
}
