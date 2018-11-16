using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeTofood.Data;
using OdeTofood.Services;

namespace OdeTofood
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddSingleton<IGreeter , Greeter>();

            services.AddDbContext<OdeToFoodDbContext>(
                    options => options.UseSqlServer( _configuration.GetConnectionString( "OdeToFood" ) )
                    );

            services.AddScoped<IRestaurantData , SqlRestaurantData>();


            //for MVC
            services.AddMvc();
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

            #region BEFORE MVC FULL SAVE

            //if ( env.IsDevelopment() )
            //{
            //    //this is for when we have an error, it displays a developer friendly window if we get errors
            //    app.UseDeveloperExceptionPage();
            //}

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

            #region middleware for using static/default files

            //app.UseDefaultFiles();

            ////items from wwwroot
            //app.UseStaticFiles();

            //this install defaultfiles and staticfiles together
            //app.UseFileServer(); //this should be uncomment if we get back

            #endregion


            ////app.Run( async ( context ) =>
            //// {
            ////     //throw new Exception( "error!" );
            ////     //var greeting = configuration[ "Greeting" ];
            ////     var greeting = greeter.GetMessageOfTheDay();
            ////     await context.Response.WriteAsync( $" {greeting} : {env.EnvironmentName}" );
            //// } );
            ///
            #endregion

            //to manually add MVC

            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc( ConfigureRoutes );

            app.Run( async ( context ) =>
            {
                // context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync( $"Not found" );
            } );
        }

        private void ConfigureRoutes( IRouteBuilder routeBuilder )
        {

            // /Home/Index/4   
            //{controller=Home}/{action=Index} here we say: if we dont add in the url Home and Index, then use them as default
            routeBuilder.MapRoute( "Default" ,
                "{controller=Home}/{action=Index}/{id?}" );
        }
    }

}
