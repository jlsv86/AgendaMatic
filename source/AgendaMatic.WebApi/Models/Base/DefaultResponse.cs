using System.Collections.Generic;

namespace AgendaMatic.WebApi.Models.Base
{
    public class DefaultResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<ErrorModel> Errors { get; set; }
    }
}
