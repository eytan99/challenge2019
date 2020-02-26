using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public interface IOCRDataProcessorStartegy
    {
        Task RunTaskAsync(JToken OCRData, OCRProcessData processData);
    }

    public class OCRDataProcessorStartegy : IOCRDataProcessorStartegy
    {
        private readonly IOCRDataProcessor[] _ocrDataProcessors;

        public OCRDataProcessorStartegy(IOCRDataProcessor[] ocrDataProcessors)
        {
            _ocrDataProcessors = ocrDataProcessors;
        }

        public Task RunTaskAsync(JToken OCRData,  OCRProcessData processData)
        {
            return _ocrDataProcessors.FirstOrDefault(x => x.Provider == processData.Provider).RunTaskAsync(OCRData, processData);
        }
    }
}
