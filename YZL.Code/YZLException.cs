using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZL.Code
{
    public class YZLException : ApplicationException
    {

        public YZLException()
        {
            throw new Exception();
        }
        public YZLException(string msg)
            : base(msg)
        {
            
        }
        public YZLException(string msg, Exception ex)
            : base(msg, ex)
        {

        }
        
    }
}
