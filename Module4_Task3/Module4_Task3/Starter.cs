using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4_Task3.Entities;

namespace Module4_Task3
{
    public class Starter
    {
        public void Run()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (var db = new ApplicationContext(options))
            {
            }

            Console.Read();
        }
    }
}