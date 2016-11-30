using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZL.Code
{
    public class Log
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void StartLog()
        {
            log4net.Config.DOMConfigurator.Configure();
        }

        /// <summary>错误日志
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <param name="exception">异常</param>
        public static void Error(string errorMsg, Exception exception)
        {
            log.Error(errorMsg, exception);
        }
    }
}
