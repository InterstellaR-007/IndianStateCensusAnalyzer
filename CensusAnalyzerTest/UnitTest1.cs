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
        static string wrongIndianStateCensusFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCensusDataFilePath.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\anujs\source\repos\IndianStateCensusAnalyzer\CensusAnalyzerTest\CSVFiles\WrongIndiaStateCodeFilePath.txt";

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
            Dictionary<string, CensusDTO> indiaStateCensusTotalRecords = new Dictionary<string, CensusDTO>();

            indiaStateCensusTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
         
            Assert.AreEqual(29, indiaStateCensusTotalRecords.Count);
            
        }
        [Test]
        public void GivenIndianStateCodeDataFile_WhenRead_ShouldReturnCodeDataCount()
        {
            Dictionary<string, CensusDTO> indiaStateCodeTotalRecords = new Dictionary<string, CensusDTO>();

            indiaStateCodeTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);

            Assert.AreEqual(37, indiaStateCodeTotalRecords.Count);
        }

        [Test]
        public void GivenIncorrectIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCensusTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCensusTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders);
                
            }
            catch(CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, e.eType);
            }
            
        }

        [Test]
        public void GivenIncorrectIndianStateCodeFile_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCodeTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCodeTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, e.eType);
            }

        }

        [Test]
        public void GivenIncorrectIndianCensusDataFileType_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCensusTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCensusTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }

        }

        [Test]
        public void GivenIncorrectIndianStateCodeFileType_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCodeTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCodeTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, e.eType);
            }

        }
        [Test]
        public void GivenIncorrectIndianCensusDataDelimiter_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCensusTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCensusTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }

        }

        [Test]
        public void GivenIncorrectIndianStateCodeDelimiter_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCodeTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCodeTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, e.eType);
            }

        }

        [Test]
        public void GivenIncorrectHeaderForIndianCensusData_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCensusTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCensusTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, e.eType);
            }

        }

        [Test]
        public void GivenIncorrectHeaderIndianStateCode_WhenRead_ShouldReturnException()
        {
            try
            {
                Dictionary<string, CensusDTO> indiaStateCodeTotalRecords = new Dictionary<string, CensusDTO>();

                indiaStateCodeTotalRecords = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders);

            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, e.eType);
            }

        }
    }
}