using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public interface IOCRDataProcessorStartegyFactory
    {
        IOCRDataProcessor[] Create();
    }

    public class OCRDataProcessorStartegyFactory : IOCRDataProcessorStartegyFactory
    {
        private readonly MicrosoftOCRDataProcessor _microsoftProcessor;
        private readonly GoogleOCRDataProcessor _googleOCRDataProcessor;

        public OCRDataProcessorStartegyFactory(MicrosoftOCRDataProcessor microsoftProcessor,
            GoogleOCRDataProcessor googleOCRDataProcessor)
        {
            _microsoftProcessor = microsoftProcessor;
            _googleOCRDataProcessor = googleOCRDataProcessor;
        }

        public IOCRDataProcessor[] Create() => new IOCRDataProcessor[] { _microsoftProcessor, _googleOCRDataProcessor };
    }
}
