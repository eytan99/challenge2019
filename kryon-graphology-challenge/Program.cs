using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using kryon_graphology_challenge.OCRDataProcessor;
using kryongraphologychallenge.Helpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace kryon_graphology_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //   /$$   /$$                                        
            //  | $$  /$$/                                        
            //  | $$ /$$/   /$$$$$$  /$$   /$$  /$$$$$$  /$$$$$$$ 
            //  | $$$$$/   /$$__  $$| $$  | $$ /$$__  $$| $$__  $$
            //  | $$  $$  | $$  \__/| $$  | $$| $$  \ $$| $$  \ $$
            //  | $$\  $$ | $$      | $$  | $$| $$  | $$| $$  | $$
            //  | $$ \  $$| $$      |  $$$$$$$|  $$$$$$/| $$  | $$
            //  |__/  \__/|__/       \____  $$ \______/ |__/  |__/
            //                       /$$  | $$                    
            //                      |  $$$$$$/                    
            //                       \______/                     

            // TODO: STAGE 1 - read and understand what this code is suppose to do //
            var paths = Enumerable.Range(1, 5)
                            .Select(i => $"demo-image-{i.ToString()}.jpeg");

            IOCRDataProcessorStartegy ocrDataProcessorStartegy = InitOCRDataProcessorStartegy();

            foreach (string path in paths) {
                Console.WriteLine("\nReading challenge file " + path + "...\n");
                var process = HandwritingAnalyzer.ReadHandwrittenText("./Image-files/" + path);
                process.Wait();
                JToken result = process.Result;
                // TODO: STAGE 2 - fix the code so it prints the wanted results //
                // WANT TO ANALYZE HUGE AMOUNTS OF TEXT 
                // AND UTILIZE IT TO PARTICIPATE THE NEXT
                // INDUSTRIAL REVOLUTION? 

                var tOCRProcess = ocrDataProcessorStartegy.RunTaskAsync(result, new OCRProcessData { Provider = OCRProvider.Microsoft });
                tOCRProcess.Wait();
            }

            // TODO: STAGE 3 - find the connections between the outputs above //
            Console.WriteLine("\nCan you find the connection between the outputs above?");
            // Russian and American leaders in the 18th century

            // TODO: STAGE 4 - submit your answers, repo and CV, and join us for a cup of coffee //
            Console.WriteLine("\nSend us your solution with the github repo and your CV to challenge@kryonsystems.com and wait for our call!\n");
            Console.ReadLine();
        }

        private static IOCRDataProcessorStartegy InitOCRDataProcessorStartegy()
        {
            var microsoftProcessor = new MicrosoftOCRDataProcessor();
            var googleProcessor = new GoogleOCRDataProcessor();
            var processors = new OCRDataProcessorStartegyFactory(microsoftProcessor, googleProcessor).Create();
            return new OCRDataProcessorStartegy(processors);
        }
    }
}
