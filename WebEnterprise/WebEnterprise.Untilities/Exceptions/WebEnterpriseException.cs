using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Untilities.Exceptions
{
    public class WebEnterpriseException : Exception
    {
        public WebEnterpriseException()
        {

        }
        public WebEnterpriseException(string message)
        {

        }
        public WebEnterpriseException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
