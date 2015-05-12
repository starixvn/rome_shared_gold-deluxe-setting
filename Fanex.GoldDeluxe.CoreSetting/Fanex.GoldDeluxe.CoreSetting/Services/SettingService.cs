namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using Fanex.GoldDeluxe.CoreSetting.DTOs;
    using Fanex.GoldDeluxe.CoreSetting.Repositories;
    using Fanex.NAP.Framework.Data;
    using Fanex.GoldDeluxe.CoreSetting.Criterias;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.CommandResult;

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

        public SettingDTO GetSuperSetting(int superId)
        {
            return _settingRepository.GetSupperSetting(new GetSuperSettingCriteria
            {
                CustId = superId
            });
        }

        public SettingDTO GetMasterSetting(int masterId, int superId)
        {
            return _settingRepository.GetMasterSetting(new GetMasterSettingCriteria
            {
                CustId = masterId,
                SuperId = superId
            });
        }

        public SettingDTO GetAgentSetting(int agentId, int masterId)
        {
            return _settingRepository.GetAgentSetting(new GetAgentSettingCriteria
            {
                CustId = agentId,
                MasterId = masterId
            });
        }

        public SettingDTO GetMemberSetting(int memberId, int agentId)
        {
            return _settingRepository.GetMemberSetting(new GetMemberSettingCriteria
            {
                CustId = memberId,
                AgentId = agentId
            });
        }

        public SettingDTO GetMemberSettingEditBySuper(int memberId)
        {
            return _settingRepository.GetMemberSettingEditBySuper(new GetMemberSettingEditBySuperCriteria
            {
                CustId = memberId
            });
        }

        public SettingDTO GetMemberSettingEditByMaster(int memberId)
        {
            return _settingRepository.GetMemberSettingEditByMaster(new GetMemberSettingEditByMasterCriteria
            {
                CustId = memberId
            });
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
    }
}
