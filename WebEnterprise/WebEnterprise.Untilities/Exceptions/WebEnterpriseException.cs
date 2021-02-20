using System;

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
