using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TesztNaplo
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("TesztNaplo.Program");

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            //naplóírás 
            var r = new Random();

            Console.WriteLine("Megállításhoz egy gombot kell nyomni...");
            while (!Console.KeyAvailable)
            {
                var val = r.Next(100);
                Thread.Sleep(4);

                if (val<60)
                {
                    logger.Debug("Ez egy debug");
                }
                else if (val < 80)
                {
                    logger.Info("Ez egy info");
                }
                else if (val < 90)
                {
                    logger.Warn("Warning");
                }
                else if (val < 97)
                {
                    try
                    {
                        throw new Exception("csibészkedem, dobok egy kivételt");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Error", ex);
                    }
                }
                else 
                {
                    logger.Fatal("Fatal");
                }
            }

            log4net.LogManager.Shutdown();

        }
    }
}
