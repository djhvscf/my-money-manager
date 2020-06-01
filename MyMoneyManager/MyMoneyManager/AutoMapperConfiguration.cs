using AutoMapper;
using MyMoneyManager.ViewModels;

namespace MyMoneyManager
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<BaseViewModel, AboutViewModel>().ReverseMap()
            );

            return config.CreateMapper();
        }
    }
}
