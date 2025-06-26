using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitClock.Common.Models
{
    public class Error
    {
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
    }
}
