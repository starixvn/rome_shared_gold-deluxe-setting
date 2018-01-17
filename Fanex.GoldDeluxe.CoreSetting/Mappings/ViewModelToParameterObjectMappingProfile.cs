namespace Fanex.GoldDeluxe.CoreSetting.Mappings
{
    using System;
    using System.Linq;
    using AutoMapper;
    using DTOs;
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
            Mapper.CreateMap<EditSettingViewModel, GetSettingParameters>();
            Mapper.CreateMap<EditSettingViewModel, UpdatePTAndComParameters>()
                .ForMember(x => x.PositionTaking, opt => opt.MapFrom(source => source.Setting.PositionTaking))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Setting.Commission));
            Mapper.CreateMap<EditSettingViewModel, UpdateGameSettingParameters>()
                .ForMember(x => x.GameSetting, opt => opt.MapFrom(source => source.Setting.GameSetting));
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdatePTAndComParameters>()
                .ForMember(x => x.PositionTaking, opt => opt.MapFrom(source => source.Setting.PositionTaking))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Setting.Commission));
            Mapper.CreateMap<EditSettingViewModel, UpdateWinLimitParameters>()
                .ForMember(x => x.MaxWinLimit, opt => opt.MapFrom(source => source.Setting.WinLimit.Max))
                .ForMember(x => x.IsAutoReset, opt => opt.MapFrom(source => source.Setting.WinLimit.IsAutoReset));
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdateGameSettingParameters>()
                .ForMember(x => x.GameSetting, opt => opt.MapFrom(source => source.Setting.GameSetting));
            Mapper.CreateMap<EditSettingViewModel, UpdateDisableStatusParameters>()
                .ForMember(x => x.Disable, opt => opt.MapFrom(source => source.Setting.DisableGoldDeluxe));
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdateDisableStatusParameters>()
                .ForMember(x => x.Disable, opt => opt.MapFrom(source => source.Setting.DisableGoldDeluxe));
            Mapper.CreateMap<EditSettingMultipleViewModel, GetSettingParameters>();
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdateGameSettingMultipleParameters>()
                .ForMember(x => x.CustIds, opt => opt.MapFrom(source => source.CustIds.Split(',').Select(int.Parse).ToList()))
                .ForMember(x => x.Usernames, opt => opt.MapFrom(source => source.Usernames.Split(',').ToList()))
                .ForMember(x => x.GameSetting, opt => opt.MapFrom(source => source.Setting.GameSetting));
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdatePTAndComMultipleParameters>()
                .ForMember(x => x.CustIds, opt => opt.MapFrom(source => source.CustIds.Split(',').Select(int.Parse).ToList()))
                .ForMember(x => x.Usernames, opt => opt.MapFrom(source => source.Usernames.Split(',').ToList()))
                .ForMember(x => x.PositionTaking, opt => opt.MapFrom(source => source.Setting.PositionTaking))
                .ForMember(x => x.Commission, opt => opt.MapFrom(source => source.Setting.Commission));
            Mapper.CreateMap<EditSettingMultipleViewModel, UpdateWinLimitMultipleParameters>()
                .ForMember(x => x.CustIds, opt => opt.MapFrom(source => source.CustIds.Split(',').Select(int.Parse).ToList()))
                .ForMember(x => x.Usernames, opt => opt.MapFrom(source => source.Usernames.Split(',').ToList()))
                .ForMember(x => x.MaxWinLimit, opt => opt.MapFrom(source => source.Setting.WinLimit.Max))
                .ForMember(x => x.IsAutoReset, opt => opt.MapFrom(source => source.Setting.WinLimit.IsAutoReset));
        }
    }
}