﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApiService.Dtos
{
    public class OrderDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string CustomerFullName { get; set; }
    }
}
