﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contexts;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.Create(model);
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _customerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerService.Get(id);
            if (result != null)
                return new OkObjectResult(result);

            return new NotFoundResult();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(CustomerModel cm)
        {
            var result = await _customerService.Update(cm);
            if (result != null)
                return new OkResult();
            return new NotFoundResult();

        }
    }
}
