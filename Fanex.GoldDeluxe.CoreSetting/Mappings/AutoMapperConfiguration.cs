namespace Fanex.GoldDeluxe.CoreSetting.Mappings
{
    using AutoMapper;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ViewModelToParameterObjectMappingProfile>();
                x.AddProfile<ParameterObjectToCriteriaMappingProfile>();
            });
        }
    }
}