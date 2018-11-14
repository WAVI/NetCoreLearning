using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeTofood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            //services.AddScoped<IGreeter, Greeter>();
            services.AddSingleton<IGreeter , Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //The code will response to whatever we configure here in the "Configure" method
        public void Configure( IApplicationBuilder app ,
                               IHostingEnvironment env ,
                               //IConfiguration configuration,
                               IGreeter greeter ,
                               ILogger<Startup> logger
                               )
        {

            if ( env.IsDevelopment() )
            {
                //this is for when we have an error, it displays a developer friendly window if we get errors
                app.UseDeveloperExceptionPage();
            }

            //ORDER OF MIDDLEWARE IS IMPORTANT

            #region mymiddleware
            /*
            app.Use( next =>
            {
                return async context =>
                {                                                               
                    logger.LogInformation( "Request incoming" );                
                    if ( context.Request.Path.StartsWithSegments( "/mym" ) )    
                    {                                                           
                        await context.Response.WriteAsync( "HIT!!" );           
                        logger.LogInformation( "Request handled" );             
                    }                                                           
                    else                                                        
                    {                                                           
                        await next( context );                                  
                        logger.LogInformation( "Response outgoing" );           
                    }                                                           
                };
            } );

            app.UseWelcomePage( new WelcomePageOptions
            {
                Path = "/wp"
            } );
            */

            #endregion mymiddleware

            //app.UseDefaultFiles();

            ////items from wwwroot
            //app.UseStaticFiles();

            //this install defaultfiles and staticfiles together
            app.UseFileServer();
           

            app.Run( async ( context ) =>
             {
                 //throw new Exception( "error!" );
                 //var greeting = configuration[ "Greeting" ];
                 var greeting = greeter.GetMessageOfTheDay();
                 await context.Response.WriteAsync( $" {greeting} : {env.EnvironmentName}" );
             } );
        }
    }

}
