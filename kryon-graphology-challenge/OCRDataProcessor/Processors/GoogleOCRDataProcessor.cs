using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public class GoogleOCRDataProcessor : IOCRDataProcessor
    {
        public OCRProvider Provider => OCRProvider.Google;

        public async Task RunTaskAsync(JToken ocrData, OCRProcessData ocrProcessData)
        {
            throw new System.NotImplementedException();
        }
    }
}