using InUit.Model;
using InUit.Model.Bookkeeping;
using InUit.Model.Users;
using Ninject;
using System;
using System.Windows.Forms;

namespace InUit.Ui.Desktop.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(DI.Get<Main>());
        }

        public static IKernel DI { get; }
        static Program() {
            DI = new StandardKernel();
            DI.Bind<AppContext>().ToSelf().InSingletonScope();
            DI.Bind<IUserProvider>().To<WindowsIdentityUserProvider>();
            DI.Bind<IBookRepository>().To<JsonBookRepository>();            
        }
    }
}
