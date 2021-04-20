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
                var employees = db.Employees.ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.Id} - {employee.FirstName} {employee.LastName} - {employee.HiredDate:dd/MM/yyyy}");
                }

                db.Employees.Add(new Employee() { EmployeeId = 3, FirstName = "Monica", LastName = "Geller", DateOfBirth = new DateTime(1980, 10, 12), HiredDate = new DateTime(2016, 11, 26), OfficeId = 2, TitleId = 2 });
                db.SaveChanges();
            }

            Console.Read();
        }
    }
}