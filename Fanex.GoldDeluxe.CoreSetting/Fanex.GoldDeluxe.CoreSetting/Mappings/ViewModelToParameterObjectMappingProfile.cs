namespace Fanex.GoldDeluxe.CoreSetting.Mappings
{
    using AutoMapper;
    using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
    using Fanex.GoldDeluxe.CoreSetting.ViewModels;

    public class ViewModelToParameterObjectMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToParameterObjectMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EditSettingViewModel, UpdatePTAndComParameters>()
                .ForMember(x => x.PositionTaking, opt => opt.MapFrom(source => source.Setting.PositionTaking))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Setting.Commission));
            Mapper.CreateMap<EditSettingViewModel, GetSettingParameters>();
            Mapper.CreateMap<EditSettingViewModel, UpdateGameSettingParameters>()
                .ForMember(x => x.GameSetting, opt => opt.MapFrom(source => source.Setting.GameSetting));
        }
    }
}
