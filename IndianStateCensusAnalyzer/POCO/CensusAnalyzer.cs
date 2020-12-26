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
        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeader">The data header.</param>
        /// <returns></returns>
        public Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeader)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeader);
            return dataMap;

        }
        
    }
}
