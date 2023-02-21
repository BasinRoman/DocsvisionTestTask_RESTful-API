
namespace DocvisionTestTask.Domain.Response
{
    // Класс для формирования BaseResponse, внутренний махизм валидации состояние бизнес-процесса.
    // Description коллектор для формирования лога бизнес-процесса.
    // Data - возвращаемые данные.
    // StatusCode - состояние бизнес-процесса .
    //      ok - обработка успешна.
    //      internalServiceError - ошибка обработки запроса.

    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode statusCode { get; set; }
        public T Data { get; set; }
    }
}
