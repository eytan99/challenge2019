using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public interface IOCRDataProcessor
    {
        OCRProvider Provider { get; }
        Task RunTaskAsync(JToken ocrData, OCRProcessData ocrProcessData);
    }
}