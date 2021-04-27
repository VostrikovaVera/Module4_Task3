using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4_Task3.Entities;

namespace Module4_Task3
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Query1()
        {
            var employees = await _context.Employees
                .Select(x => new { Name = $"{x.FirstName} {x.LastName}", Title = x.Title.Name, Location = x.Office.Location })
                .ToListAsync();

            Console.WriteLine("Employee data");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee name: {employee.Name}. Employee job title: {employee.Title}. Employee location: {employee.Location}.");
            }
        }

        public async Task Query2()
        {
            var projects = await _context.Projects
                .Select(x => new { StartedDate = x.StartedDate })
                .ToListAsync();

            Console.WriteLine("Date time span from project started date till now");
            foreach (var project in projects)
            {
                // Tried DateTime.Now.Subtract(x.HiredDate) & DbFunctions.DateDiff() - but they doesn't work properly
                Console.WriteLine($"Date time span: {DateTime.Now - project.StartedDate}.");
            }
        }

        public async Task Query3()
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Name == "Monobank App");

            var client = await _context.Clients
                .FirstOrDefaultAsync(p => p.CompanyName == "Monobank");

            project.Name = "MonoBank Premium App";
            client.CompanyName = "MonoBank Premium";

            await _context.SaveChangesAsync();
        }

        public async Task Query4()
        {
            var jobTitle = await _context.Titles
                .FirstOrDefaultAsync(t => t.Name == ".Net Developer");

            var office = await _context.Offices
                .FirstOrDefaultAsync(p => p.Title == "USA HQ");

            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Name == "MonoBank Premium App");

            var employee = new Employee()
            {
                FirstName = "Monica",
                LastName = "Geller",
                HiredDate = new DateTime(2008, 08, 06),
                TitleId = jobTitle.TitleId,
                OfficeId = office.OfficeId,
                EmployeeProjects = new List<EmployeeProject>() { new EmployeeProject() { Rate = 25, StartedDate = DateTime.Now, ProjectId = project.ProjectId } }
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Query5()
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.FirstName == "Rachel" && e.LastName == "Green");

            _context.EmployeeProjects.RemoveRange(employee.EmployeeProjects);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Query6()
        {
            var employeesTitles = await _context.Employees
                .GroupBy(e => e.Title.Name)
                .Select(x => new { Title = x.Key })
                .Where(n => !n.Title.Contains("a"))
                .ToListAsync();

            foreach (var title in employeesTitles)
            {
                Console.WriteLine($"Title name: {title}.");
            }
        }
    }
}
