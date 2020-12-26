using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    /// <summary>
    /// Census Adapter Abstract class
    /// </summary>
    public abstract class CensusAdapter
    {
        /// <summary>
        /// Gets the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyzerException">
        /// File Not found
        /// or
        /// Invalid FIle Type
        /// or
        /// Incorrect headers or file
        /// </exception>
        protected string[] GetCensusData(string csvFilePath,string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyzerException("File Not found", CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyzerException("Invalid FIle Type", CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyzerException("Incorrect headers or file", CensusAnalyzerException.ExceptionType.INCORRECT_HEADER);
            }

            return censusData;
        }
    }
}
