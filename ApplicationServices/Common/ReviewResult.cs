using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using OneOf;

namespace ApplicationServices.Common
{
    public class Result<T> : OneOfBase<T, Error>
    {
        public Result(OneOf<T,Error> input) : base(input) {}

        // implicit conversions from T and Error to Result<T>
        public static implicit operator Result<T>(T ok) => new Result<T>(ok);
        public static implicit operator Result<T>(Error error) => new Result<T>(error);

        // checking and casting
        public bool IsOk => IsT0;
        public bool IsError => IsT1;
        public T AsOk => AsT0;
        public Error AsError => AsT1;
    }

    public readonly struct Error
    {
        public string Message { get; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
