﻿using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Entity.Dtos.UserApartmentDtos;
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
    public class UserApartmentController : ControllerBase
    {
        private readonly IUserApartmentService _userApartmentService;

        public UserApartmentController(IUserApartmentService userApartmentService)
        {
            _userApartmentService = userApartmentService;
        }

        [HttpPost("adduserapartment")]
        public IActionResult Add(UserApartmentAddDto dto)
        {
            var result = _userApartmentService.Add(dto);
            return Ok(result);
        }
        [HttpPost("updateuseapartment")]
        public IActionResult Update(UserApartmentUpdateDto dto)
        {
            var result = _userApartmentService.Update(dto);
            return Ok(result);
        }

        [HttpGet("userapartmentlist")]
        public IActionResult GetList()
        {
            var result = _userApartmentService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userApartmentService.GetById(id);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _userApartmentService.Delete(id);
            return Ok(result);
        }

        [HttpPost("addmultiple")]
        public IActionResult AddMultiple(UserApartmentAddMultipleDto dto)
        {
            var result = _userApartmentService.AddMultiple(dto);
            return Ok(result);
        }
    }
}
