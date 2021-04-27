using System;
using System.Threading.Tasks;

namespace Module4_Task3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /*await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query1();
            }*/

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query2();
            }

            /*await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query3();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query4();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query5();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LazyLoadingSamples(context).Query6();
            }*/
        }
    }
}
