using AdvanceDotNetBatch1.Utlis.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceDotNetBatch1.Utlis
{
    public class Result<T>
    {
        public T Data { get; set; }
        public EnumHttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public static Result<T> Success(string message = "Success")
        {
            return new Result<T>
            {
                Message = message,
                IsSuccess = true,
                StatusCode = EnumHttpStatusCode.Success,
            };
        }

        public static Result<T> Success(T data, string message = "Success")
        {
            return new Result<T>
            {
                Data = data,
                Message = message,
                IsSuccess = true,
                StatusCode = EnumHttpStatusCode.Success,
            };
        }

        public static Result<T> Fail(
            string message = "Fail.",
            EnumHttpStatusCode statusCode = EnumHttpStatusCode.BadRequest
        )
        {
            return new Result<T>
            {
                IsSuccess = false,
                Message = message,
                StatusCode = statusCode,
            };
        }

        public static Result<T> Fail(Exception ex)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Message = ex.ToString(),
                StatusCode = EnumHttpStatusCode.InternalServerError,
            };
        }
    }
    }
