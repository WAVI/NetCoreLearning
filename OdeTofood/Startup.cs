using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OdeTofood
{
   public class Startup
   {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices( IServiceCollection services )
      {
         //services.AddScoped<IGreeter, Greeter>();
         services.AddSingleton<IGreeter, Greeter>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      //The code will response to whatever we configure here in the "Configure" method
      public void Configure( IApplicationBuilder app, 
                             IHostingEnvironment env,
                             //IConfiguration configuration,
                             IGreeter greeter
                             )
      {
         if( env.IsDevelopment() )
         {
            app.UseDeveloperExceptionPage();
         }

         app.Run( async ( context ) =>
          {
             //var greeting = configuration[ "Greeting" ];
             var greeting = greeter.GetMessageOfTheDay();
             await context.Response.WriteAsync( greeting );
          } );
      }
   }
   
}
