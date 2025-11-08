using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public string PublicId { get; set; } = "";
        public string CreatedAt { get; set; } = "";
    }
}