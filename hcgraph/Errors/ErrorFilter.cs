
namespace hcgraph.Errors
{
    public class ErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Exception?.Message ?? "");
        }
    }
}