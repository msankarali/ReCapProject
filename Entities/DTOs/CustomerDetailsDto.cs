using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDetailsDto
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
