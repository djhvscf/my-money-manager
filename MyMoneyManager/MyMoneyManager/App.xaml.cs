using Autofac;
using Autofac.Util;
using MyMoneyManager.DataAccess;
using MyMoneyManager.Helpers;
using MyMoneyManager.Services;
using MyMoneyManager.ViewModels;
using Syncfusion.Licensing;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace MyMoneyManager
{
    public partial class App : Application
    {
        public static IContainer Container;

        static readonly ContainerBuilder Builder = new ContainerBuilder();

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjYxNzE3QDMxMzgyZTMxMmUzMEJJS0N5emt4ZGVCMEJjbmVuZ014YWtaYWxUdTdHTFpYaTZNandiNmQvUjA9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            Builder.RegisterType<T>().As<TInterface>();
        }

        public static void BuildContainer()
        {
            RegisterSharedTypes();
            Container = Builder.Build();
        }

        private static void RegisterSharedTypes()
        {
            ConfigAutoMapper();
            RegisterOther();
            RegisterRepositories();
            RegisterServices();
            RegisterViewModels();
        }

        private static void RegisterRepositories()
        {
            RegisterTypes(typeof(IRepository).GetTypeInfo().Assembly, "Repository");
        }

        private static void RegisterServices()
        {
            RegisterTypes(typeof(IService).GetTypeInfo().Assembly, "Service");
        }

        private static void RegisterOther()
        {
            RegisterTypes(typeof(ISessionManager).GetTypeInfo().Assembly, "SessionManager");
        }

        private static void RegisterViewModels()
        {
            var viewModelsassembly = typeof(BaseViewModel).GetTypeInfo().Assembly;
            var viewModels = viewModelsassembly.GetLoadableTypes()
                .Where(x => x.IsAssignableTo<BaseViewModel>() && x != typeof(BaseViewModel));
            foreach (var type in viewModels)
            {
                Builder.RegisterType(type);
            }
        }

        private static void RegisterTypes(Assembly assembly, string endsWith)
        {
            Builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(endsWith))
                .AsImplementedInterfaces();
        }

        private static void ConfigAutoMapper()
        {
            Builder.RegisterInstance(AutoMapperConfiguration.Configure());
        }
    }
}
