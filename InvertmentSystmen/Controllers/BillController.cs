using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Entity.Dtos.BillDtos;
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
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _billService.GetList();
            return Ok(result);
        }

        [HttpPost("updateisbillPaymentStatus")]
        public IActionResult UpdateBillPaymentStaus(int id)
        {
            var result = _billService.UpdateIsBillPaymentStatus(id);
            return Ok(result);
        }

        [HttpGet("getbyid")]                          
        public IActionResult GetById(int id)
        {
            var result = _billService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddMultipleBillDto dto)
        {
            var result = _billService.Add(dto);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UpdateBillDto dto)
        {
            var result = _billService.Update(dto);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _billService.UpdateIsBillPaymentStatus(id);
            return Ok(result);
        }
    }
}
