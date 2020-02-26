using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public class MicrosoftOCRDataProcessor: IOCRDataProcessor
    {
        //private readonly ILogger _logger;

        public OCRProvider Provider => OCRProvider.Microsoft;

        //public MicrosoftOCRDataProcessor(ILogger<MicrosoftOCRDataProcessor> logger)
        //{
        //    _logger = logger;
        //}

        public async Task RunTaskAsync(JToken ocrData, OCRProcessData ocrProcessData)
        {
            //_logger.LogInformation("Start Job ID: {Id}, Provider :{Provider}", ocrProcessData.Id, ocrProcessData.Provider);

            var textLines = ocrData["recognitionResults"]
                    .SelectMany(page => page["lines"])
                    .Select(line => $"{line["text"].ToString()} ");
            await Task.Run(() =>
            {
                foreach (var line in textLines)
                {
                    Console.WriteLine(line);
                }
            });

            //_logger.LogInformation("Finish Job ID: {Id}", ocrProcessData.Id);
        }
    }
}