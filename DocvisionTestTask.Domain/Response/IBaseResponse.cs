
namespace DocvisionTestTask.Domain.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode statusCode { get; }
        T Data { get; }
    }
}
