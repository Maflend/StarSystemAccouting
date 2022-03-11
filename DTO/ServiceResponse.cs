using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.DTOs
{
    public class ServiceResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
