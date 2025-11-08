using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class Rule
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; } = ""; // eg: High Value Transaction, New Device + Large Transfer
        public string Field { get; set; } = ""; //eg: Device, Location
        public string Condition { get; set; } = ""; // eg:  GreaterThan
        public string Value { get; set; } = ""; // eg: 500000
        public int Severity { get; set; }
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString();
    }
}