namespace Fanex.GoldDeluxe.CoreSetting.Services
{
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
    using System;

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
                    setting = GetMasterSetting(parameter.CustId, parameter.UpLineId);
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

            resultDetails = GetResultDetails(result);

            return resultDetails;
        }

        public ICommandResult UpdateStatus(UpdateDisableStatusParameters parameter)
        {
            var criteria = Mapper.Map<UpdateDisableStatusParameters, UpdateDisableStatusCriteria>(parameter);

            return _settingRepository.SaveChange(criteria);
        }

        public ICommandResults UpdateGameSetting(UpdateGameSettingParameters parameter)
        {
            var results = new CommandResults();
            var criteria = Mapper.Map<UpdateGameSettingParameters, UpdateGameSettingCriteria>(parameter);
            results.Results.Add(_settingRepository.SaveChange(criteria));

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
                SuperId = superId
            });
        }

        private SettingDTO GetAgentSetting(int agentId, int masterId)
        {
            return _settingRepository.GetAgentSetting(new GetAgentSettingCriteria
            {
                CustId = agentId,
                MasterId = masterId
            });
        }

        private SettingDTO GetMemberSetting(int memberId, int agentId)
        {
            return _settingRepository.GetMemberSetting(new GetMemberSettingCriteria
            {
                CustId = memberId,
                AgentId = agentId
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

        private ICommandResults GetResultDetails(ICommandResult commandResult)
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
