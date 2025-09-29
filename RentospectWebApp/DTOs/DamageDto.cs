using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectWebApp.DTOs
{
    public class DamageDto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string ExampleOnePhoto { get; set; }
        public string ExampleTwoPhoto { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
