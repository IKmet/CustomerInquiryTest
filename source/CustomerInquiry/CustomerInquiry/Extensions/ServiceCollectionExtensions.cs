using CustomerInquiry.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CustomerInquiry.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static void AddSwagger(this IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Customer Inquiry API",
          Version = "v1",
          Contact = new OpenApiContact() { Name = "Test Person", Email = "test@contact.com" }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    public static void AddDataAccessService(this IServiceCollection services, string connectionString)
    {
      services.AddDbContext<CustomerContext>(options =>
        options.UseSqlServer(connectionString));
    }
  }
}
