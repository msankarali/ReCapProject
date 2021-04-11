using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CreditCardController : Controller
    {
        private ICreditCardService _creditCardManager;
        public CreditCardController(ICreditCardService creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }
        [HttpPost("cardadd")]
        public IActionResult CreditCardAdd(CreditCard creditCard)
        {
            var result = _creditCardManager.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("cardDelete")]
        public IActionResult CreditCardDelete([FromForm] CreditCard creditCard)
        {
            var result = _creditCardManager.Delete(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("cardUpdate")]
        public IActionResult CreditCardUpdate([FromForm] CreditCard creditCard)
        {
            var result = _creditCardManager.Update(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcardall")]
        public IActionResult CreditCardAll()
        {
            var result = _creditCardManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcardbyid")]
        public IActionResult CreditCardById(int id)
        {
            var result = _creditCardManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getusercards")]
        public IActionResult CreditCardByUserId(int customerId)
        {
            var result = _creditCardManager.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
