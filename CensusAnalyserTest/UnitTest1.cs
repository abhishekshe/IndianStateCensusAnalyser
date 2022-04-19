using NUnit.Framework;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
//using IndianStateCensusAnalyser.CensusAnalyser;

using IndianStateCensusAnalyser.POCO;
using Newtonsoft.Json;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string wrongHeaderindianCensusFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";  
        static string wrongindianStateCensusFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string indiaStateCodeFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCodes.csv";
        static string delimiterindianCensusFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianStateCesusDelimeter.csv";
        static string delimiterIndiaStateCodeFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCodes.csv";
        static string wrongindianStateCensusFileType = @"";
        static string wrongindianStateCodeFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongindianStateCodeFileType = @"";
        static string indianStateCensusFilePath = @"D:\BridgeLabz\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCensusHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        private string indiaStateCensusFilePath;
        private string indianStateCodesHeaders;
        private string wrongIndiaStateCensusData;
        private string indiaStateCensusDataText;
        private string delimiterIndiaStateCensusData;
        private string indiaStateCode;
        private object delimiterIndiaStateCode;
        private object wrongIndiaStateCode;
        private object indiaStateCodeText;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }
       

        [Test]
        public void GivenIndianCensusDataFile_WhenReturnShouldReturnCensusDataCount()
        {
           
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCodeFilePath, indianStateCodesHeaders);


            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
       
        public void GivenWrongIndianCensusDataFile_WhenReadedShouldReturnCustomException()
        {
            
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// test case 1.3
        /// </summary>
        public void GivenWrongIndianCensusDataType_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusDataText, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// test case 1.4
        /// </summary>
        public void GivenIncorrectDelimiterForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect header is passed
        /// test case 1.5
        /// </summary>
        public void GivenIncorrectHeaderForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.etype);
        }

        /// <summary>
        /// Test Case 2.1
        /// Getting the count of data in IndiaStateCodeData
        /// </summary>

        [Test]
        public void GivenIndianCodeDataFile_WhenReturnShouldReturnCodeCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCode, indianStateCodeHeaders);
            //assert
            //total no of rows excluding header are 37 in indian state census data.
            Assert.AreEqual(37, totalRecord.Count);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file name which do not exist
        /// test case 2.2
        /// </summary>
        public void GivenWrongIndianCodeDataFile_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// test case 2.3
        /// </summary>
        public void GivenWrongIndianCodeDataType_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCodeText, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// test case 2.4
        /// </summary>
        public void GivenIncorrectDelimiterForCodeData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndiaStateCode, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect header is passed
        /// test case 2.5
        /// </summary>
        public void GivenIncorrectHeaderForCodeData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCode, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.etype);
        }
    }
}