using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int FindeksId { get; set; }
        public int CustomerId { get; set; }
        public string IdentityNumber { get; set; }
        public short Score { get; set; }
    }
}
