using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactASPNetMVCDemo
{
    public class ContactUs : AuditableEntity, IContactUs
    {
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
