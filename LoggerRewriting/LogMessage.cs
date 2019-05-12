using System;
using PostSharp.Aspects;

namespace LoggerRewriting
{
    public class LogMessage
    {
        public string Method { get; set; }
        public Arguments Params { get; set; }
        public DateTime CallTime { get; set; }
        public string Status { get; set; }
        public object ReturnValue { get; set; }
    }
}
