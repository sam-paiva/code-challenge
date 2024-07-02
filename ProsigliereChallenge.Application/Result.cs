using ProsigliereChallenge.Core.Models;

namespace ProsigliereChallenge.Application;

public class Result
{
    private Result(bool success, Error error)
    {
        if ((success && error != Error.None) || (!success && error == Error.None))
            throw new ArgumentException("Invalid Error", nameof(error));

        IsSuccess = success;
        Error = error;
    }


    public bool IsSuccess { get; }
    public Error Error { get; }

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }
}

public class Result<T>
{
    private Result(bool success, T data, Error error)
    {
        if ((success && error != Error.None) || (!success && error == Error.None))
            throw new ArgumentException("Invalid Error", nameof(error));

        Data = data;
        IsSuccess = success;
        Error = error;
    }


    public bool IsSuccess { get; }
    public T Data { get; }
    public Error Error { get; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, Error.None);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(false, default, error);
    }
}