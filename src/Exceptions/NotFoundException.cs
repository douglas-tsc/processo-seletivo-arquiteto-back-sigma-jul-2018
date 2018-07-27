using Sigma.PatrimonioApi.Exceptions;

namespace Sigma.PatrimonioApi
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }

    }
}
