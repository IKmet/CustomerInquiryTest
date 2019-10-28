using AutoMapper;
using CustomerInquiry.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerInquiry {
  public class Startup {
    public Startup(IHostingEnvironment env, IConfiguration conf) {
      this.Configuration = conf;

      var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath);

      builder.AddUserSecrets<Startup>();

      this.Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new MappingProfile());
      });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);

      services.AddDbContext<CustomerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.Run(async (context) => {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}
