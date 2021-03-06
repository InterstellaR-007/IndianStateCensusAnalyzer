﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    /// <summary>
    /// CSV File Adapter Class
    /// </summary>
    public class CSVAdapterFactory
    {
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyzer.Country country,string csvFilePath,string dataHeader)
        {
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                default:
                    throw new CensusAnalyzerException("No such country", CensusAnalyzerException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
