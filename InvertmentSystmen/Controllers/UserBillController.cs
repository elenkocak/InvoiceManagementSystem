using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Entity.Dtos.UserBillDtos;
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
    public class UserBillController : ControllerBase
    {
        private readonly IUserBillService _userBillService;

        public UserBillController(IUserBillService userBillService)
        {
            _userBillService = userBillService;
        }

        //[HttpPost("add")]
        //public IActionResult Add(UserBillAddDto dto)
        //{
        //    var result = _userBillService.Add(dto);
        //    return Ok(result);
        //}

        //[HttpGet("getlist")]
        //public IActionResult Getlist()
        //{
        //    var result = _userBillService.GetList();
        //    return Ok(result);
        //}

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _userBillService.GetById(id);
        //    return Ok(result);
        //}

        //[HttpPost("update")]
        //public IActionResult Update(UserBillUpdateDto userBillUpdateDto)
        //{
        //    var result = _userBillService.Update(userBillUpdateDto);
        //    return Ok(result);
        //}

        //[HttpPost("delete")]
        //public IActionResult Delete(int id)
        //{
        //    var result = _userBillService.Delete(id);
        //    return Ok(result);
        //}
    }
}
