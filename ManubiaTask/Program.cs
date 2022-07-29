using System;

namespace ManubiaTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Log(LogLevel.APP_STATE_INFO, nameof(Program), "Process started");

            //Part 1: Download products' data from the website
            new FarmasiRO().Run();
            //Part 2: Classify products' units and values (for example 20ml/5g/3cm)
            new Unit().Run("FarmasiRO");
            new Content().Run("FarmasiRO");

            Logger.Log(LogLevel.APP_STATE_INFO, nameof(Program), "Process finished");
            Console.ReadKey();

            //Pay attention at:
            //not wasting resources
            //not creating obvious or meaningless comments
            //avoiding making boilerplate code
            //handling dangerous code snippets
            //informing about changes of the states
            //writing in a similar way as in the existing code
            //using as much existing code as possible
            //explaining how interesting sections works (you can also add comments to existing code)
            //veryfing results
        }
    }
}
