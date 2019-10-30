using Microsoft.AspNetCore.Builder;

namespace CustomerInquiry.Extensions
{
  public static class ApplicationBuilderExtensions
  {
    public const string SwaggerEndpointName = "Customer Inquiry V1";

    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", SwaggerEndpointName);
      });
    }
  }
}
