using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    /// <summary>
    /// Indian Census Adapter class
    /// </summary>
    /// <seealso cref="IndianStateCensusAnalyzer.POCO.CensusAdapter" />
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeader">The data header.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyzerException">File COntains Wrong Delimiter</exception>
        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath, string dataHeader)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeader);
            foreach(string data  in censusData.Skip(1))
            {
                //If file contains correct deleimiter
                if (!data.Contains(","))
                {
                    throw new CensusAnalyzerException("File COntains Wrong Delimiter", CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER);

                }
                string[] column = data.Split(",");
                if(csvFilePath.Contains("IndiaStateCode.csv"))
                        dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                if(csvFilePath.Contains("IndiaStateCensusData.csv"))
                        dataMap.Add(column[1], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));

            }
            //return dictionary 
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
