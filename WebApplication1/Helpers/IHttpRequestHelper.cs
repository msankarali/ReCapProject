﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public interface IHttpRequestHelper
    {
        Task<ViewDataResult<T>> SendRequest<T>(string url);
    }
}
