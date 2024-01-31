using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        internal Result(bool succeeded, object data, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Data = data;
        }

        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, new string[] { });
        }

        public static Result Success(object data)
        {
            return new Result(true, data, new string[] { });
        }


        public static Result Failure(params string[] errors)
        {
            return new Result(false, errors);
        }
    }

    public class Result<T>
    {
        private Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        private Result(bool succeeded, T data, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Data = data;
        }

        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string[] Errors { get; set; }

        public static Result<T> Success()
        {
            return new Result<T>(true, Array.Empty<string>());
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, Array.Empty<string>());
        }

        public static Result<T> Success(T data, IEnumerable<string> errors)
        {
            return new Result<T>(true, data, errors);
        }

        public static Result<T> Failure(params string[] errors)
        {
            return new Result<T>(false, errors);
        }
    }

}
