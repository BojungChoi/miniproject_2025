using System.Windows;
using WpfIoTSimulatorApp.Views;
using WpfIoTSimulatorApp.ViewModels;

namespace WpfIoTSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewModel = new MainViewModel();
            var view = new MainView { 
                DataContext = viewModel,
            };

            // 
            viewModel.StartHmiAnimation += view.StartHmiAni; // ViewModel에서 View 애니메이션 메서드 연결
            viewModel.StartSensorCheckRequest += view.StartSensorCheck; // 센서 체크 요청

            view.ShowDialog();            
        }
    }

}
