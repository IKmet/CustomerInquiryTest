using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerInquiry {

  public class Program {

    public static void Main(string[] args) {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(logging => {
              logging.AddConsole();
              logging.AddDebug();
              logging.AddEventSourceLogger();
            });
  }
}
