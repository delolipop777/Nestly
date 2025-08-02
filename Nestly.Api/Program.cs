// |====================================================|
// |Copyright©                                          |
// |Nestly API - Home Finder                            |
// |Modern API to discover homes for rent  or purchase  |
// |                                                    | 
// |----------------------------------------------------|
// |                                                    | 
// |All rights reserved, including the right to         |
// |reproduce this work in any form. For permission     |
// |requests, contact [bilolbek424@gmail.com]           |
// |====================================================|


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Nestly.Api
{
    public class Program
    {
        public static void Main(string[] args) =>
                    CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>());
        }
    }
}
