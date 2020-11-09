using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer: IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
    }
}
