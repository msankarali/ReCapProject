﻿using Core.CrossCuttingConcerns.Attributes;
using Core.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        //[SwaggerIgnore]
        [JsonIgnore]
        public List<Car> Cars { get; set; }
    }
}