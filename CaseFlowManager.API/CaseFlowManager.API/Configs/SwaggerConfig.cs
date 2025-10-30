using IMotionSoftware.CaseFlowManager.API.Configs;
using Swashbuckle.Application;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace IMotionSoftware.CaseFlowManager.API.Configs
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration.EnableSwagger( c => 
            {   
                c.SingleApiVersion("v1", "Case Flow Manager API")
                    .Description("API for managing case flows");

                var xmlPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "IMotionSoftware.CaseFlowManager.API.xml");
                if (System.IO.File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            })
            .EnableSwaggerUi(c =>
            {
                c.DocumentTitle("CaseFlow Manager API Docs");
                c.DisableValidator();
            });
        }
    }
}
