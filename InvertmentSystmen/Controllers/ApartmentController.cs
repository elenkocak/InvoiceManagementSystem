using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Entity.Dtos.ApartmentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost("addapartment")]
        public IActionResult Add(AddMultipleApartmentDto dto)
        {
            var result = _apartmentService.Add(dto);
            return Ok(result);
        }

        [HttpPost("deleteapartment")]
        public IActionResult Delete(int id, string token)
        {
            var result = _apartmentService.Delete(id, token);
            return Ok(result);
        }

        [HttpPost("updateapartment")]
        public IActionResult Update(ApartmentUpdateDto apartmentUpdate)
        {
            var result = _apartmentService.Update(apartmentUpdate);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _apartmentService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _apartmentService.GetList();
            return Ok(result);
        }
    }
}
