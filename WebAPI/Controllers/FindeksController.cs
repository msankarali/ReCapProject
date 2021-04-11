using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class FindeksController : Controller
    {
        IFindeksService _findexService;

        public FindeksController(IFindeksService findexService)
        {
            _findexService = findexService;
        }

        [HttpPost("add")]
        public IActionResult Add(Findeks findeks)
        {
            var result = _findexService.Add(findeks);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Findeks findeks)
        {
            var result = _findexService.Update(findeks);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Findeks findeks)
        {
            var result = _findexService.Delete(findeks);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _findexService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserfindex")]
        public IActionResult GetUserFindeks()
        {
            var result = _findexService.GetUserFindeks();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindex")]
        public IActionResult GetCarFindeks()
        {
            var result = _findexService.GetCarFindeks();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findexService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
