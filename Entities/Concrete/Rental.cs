﻿using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } //INFO: Navigation propertyler sorguya dahil olur!
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Customer Customer { get; set; }
    }
}