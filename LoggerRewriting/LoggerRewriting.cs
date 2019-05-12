using System;
using System.Collections.Generic;
using System.Linq;
using PostSharp.Aspects;

namespace LoggerRewriting
{
    [Serializable]
    public class LoggerRewriting : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var logger = Logger.Logger.Current;
            var logMsg = new LogMessage
            {
                Status = "OnEntry",
                Method = args.Method.Name,
                Params = args.Arguments,
                CallTime = DateTime.Now
            };

            logger.Info(ConvertToJson(logMsg));
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var logger = Logger.Logger.Current;
            var logExitMsg = new LogMessage
            {
                Status = "OnExit",
                Method = args.Method.Name,
                Params = args.Arguments,
                ReturnValue = args.ReturnValue,
                CallTime = DateTime.Now
            };

            logger.Info(ConvertToJson(logExitMsg));
        }


        private static string ConvertToJson(LogMessage msg)
        {
            var list = new List<string>
            {
                $"Status: {msg.Status}",
                $"Method: {msg.Method}",
                $"CallTime: {msg.CallTime}"
            };

            list.AddRange(
                msg.Params
                    .Select(p => $" Param: {JsonSerializer.Serialize(p)}"));

            string returnValue = string.Join(", ", list.ToArray());
            if (msg.ReturnValue != null)
            {
                var retValue = $" ReturnValue: {JsonSerializer.Serialize(msg.ReturnValue)}";
                returnValue = string.Concat(returnValue, retValue);
            }

            return returnValue;
        }
    }
}
