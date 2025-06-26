using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GitClock.Common.Models
{
    public class ErrorResponse
    {
        public string Instance { get; set; }
        public List<Error>? Errors { get; set; }
    }
}
