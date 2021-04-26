using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module4_Task3
{
    public class LazyLoadingSamples
    {
        private readonly ApplicationContext _context;

        public LazyLoadingSamples(ApplicationContext context)
        {
            _context = context;
        }

        public async Task GetDateTimeSpan()
        {
            var projects = await _context.Projects
                .Select(x => new { StartedDate = x.StartedDate })
                .ToListAsync();

            Console.WriteLine("Date span from project started date till now");
            foreach (var project in projects)
            {
                Console.WriteLine($"Date span: {DateTime.Now - project.StartedDate}.");
            }
        }
    }
}
