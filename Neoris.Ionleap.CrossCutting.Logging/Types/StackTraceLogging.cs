using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Neoris.Ionleap.CrossCutting.Logging.Types
{
    public class StackTraceLogging
    {
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public ExceptionLog Exception { get; set; }
        [DataMember]
        public List<InnerExceptionLog> InnerExceptions { get; set; }
    }
    
    public class InnerExceptionLog : ExceptionLog
    {

    }

    public class ExceptionLog
    {
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Stack { get; set; }
        [DataMember]
        public string FullStack { get; set; }
        [DataMember]
        public string Data { get; set; }
    }
}
