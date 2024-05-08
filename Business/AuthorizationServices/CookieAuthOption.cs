using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AuthorizationServices
{
    public class CookieAuthOption
    {
        public string? Name { get; set; }

        public string? LoginPath { get; set; }

        public string? LogOutPath { get; set; }

        public string? AccessDeniedPath { get; set; }

        public bool SlidingExpiration { get; set; }

        public double TimeOut { get; set; }

    }
}
