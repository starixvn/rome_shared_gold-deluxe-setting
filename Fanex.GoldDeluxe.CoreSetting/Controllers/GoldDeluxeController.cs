namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Fanex.Common;
    using Fanex.CustomerSetting.Module.Core.Constants;
    using Fanex.CustomerSetting.Module.Core.Services.Impl;
    using Fanex.CustomerSetting.Module.Core.Services.Interface;
    using Fanex.CustomerSetting.Module.Core.Web;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.Configuration;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.Services;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;
    using Fanex.GoldDeluxe.CoreSetting.Web;
    using Fanex.GoldDeluxe.CoreSetting.Web.Filters;
    using NAP.Framework.Data;
    using Resources;

    public class GoldDeluxeController : BaseController
    {
        private const string EditSinglePagePath = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingSingle.cshtml";
        private const string EditMultiplePagePath = "~/Areas/GoldDeluxeSetting/Views/EditSetting/EditSettingMultiple.cshtml";
        private readonly ISettingService _settingService;
        private readonly GoldDeluxeSettings _settingConfiguration = GoldDeluxeSettings.Settings;
        private readonly IServiceBase serviceBase;

        public GoldDeluxeController()
            : this(null, null)
        {
        }

        public GoldDeluxeController(ISettingService settingService, IServiceBase serviceBase)
        {
            _settingService = settingService ?? new SettingService();
            this.serviceBase = serviceBase ?? new ServiceBase();
        }

        [HttpGet, GoldDeluxeAuthorization]
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

        [HttpPost, GoldDeluxeAuthorization]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed.")]
        public ActionResult EditSettingMultiple(
            string customerIds,
            string usernames,
            int upLineId,
            int customerLevel,
            int upLineLevel,
            int actorId,
            int subAccId = 0,
            string language = "E",
            FormType formType = FormType.ReadOnly)
        {
            var model = new EditSettingMultipleViewModel
            {
                CustIds = customerIds,
                Usernames = usernames,
                UpLineId = upLineId,
                Level = (CustomerLevel)customerLevel,
                UpLineLevel = (CustomerLevel)upLineLevel,
                ActorId = actorId,
                SubAccId = subAccId,
                Language = language,
                FormType = formType
            };

            model.CustId = Converter.To<int>(customerIds.Split(',')[0]);
            var param = Mapper.Map<EditSettingMultipleViewModel, GetSettingParameters>(model);
            model.Setting = _settingService.GetSetting(param);

            return View(EditMultiplePagePath, model);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdatePTAndCom(EditSettingViewModel model)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            var param = Mapper.Map<EditSettingViewModel, UpdatePTAndComParameters>(model);
            updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>
                {
                    _settingService.UpdatePTAndCom(param)
                }
            };

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdatePTAndComMultiple(EditSettingMultipleViewModel model)
        {
            IMultipleCommandResults updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            var param = Mapper.Map<EditSettingMultipleViewModel, UpdatePTAndComMultipleParameters>(model);
            updateResult = _settingService.UpdatePTAndComMultiple(param);

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateGameSetting(EditSettingViewModel model)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            if (this.IsCrossLevelAtMember(model))
            {
                return Json(this.UnAuthorizedWinLimitAndGameSetting(GoldDeluxeLang.lblGameSetting));
            }

            if (IsUpdateMemberGameSettingNotValid(model))
            {
                return Json(this.UnAuthorizedMemberGameSetting(GetErrorMemberStakeLevels()));
            }

            var param = Mapper.Map<EditSettingViewModel, UpdateGameSettingParameters>(model);
            updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>
                {
                    _settingService.UpdateGameSetting(param)
                }
            };

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateGameSettingMultiple(EditSettingMultipleViewModel model)
        {
            IMultipleCommandResults updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            if (this.IsCrossLevelAtMember(model))
            {
                return Json(this.UnAuthorizedWinLimitAndGameSetting(GoldDeluxeLang.lblGameSetting));
            }

            if (IsUpdateMemberGameSettingNotValid(model))
            {
                return Json(this.UnAuthorizedMemberGameSetting(GetErrorMemberStakeLevels()));
            }

            var param = Mapper.Map<EditSettingMultipleViewModel, UpdateGameSettingMultipleParameters>(model);
            updateResult = _settingService.UpdateGameSettingMultiple(param);

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateWinLimit(EditSettingViewModel model)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            if (this.IsCrossLevelAtMember(model))
            {
               return Json(this.UnAuthorizedWinLimitAndGameSetting(GoldDeluxeLang.lblMemberWinLimit));
            }

            var param = Mapper.Map<EditSettingViewModel, UpdateWinLimitParameters>(model);
            updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>
                {
                    _settingService.UpdateWinLimit(param)
                }
            };

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateWinLimitMultiple(EditSettingMultipleViewModel model)
        {
            IMultipleCommandResults updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            if (this.IsCrossLevelAtMember(model))
            {
                return Json(this.UnAuthorizedWinLimitAndGameSetting(GoldDeluxeLang.lblMemberWinLimit));
            }

            var param = Mapper.Map<EditSettingMultipleViewModel, UpdateWinLimitMultipleParameters>(model);
            updateResult = _settingService.UpdateWinLimitMutiple(param);

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateSetting(EditSettingViewModel model)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            var updatePTAndComParam = Mapper.Map<EditSettingViewModel, UpdatePTAndComParameters>(model);
            var updateStatusParam = Mapper.Map<EditSettingViewModel, UpdateDisableStatusParameters>(model);

            var resultUpdatePTAndCom = _settingService.UpdatePTAndCom(updatePTAndComParam);

            if (resultUpdatePTAndCom.IsSuccessful)
            {
                if (!IsCrossLevelAtMember(model) && WebHelper.IsCustomerNotBelongToSpecialSites())
                {
                    updateResult.CommandResultsList.Add(_settingService.UpdateStatus(updateStatusParam));
                }
            }

            updateResult.CommandResultsList.Add(resultUpdatePTAndCom);

            if (!IsCrossLevelAtMember(model))
            {
                var updateGameSettingPram = Mapper.Map<EditSettingViewModel, UpdateGameSettingParameters>(model);
                var updateWinLimitParam = Mapper.Map<EditSettingViewModel, UpdateWinLimitParameters>(model);
                updateResult.CommandResultsList.Add(_settingService.UpdateWinLimit(updateWinLimitParam));
                if (IsUpdateMemberGameSettingNotValid(model))
                {
                    updateResult.CommandResultsList.Add(new CommandResults { Results = { new CommandResult { Code = "-101", Message = GetErrorMemberStakeLevels() } } });
                }
                else
                {
                    updateResult.CommandResultsList.Add(_settingService.UpdateGameSetting(updateGameSettingPram));
                }
            }

            return Json(updateResult);
        }

        [HttpPost, GoldDeluxeAuthorization(IsHost = true)]
        public ActionResult UpdateSettingMultiple(EditSettingMultipleViewModel model)
        {
            var updateResult = new MultipleCommandResults();
            var checkUmResult = serviceBase.CheckUM(model.CustId, NonDcsProduct.GoldDeluxe, AppSession.CurrentSession.LangKey);
            if (!checkUmResult.IsSuccess)
            {
                updateResult.CommandResultsList.Add(new CommandResults
                {
                    Results = new List<ICommandResult>
                    {
                        new CommandResult { Code = checkUmResult.ErrorCode, Message = checkUmResult.ErrorMessage }
                    }
                });

                return Json(updateResult);
            }

            var custIds = model.CustIds.Split(',').Select(int.Parse).ToList();
            var usernames = model.Usernames.Split(',').ToList();

            for (int i = 0; i < custIds.Count; i++)
            {
                var subUpdateResult = new CommandResults();
                var username = usernames[i];
                model.CustId = custIds[i];

                var updatePTAndComParam = Mapper.Map<EditSettingMultipleViewModel, UpdatePTAndComParameters>(model);
                var resultUpdatePTAndCom = _settingService.UpdatePTAndCom(updatePTAndComParam);

                if (model.Level == CustomerLevel.Member && model.UpLineLevel == CustomerLevel.Agent)
                {
                    var updateStatusParam = Mapper.Map<EditSettingMultipleViewModel, UpdateDisableStatusParameters>(model);

                    if (resultUpdatePTAndCom.IsSuccessful)
                    {
                        var resultUpdateStatus = _settingService.UpdateStatus(updateStatusParam);

                        subUpdateResult.Results.AddRange(resultUpdateStatus.Results);
                    }
                }

                subUpdateResult.Results.AddRange(resultUpdatePTAndCom.Results);

                if (!this.IsCrossLevelAtMember(model))
                {
                    var updateWinLimitParam = Mapper.Map<EditSettingMultipleViewModel, UpdateWinLimitParameters>(model);
                    var updateGameSettingPram = Mapper.Map<EditSettingMultipleViewModel, UpdateGameSettingParameters>(model);
                    var resultWinLimit = _settingService.UpdateWinLimit(updateWinLimitParam);

                    ICommandResults resultUpdateGameSetting = new CommandResults();
                    if (IsUpdateMemberGameSettingNotValid(model))
                    {
                        resultUpdateGameSetting.Results = new List<ICommandResult> { new CommandResult { Code = "-101", Message = GetErrorMemberStakeLevels() } };
                    }
                    else
                    {
                        resultUpdateGameSetting = _settingService.UpdateGameSetting(updateGameSettingPram);
                    }

                    subUpdateResult.Results.AddRange(resultWinLimit.Results);
                    subUpdateResult.Results.AddRange(resultUpdateGameSetting.Results);
                }

                subUpdateResult.Id = model.CustId;
                subUpdateResult.Name = username;
                updateResult.CommandResultsList.Add(subUpdateResult);
            }

            return Json(updateResult);
        }

        [HttpGet, GoldDeluxeAuthorization(IsHost = false)]
        public ActionResult GetCurrentWinLimit(int custId)
        {
            return Json(_settingService.GetCurrentWinLimit(custId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnAuthorized()
        {
            return View(GoldDeluxeSettings.Settings.UnAuthorizedPath);
        }

        private bool IsCrossLevelAtMember(EditSettingViewModel model)
        {
            return (model.UpLineLevel == CustomerLevel.Super || model.UpLineLevel == CustomerLevel.Master) && model.Level == CustomerLevel.Member;
        }

        private bool IsUpdateMemberGameSettingNotValid(EditSettingViewModel model)
            => model.Level == CustomerLevel.Member && model.Setting.GameSetting?.Count > 0 &&
                model.Setting.GameSetting.Any(s => s.BettingLimit.Count(b => b.IsChecked) > _settingConfiguration.MemberMaxStakeLevels);

        private string GetErrorMemberStakeLevels()
        {
            var productName = GoldDeluxeLang.GoldDeluxe;
            var errorStakeLevels = $"{GoldDeluxeLang.lblGameSetting}: {string.Format(GoldDeluxeLang.ErrorMaxMemberStakeLevels, _settingConfiguration.MemberMaxStakeLevels, productName)}";

            return errorStakeLevels;
        }

        private MultipleCommandResults UnAuthorizedWinLimitAndGameSetting(string SettingTypeName)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var result = new CommandResult { Message = SettingTypeName + ": " + GoldDeluxeLang.UnauthorizeMsg, Code = "-101" };
            var commandResult = new CommandResults
            {
                Results = new List<ICommandResult> { result }
            };

            updateResult.CommandResultsList.Add(commandResult);
            return updateResult;
        }

        private MultipleCommandResults UnAuthorizedMemberGameSetting(string errorMessage)
        {
            var updateResult = new MultipleCommandResults
            {
                CommandResultsList = new List<ICommandResults>()
            };

            var result = new CommandResult { Message = errorMessage, Code = "-101" };
            var commandResult = new CommandResults
            {
                Results = new List<ICommandResult> { result }
            };

            updateResult.CommandResultsList.Add(commandResult);
            return updateResult;
        }
    }
}