namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Fanex.Common;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.Criterias;
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.Repositories;
    using Fanex.GoldDeluxe.CoreSetting.Resources;
    using Fanex.NAP.Framework.Data;

    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService()
            : this(null)
        {
        }

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository ?? new SettingRepository();
        }

        public SettingDTO GetSetting(GetSettingParameters parameter)
        {
            var setting = new SettingDTO();

            switch (parameter.Level)
            {
                case CustomerLevel.Member:
                    {
                        switch (parameter.UpLineLevel)
                        {
                            case CustomerLevel.Master:
                                setting = GetMemberSettingEditByMaster(parameter.CustId);

                                break;
                            case CustomerLevel.Super:
                                setting = GetMemberSettingEditBySuper(parameter.CustId);

                                break;
                            default:
                                setting = GetMemberSetting(parameter.CustId, parameter.UpLineId);

                                break;
                        }
                    }

                    break;
                case CustomerLevel.Agent:
                    setting = GetAgentSetting(parameter.CustId, parameter.UpLineId);

                    break;
                case CustomerLevel.Master:
                    setting = GetMasterSetting(parameter.CustId, parameter.UpLineId);

                    break;
                case CustomerLevel.Super:
                    setting = GetSuperSetting(parameter.CustId);

                    break;
            }

            return setting;
        }

        public ICommandResults UpdatePTAndCom(UpdatePTAndComParameters parameter)
        {
            ICommandResults resultDetails = null;
            ICommandResult result = null;
            ICriteria criteria = null;

            switch (parameter.Level)
            {
                case CustomerLevel.Member:
                    {
                        switch (parameter.UpLineLevel)
                        {
                            case CustomerLevel.Master:
                                criteria = Mapper.Map<UpdatePTAndComParameters, UpdateMemberPTAndComByMasterCriteria>(parameter);
                                result = _settingRepository.SaveChange(criteria);
                                break;

                            case CustomerLevel.Super:
                                criteria = Mapper.Map<UpdatePTAndComParameters, UpdateMemberPTAndComBySuperCriteria>(parameter);
                                result = _settingRepository.SaveChange(criteria);
                                break;

                            default:
                                criteria = Mapper.Map<UpdatePTAndComParameters, UpdateMemberPTAndComCriteria>(parameter);
                                result = _settingRepository.SaveChange(criteria);
                                break;
                        }
                    }

                    break;

                case CustomerLevel.Agent:
                    criteria = Mapper.Map<UpdatePTAndComParameters, UpdateAgentPTAndComCriteria>(parameter);
                    result = _settingRepository.SaveChange(criteria);

                    break;
                case CustomerLevel.Master:
                    criteria = Mapper.Map<UpdatePTAndComParameters, UpdateMasterPTAndComCriteria>(parameter);
                    result = _settingRepository.SaveChange(criteria);

                    break;

                case CustomerLevel.Super:
                    criteria = Mapper.Map<UpdatePTAndComParameters, UpdateSuperPTAndComCriteria>(parameter);
                    result = _settingRepository.SaveChange(criteria);

                    break;
            }

            resultDetails = GetPTAndComResultDetails(result);

            return resultDetails;
        }

        public ICommandResults UpdateStatus(UpdateDisableStatusParameters parameter)
        {
            var criteria = Mapper.Map<UpdateDisableStatusParameters, UpdateDisableStatusCriteria>(parameter);
            var updateResult = (CommandResult)_settingRepository.SaveChange(criteria);

            if (updateResult.IsSuccessful)
            {
                updateResult = new CommandResult { Message = GoldDeluxeLang.UpdateStatusSuccess };
            }

            return new CommandResults
            {
                Results = new List<ICommandResult> { updateResult }
            };
        }

        public ICommandResults UpdateGameSetting(UpdateGameSettingParameters parameter)
        {
            var criteria = Mapper.Map<UpdateGameSettingParameters, UpdateGameSettingCriteria>(parameter);
            var updateResult = _settingRepository.SaveChange(criteria);

            if (updateResult.IsSuccessful)
            {
                updateResult = new CommandResult { Message = GoldDeluxeLang.lblGameSetting + ": " + GoldDeluxeLang.UpdateSuccessfully };
            }

            return new CommandResults
            {
                Results = new List<ICommandResult> { updateResult }
            };
        }

        public ICommandResults UpdateWinLimit(UpdateWinLimitParameters parameter)
        {
            var criteria = Mapper.Map<UpdateWinLimitParameters, UpdateWinLimitCriteria>(parameter);
            var updateResult = _settingRepository.SaveChange(criteria);

            if (updateResult.IsSuccessful)
            {
                updateResult = new CommandResult { Message = GoldDeluxeLang.lblMemberWinLimit + ": " + GoldDeluxeLang.UpdateSuccessfully };
            }

            return new CommandResults
            {
                Results = new List<ICommandResult> { updateResult }
            };
        }

        public ICommandResults UpdatePTAndComFromExistingMember(UpdatePTAndComFromExistingMemberParameters parameter)
        {
            var setting = GetSetting(new GetSettingParameters
            {
                CustId = parameter.FromCustId,
                Level = CustomerLevel.Member,
                UpLineId = parameter.UpLineId,
                UpLineLevel = CustomerLevel.Agent
            });

            return UpdatePTAndCom(new UpdatePTAndComParameters
            {
                ActorId = parameter.ActorId,
                Commission = setting.Commission,
                CustId = parameter.CustId,
                Ip = parameter.Ip,
                IsUpdatePTAllMembers = false,
                Language = parameter.Language,
                Level = CustomerLevel.Member,
                PositionTaking = setting.PositionTaking,
                PTOnMember = 0,
                SubAccId = parameter.SubAccId,
                UpLineId = parameter.UpLineId,
                UpLineLevel = CustomerLevel.Agent
            });
        }

        public IMultipleCommandResults UpdateGameSettingMultiple(UpdateGameSettingMultipleParameters parameter)
        {
            var results = new MultipleCommandResults();
            var updateParameter = Mapper.Map<UpdateGameSettingMultipleParameters, UpdateGameSettingParameters>(parameter);

            for (int i = 0; i < parameter.CustIds.Count; i++)
            {
                var custId = parameter.CustIds[i];
                var username = parameter.Usernames[i];

                updateParameter.CustId = custId;
                var updateResult = (CommandResults)UpdateGameSetting(updateParameter);

                updateResult.Id = custId;
                updateResult.Name = username;
                results.CommandResultsList.Add(updateResult);
            }

            return results;
        }

        public IMultipleCommandResults UpdatePTAndComMultiple(UpdatePTAndComMultipleParameters parameter)
        {
            var results = new MultipleCommandResults();
            var updateParameter = Mapper.Map<UpdatePTAndComMultipleParameters, UpdatePTAndComParameters>(parameter);

            for (int i = 0; i < parameter.CustIds.Count; i++)
            {
                var custId = parameter.CustIds[i];
                var username = parameter.Usernames[i];

                updateParameter.CustId = custId;
                var updateResult = (CommandResults)UpdatePTAndCom(updateParameter);

                updateResult.Id = custId;
                updateResult.Name = username;
                results.CommandResultsList.Add(updateResult);
            }

            return results;
        }

        public IMultipleCommandResults UpdateWinLimitMutiple(UpdateWinLimitMultipleParameters parameter)
        {
            var results = new MultipleCommandResults();
            var updateParameter = Mapper.Map<UpdateWinLimitMultipleParameters, UpdateGameSettingParameters>(parameter);

            for (int i = 0; i < parameter.CustIds.Count; i++)
            {
                var custId = parameter.CustIds[i];
                var username = parameter.Usernames[i];

                updateParameter.CustId = custId;
                var updateResult = (CommandResults)UpdateGameSetting(updateParameter);

                updateResult.Id = custId;
                updateResult.Name = username;
                results.CommandResultsList.Add(updateResult);
            }

            return results;
        }

        private SettingDTO GetSuperSetting(int superId)
        {
            return _settingRepository.GetSupperSetting(new GetSuperSettingCriteria
            {
                CustId = superId
            });
        }

        private SettingDTO GetMasterSetting(int masterId, int superId)
        {
            return _settingRepository.GetMasterSetting(new GetMasterSettingCriteria
            {
                CustId = masterId,
                UpLineId = superId
            });
        }

        private SettingDTO GetAgentSetting(int agentId, int masterId)
        {
            return _settingRepository.GetAgentSetting(new GetAgentSettingCriteria
            {
                CustId = agentId,
                UpLineId = masterId
            });
        }

        private SettingDTO GetMemberSetting(int memberId, int agentId)
        {
            return _settingRepository.GetMemberSetting(new GetMemberSettingCriteria
            {
                CustId = memberId,
                UpLineId = agentId
            });
        }

        private SettingDTO GetMemberSettingEditBySuper(int memberId)
        {
            return _settingRepository.GetMemberSettingEditBySuper(new GetMemberSettingEditBySuperCriteria
            {
                CustId = memberId
            });
        }

        private SettingDTO GetMemberSettingEditByMaster(int memberId)
        {
            return _settingRepository.GetMemberSettingEditByMaster(new GetMemberSettingEditByMasterCriteria
            {
                CustId = memberId
            });
        }

        private ICommandResults GetPTAndComResultDetails(ICommandResult commandResult)
        {
            CommandResults resultDetails = new CommandResults();
            string[] errCodes = commandResult.Code.Split('\a');
            string[] errMsgs = commandResult.Message.Split('\a');

            for (int i = 0; i < errCodes.Length; i++)
            {
                if (!string.IsNullOrEmpty(errCodes[i]))
                {
                    var errCode = Converter.ToInt(errCodes[i]);
                    if (errCode < 0)
                    {
                        resultDetails.Results.Add(new PTAndComCommandResult
                        {
                            Code = errCode,
                            Message = GoldDeluxeLang.ResourceManager.GetString(string.Format("_{0}", Math.Abs(errCode)))
                        });
                    }
                    else
                    {
                        resultDetails.Results.Add(new PTAndComCommandResult
                        {
                            Code = errCode,
                            Message = errMsgs[i]
                        });
                    }
                }
            }

            return resultDetails;
        }
    }
}