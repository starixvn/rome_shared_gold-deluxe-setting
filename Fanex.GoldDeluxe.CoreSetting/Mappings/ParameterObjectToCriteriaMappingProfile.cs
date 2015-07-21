namespace Fanex.GoldDeluxe.CoreSetting.Mappings
{
    using AutoMapper;
    using Fanex.GoldDeluxe.CoreSetting.Criterias;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;

    public class ParameterObjectToCriteriaMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ParameterObjectToCriteriaMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UpdateDisableStatusParameters, UpdateDisableStatusCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateSuperPTAndComCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Commission.Commission))
                .ForMember(x => x.N4, opt => opt.MapFrom(source => source.PositionTaking.N4))
                .ForMember(x => x.S4, opt => opt.MapFrom(source => source.PositionTaking.S4));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateMasterPTAndComCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Commission.Commission))
                .ForMember(x => x.S3, opt => opt.MapFrom(source => (bool)source.PositionTaking.Is3 ? 0 : source.PositionTaking.S3))
                .ForMember(x => x.M3, opt => opt.MapFrom(source => source.PositionTaking.M3))
                .ForMember(x => x.Is3, opt => opt.MapFrom(source => source.PositionTaking.Is3))
                .ForMember(x => x.Us3, opt => opt.MapFrom(source => (bool)source.PositionTaking.Is3 ? source.PositionTaking.Us3 : 0))
                .ForMember(x => x.N3, opt => opt.MapFrom(source => source.PositionTaking.N3));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateAgentPTAndComCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Commission.Commission))
                .ForMember(x => x.M2, opt => opt.MapFrom(source => (bool)source.PositionTaking.Im2 ? 0 : source.PositionTaking.M2))
                .ForMember(x => x.Um2, opt => opt.MapFrom(source => (bool)source.PositionTaking.Im2 ? source.PositionTaking.Um2 : 0))
                .ForMember(x => x.Im2, opt => opt.MapFrom(source => source.PositionTaking.Im2))
                .ForMember(x => x.A2, opt => opt.MapFrom(source => source.PositionTaking.A2))
                .ForMember(x => x.N2, opt => opt.MapFrom(source => source.PositionTaking.N2));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateMemberPTAndComCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Commission.Commission))
                .ForMember(x => x.A1, opt => opt.MapFrom(source => source.PositionTaking.A1));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateMemberPTAndComByMasterCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.M1, opt => opt.MapFrom(source => source.PositionTaking.M1))
                .ForMember(x => x.Um1, opt => opt.MapFrom(source => (bool)source.PositionTaking.Im1 ? source.PositionTaking.Um1 : 0))
                .ForMember(x => x.Im1, opt => opt.MapFrom(source => source.PositionTaking.Im1))
                .ForMember(x => x.Im2, opt => opt.MapFrom(source => source.PositionTaking.Im2))
                .ForMember(
                        x => x.IsUpdateOnMember,
                        opt => opt.MapFrom(source => (bool)source.PositionTaking.Im1 ? false : ((bool)source.PositionTaking.Im2 ? false : true)));
            Mapper.CreateMap<UpdatePTAndComParameters, UpdateMemberPTAndComBySuperCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.S1, opt => opt.MapFrom(source => source.PositionTaking.S1))
                .ForMember(x => x.Is1, opt => opt.MapFrom(source => source.PositionTaking.Is1))
                .ForMember(x => x.Us1, opt => opt.MapFrom(source => (bool)source.PositionTaking.Is1 ? source.PositionTaking.Us1 : 0))
                .ForMember(
                        x => x.IsUpdateOnMember,
                        opt => opt.MapFrom(source => (bool)source.PositionTaking.Is1 ? false : ((bool)source.PositionTaking.Is3 ? false : true)));
            Mapper.CreateMap<UpdateGameSettingParameters, UpdateGameSettingCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId))
                .ForMember(x => x.StakeLevel, opt => opt.MapFrom(source => source.ToXmlCheckedGameSetting()));
            Mapper.CreateMap<UpdateWinLimitParameters, UpdateWinLimitCriteria>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(source => source.ActorId));
        }
    }
}