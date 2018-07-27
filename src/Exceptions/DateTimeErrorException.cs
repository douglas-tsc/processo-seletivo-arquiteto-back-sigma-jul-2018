using Sigma.PatrimonioApi.Exceptions;

namespace Sigma.PatrimonioApi
{
    public class DateTimeErrorException : ApiException
    {
        public DateTimeErrorException(string message)
            : base(message)
        {
        }

    }
}
