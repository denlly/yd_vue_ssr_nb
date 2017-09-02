using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
    }
}
