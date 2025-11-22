using MediatR;

namespace ServiceHub.Api.Domain.Common;

public class Result : IRequest
{
    public bool Success { get; set; }
    
    public Error Error { get; set; }

    public Result(bool success, Error error)
    {
        Success = success;
        Error = error;
    }


    public static Result Ok()
    {
        return new Result(true, default);
    }

    public static Result Fail(string  code, string message)
    {
        return new Result(false, new Error(code, message));
    }

    public static Result<T> Ok<T>(T data)
    {
        return new Result<T>(true, data, default);
    }

    public static Result<T> Fail<T>(string  code, string message)
    {
        return new Result<T>(false, default, new Error(code, message));
    }
}

public class Result<T> : Result
{
    
    public T Data { get; set; }
    
    public Result(bool success, T data,  Error error) : base(success, error)
    {
        Data = data;
    }
    
}