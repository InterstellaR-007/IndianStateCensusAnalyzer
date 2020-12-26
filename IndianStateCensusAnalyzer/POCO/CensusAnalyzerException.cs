using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyzer.POCO
{
    public class CensusAnalyzerException:Exception
    {
        /// <summary>
        /// Enum for Exception types
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_DELIMITER,INCORRECT_HEADER,NO_SUCH_ARRAY,NO_SUCH_COUNTRY
        }
        public ExceptionType eType;
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyzerException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        public CensusAnalyzerException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }

    }
}
