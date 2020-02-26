using System;

namespace kryon_graphology_challenge.OCRDataProcessor
{
    public interface IOCRProcessData
    {
        Guid Id { get; set; }
        OCRProvider Provider { get; set; }
    }

    public class OCRProcessData : IOCRProcessData
    {
        public Guid Id { get; set; }
        public OCRProvider Provider { get; set; }

        public OCRProcessData()
        {
            Id = Guid.NewGuid();
        }
        public OCRProcessData(Guid id, OCRProvider provider)
        {
            Id = id;
            Provider = provider;
        }
    }
}