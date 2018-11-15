using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeTofood
{
    public class Program
    {
        public static void Main( string [ ] args )
        {
            CreateWebHostBuilder( args ).Build().Run();
        }

        // IT sets up

        //1. Will use Kestrel web server(listen for HTTP connection)
        //2. IIS Integration
        //3. Logging
        //4. Create an object that implements IConfiguration service made available
        //   - JSON File(appsettings.json)
        //   - User Secrets
        //   - Environment variables
        //   - Command line arguments
        public static IWebHostBuilder CreateWebHostBuilder( string [ ] args ) =>
            WebHost.CreateDefaultBuilder( args )
                .UseStartup<Startup>().UseUrls( "https://127.0.0.1:5400" );
    }
}
