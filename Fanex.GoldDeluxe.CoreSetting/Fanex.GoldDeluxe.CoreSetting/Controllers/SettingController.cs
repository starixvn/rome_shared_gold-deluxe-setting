namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using AutoMapper;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult EditSetting(
            int custId,
            int upLineId,
            int level,
            int upLineLevel,
            int actorId,
            int subAccId = 0,
            string language = "E",
            FormType formType = FormType.ReadOnly)
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

            var param = Mapper.Map<EditSettingViewModel, GetSettingParameters>(model);
            model.Setting = _settingService.GetSetting(param);

            return View(EditSinglePagePath, model);
        }

        [HttpPost]
        public ActionResult UpdatePTAndCom(EditSettingViewModel model)
        {
            var param = Mapper.Map<EditSettingViewModel, UpdatePTAndComParameters>(model);

            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults> 
                { 
                    _settingService.UpdatePTAndCom(param) 
                }
            };

            return Json(updateResult);
        }

        [HttpPost]
        public ActionResult UpdateGameSetting(EditSettingViewModel model)
        {
            var param = Mapper.Map<EditSettingViewModel, UpdateGameSettingParameters>(model);

            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults> 
                { 
                    _settingService.UpdateGameSetting(param)
                }
            };

            return Json(updateResult);
        }

        [HttpPost]
        public ActionResult UpdateSetting(EditSettingViewModel model)
        {
            return View();
        }

        public ActionResult UnAuthorized()
        {
            return View(GoldDeluxeSettings.Settings.UnAuthorizedPath);
        }
    }
}
