using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineXOGame_Client.ClientAPI.DependencyInjection;
using OnlineXOGame_Client.WinForms.Common;
using OnlineXOGame_Client.WinForms.DependencyInjection;
using OnlineXOGame_Client.WinForms.Forms;

namespace OnlineXOGame_Client.WinForms {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            var serviceProvider = host.Services;
            var mainForm = serviceProvider.GetRequiredService<LoginAndSignUpForm>();
            //var mainForm = serviceProvider.GetRequiredService<Form1>();

            Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder() {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context,services) => {
                    // Register your forms (transient by default)
                    services.AddWinForms();
                    services.AddClientApi(context.Configuration);
                });
        }
    }
}