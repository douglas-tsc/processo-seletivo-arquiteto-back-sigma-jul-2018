using Sigma.PatrimonioApi.Exceptions;

namespace Sigma.PatrimonioApi
{
    public class ConstraintException : ApiException
    {
        public ConstraintException(string message)
            : base(message)
        {
        }

    }
}
