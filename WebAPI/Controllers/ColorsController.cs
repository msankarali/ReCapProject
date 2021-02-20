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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAllColors")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAllColors();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("DeleteById")]
        public IActionResult DeleteById(int colorId)
        {
            var result = _colorService.DeleteById(colorId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
