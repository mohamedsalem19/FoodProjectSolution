
using FoodProject.Models.Enums;

namespace FoodProject.ViewModels
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }

        public bool IsSucess { get; set; }

        public ErrorCode ErrorCode { get; set; }

        public string Message { get; set; }

    }


    public class SucessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SucessResponseViewModel(T data, string message = "")
        {
            Data = data;
            IsSucess = true;
            Message = message;
            ErrorCode = ErrorCode.None;

        }
    }

    public class FailureResponseViewModel<T> : ResponseViewModel<T>
    {
        public FailureResponseViewModel(ErrorCode errorCode, string message = "")
        {
            Data = default;
            IsSucess = false;
            Message = message;
            ErrorCode = errorCode;

        }
    }
}
