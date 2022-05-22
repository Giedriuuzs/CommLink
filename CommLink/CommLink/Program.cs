using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;

namespace CommLink
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).UseUrls(System.Configuration.ConfigurationManager.ConnectionStrings["SignalR"].ConnectionString).Build();
            var hubContext = (IHubContext<ClientHub>)host.Services.GetService(typeof(IHubContext<ClientHub>));
            try
            {
                Thread signalR = new Thread(() => {
                    try
                    {
                        host.Run();
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message, "Communications with mobile apps will not work!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        throw;
                    }
                    
                });
                signalR.IsBackground = true;
                signalR.Start();
            }
            catch (ThreadInterruptedException ex)
            {
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(hubContext));
           // Application.ThreadExit(){ }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();

    }
}