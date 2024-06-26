﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CommonEntities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? FName { get; set; }

        public string? LName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
