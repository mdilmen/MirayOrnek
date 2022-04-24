using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MirayOrnek.Dtos
{
    public class Response<T>
    {
        public T? Data { get; set; }

        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public static Response<T> Success(T data)
        {
            return new Response<T> { Data = data, IsSuccessful = true, Message = "İşlem Başarılı" };
        }

        public static Response<T> Success(T data, string message)
        {
            return new Response<T> { Data = data, IsSuccessful = true, Message = message };
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T> { IsSuccessful = false, Message = message };
        }

        public static Response<T> Fail(T data, string message)
        {
            return new Response<T> { Data = data, IsSuccessful = false, Message = message };
        }
    }
}
