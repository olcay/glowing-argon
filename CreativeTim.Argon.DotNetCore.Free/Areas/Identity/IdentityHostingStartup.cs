using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Ookgewoon.Web.Areas.Identity.IdentityHostingStartup))]
namespace Ookgewoon.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}