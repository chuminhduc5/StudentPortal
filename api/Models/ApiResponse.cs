using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int HttpStatusCode { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; } = default!;
        public int TotalCount { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}