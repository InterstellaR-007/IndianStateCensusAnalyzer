using IndianStateCensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA,US,BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeader)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeader);
            return dataMap;

        }
        
    }
}
