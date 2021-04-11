using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public short ExpirationMonth { get; set; }
        public short ExpirationYear { get; set; }
        public int Cvc { get; set; }
    }
}
