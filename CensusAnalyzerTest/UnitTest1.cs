using IndianStateCensusAnalyzer.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.POCO.CensusAnalyzer;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCode.csv";

        IndianStateCensusAnalyzer.POCO.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecords = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);


            Assert.AreEqual(29,totalRecords.Count);
            Assert.AreEqual(37, stateRecords.Count);
        }
    }
}