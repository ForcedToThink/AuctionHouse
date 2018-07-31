using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AuctionHouse.WebApi
{
    /// <summary>
    ///     Program
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main app method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///     Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
