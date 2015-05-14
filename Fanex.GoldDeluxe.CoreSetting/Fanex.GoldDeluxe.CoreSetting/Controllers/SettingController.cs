namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Fanex.Common;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using Fanex.GoldDeluxe.CoreSetting.Web.Filters;

    public class SettingController : BaseController
    {
        private const string EditSinglePagePath = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml";
        private const string EditMultiplePagePath = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingMultiple.cshtml";
        private readonly ISettingService _settingService;

        public SettingController()
            : this(null)
        {
        }

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService ?? new SettingService();
        }

        [GoldDeluxeAuthorization]
        [HttpGet]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
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
                Language = language,
                FormType = formType
            };

            var param = Mapper.Map<EditSettingViewModel, GetSettingParameters>(model);
            model.Setting = _settingService.GetSetting(param);

            return View(EditSinglePagePath, model);
        }

        [GoldDeluxeAuthorization]
        [HttpPost]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        public ActionResult EditSettingMultiple(
            string custIds,
            string usernames,
            int upLineId,
            int level,
            int upLineLevel,
            int actorId,
            int subAccId = 0,
            string language = "E",
            FormType formType = FormType.ReadOnly)
        {
            var model = new EditSettingMultipleViewModel
            {
                CustIds = custIds,
                Usernames = usernames,
                UpLineId = upLineId,
                Level = (CustomerLevel)level,
                UpLineLevel = (CustomerLevel)upLineLevel,
                ActorId = actorId,
                SubAccId = subAccId,
                Language = language,
                FormType = formType
            };

            model.CustId = Converter.To<int>(custIds.Split(',')[0]);
            var param = Mapper.Map<EditSettingMultipleViewModel, GetSettingParameters>(model);
            model.Setting = _settingService.GetSetting(param);

            return View(EditMultiplePagePath, model);
        }

        [GoldDeluxeAuthorization(IsHost = true)]
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

        [GoldDeluxeAuthorization(IsHost = true)]
        [HttpPost]
        public ActionResult UpdatePTAndComMultiple(EditSettingMultipleViewModel model)
        {
            var param = Mapper.Map<EditSettingMultipleViewModel, UpdatePTAndComMultipleParameters>(model);
            var updateResult = _settingService.UpdatePTAndComMultiple(param);

            return Json(updateResult);
        }

        [GoldDeluxeAuthorization(IsHost = true)]
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

        [GoldDeluxeAuthorization(IsHost = true)]
        [HttpPost]
        public ActionResult UpdateGameSettingMultiple(EditSettingMultipleViewModel model)
        {
            var param = Mapper.Map<EditSettingMultipleViewModel, UpdateGameSettingMultipleParameters>(model);
            var updateResult = _settingService.UpdateGameSettingMultiple(param);

            return Json(updateResult);
        }

        [GoldDeluxeAuthorization(IsHost = true)]
        [HttpPost]
        public ActionResult UpdateSetting(EditSettingViewModel model)
        {
            var updatePTAndComParam = Mapper.Map<EditSettingViewModel, UpdatePTAndComParameters>(model);
            var updateGameSettingPram = Mapper.Map<EditSettingViewModel, UpdateGameSettingParameters>(model);
            var updateStatusParam = Mapper.Map<EditSettingViewModel, UpdateDisableStatusParameters>(model);

            var resultUpdatePTAndCom = _settingService.UpdatePTAndCom(updatePTAndComParam);
            var resultUpdateGameSetting = _settingService.UpdateGameSetting(updateGameSettingPram);
            var resultUpdateStatus = _settingService.UpdateStatus(updateStatusParam);

            var updateResult = new MultipleCommandResults();
            updateResult.CommandResultsList.Add(resultUpdateStatus);
            updateResult.CommandResultsList.Add(resultUpdatePTAndCom);
            updateResult.CommandResultsList.Add(resultUpdateGameSetting);

            return Json(updateResult);
        }

        [GoldDeluxeAuthorization(IsHost = true)]
        [HttpPost]
        public ActionResult UpdateSettingMultiple(EditSettingMultipleViewModel model)
        {
            var updateResult = new MultipleCommandResults();

            var custIds = model.CustIds.Split(',').Select(int.Parse).ToList();
            var usernames = model.CustIds.Split(',').ToList();

            for (int i = 0; i < custIds.Count; i++)
            {
                var subUpdateResult = new CommandResults();
                var custId = custIds[i];
                var username = usernames[i];

                var updatePTAndComParam = Mapper.Map<EditSettingMultipleViewModel, UpdatePTAndComParameters>(model);
                var updateGameSettingPram = Mapper.Map<EditSettingMultipleViewModel, UpdateGameSettingParameters>(model);

                var resultUpdatePTAndCom = _settingService.UpdatePTAndCom(updatePTAndComParam);
                var resultUpdateGameSetting = _settingService.UpdateGameSetting(updateGameSettingPram);

                subUpdateResult.Results.AddRange(resultUpdatePTAndCom.Results);
                subUpdateResult.Results.AddRange(resultUpdateGameSetting.Results);
                subUpdateResult.Id = custId;
                subUpdateResult.Name = username;
                updateResult.CommandResultsList.Add(subUpdateResult);
            }

            return Json(updateResult);
        }

        public ActionResult UnAuthorized()
        {
            return View(GoldDeluxeSettings.Settings.UnAuthorizedPath);
        }
    }
}