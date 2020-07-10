﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOS.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
