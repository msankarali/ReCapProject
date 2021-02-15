using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var result = _brandService.DeleteById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetByBrandName(string brandName)
        {
            var result = _brandService.GetByBrandName(brandName);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetBrand()
        {
            var result = _brandService.GetBrand();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
