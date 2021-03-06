﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomers();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAllCustomersWithDetails")]
        public IActionResult GetAllCustomersWithDetails()
        {
            var result = _customerService.GetAllCustomersWithDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}