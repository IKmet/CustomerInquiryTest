using AutoMapper;
using CustomerInquiry.ActionFilters;
using CustomerInquiry.Common.Interfaces;
using CustomerInquiry.Infrastructure.DataAccess.SQL;
using CustomerInquiry.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerInquiry
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration conf)
        {
            this.Configuration = conf;

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath);

            builder.AddUserSecrets<Startup>();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDataAccessService(Configuration.GetConnectionString("DefaultConnection"));

            services.AddSwagger();

            services.AddTransient<CustomerInquiryFilter>();

            services.AddTransient<ICustomerInfoProvider, SQLCustomerInfoProvider>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseMvcWithDefaultRoute();

            app.UseCustomSwagger();
        }
    }
}
