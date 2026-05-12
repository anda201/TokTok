using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using TokTok.ViewModels;
using TokTok.Views;

namespace TokTok
{
    public partial class App : Application
    {
        public App()
        {
            //객체 생성을 할 때 필요한 서비스를 주입받아 사용할 수 있도록 설정
            //의존성 주입은 객체 생성을 직접적으로 하지 않고, 필요한 서비스를 외부에서 주입받아 사용하는 디자인 패턴입니다.
            Services = ConfigureServices();
            Startup += App_StartUp;
        }
        private void App_StartUp(object sender, StartupEventArgs e)
        {
            //생성자 주입을 통해 MainView 객체를 생성
            var mainView = App.Current.Services.GetService<MainView>();
            mainView.Show();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginControlViewModel>();
            services.AddTransient<SignupControlViewModel>();
            services.AddTransient<ChangePwdControlViewModel>();

            //Services

            //Views
            services.AddSingleton<MainView>();
            return services.BuildServiceProvider();
        }
    }

}
