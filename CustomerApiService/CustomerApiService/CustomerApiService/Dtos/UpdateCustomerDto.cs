﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApiService.Dtos
{
    public class UpdateCustomerDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
    }
}
