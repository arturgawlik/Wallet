using AutoMapper;

namespace WalletInfrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                
            })
            .CreateMapper();
    }
}