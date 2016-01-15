using Autofac;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.View;
using BlocNotasCurso.ViewModel;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class Startup : AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocNotasModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<RegistroViewModel, Registro>();
            viewFactory.Register<PrincipalViewModel, Principal>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            // pondrá la barra de navegacion arriba
            var np = new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}