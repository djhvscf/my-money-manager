using Syncfusion.Licensing;
using Xamarin.Forms;

namespace ExpenseAnalysis
{
    public class App : Application
    {
        private static DataService _dataService;

        public static DataService DataService => _dataService ?? (_dataService = new DataService());

        public App()
        {
            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("MjYxNzE3QDMxMzgyZTMxMmUzMEJJS0N5emt4ZGVCMEJjbmVuZ014YWtaYWxUdTdHTFpYaTZNandiNmQvUjA9");

            MainPage = new MasterDetail();
        }
    }
}