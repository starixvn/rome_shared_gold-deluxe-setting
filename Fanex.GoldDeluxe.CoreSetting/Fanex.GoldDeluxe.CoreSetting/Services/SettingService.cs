namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.Repositories;
    using Fanex.NAP.Framework.Data;
    using Fanex.GoldDeluxe.CoreSetting.Criterias;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;
    using Fanex.GoldDeluxe.CoreSetting.Enumerations;

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

        public SettingDTO GetCustomerSetting(GetCustomerSettingParameters parameter)
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

        public ICommandResults UpdateSuperPTAndComSetting(UpdateSuperPTAndComParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResults UpdateMasterPTAndComSetting(UpdateMasterPTAndComParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResults UpdateAgentPTAndComSetting(UpdateAgentPTAndComParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResults UpdateMemberPTAndComSetting(UpdateMemberPTAndComParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResults UpdateMemberPTAndComSettingBySuper(UpdateMemberPTAndComBySuperParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResults UpdateMemberPTAndComSettingByMaster(UpdateMemberPTAndComByMasterParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult UpdateDisableStatus(UpdateDisableStatusParameters parameter)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult UpdateGameSetting(UpdateGameSettingParameters parameter)
        {
            throw new System.NotImplementedException();
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
    }
}
