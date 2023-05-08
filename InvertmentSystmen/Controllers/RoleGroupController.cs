using InvoiceManagementSystem.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleGroupController : ControllerBase
    {
        private readonly IRoleGroupService _roleGroupService;

        public RoleGroupController(IRoleGroupService roleGroupService)
        {
            _roleGroupService = roleGroupService;
        }

        [HttpPost("getlist")]
        public IActionResult GetList()
        {
            var result=_roleGroupService.GetList();
            return Ok(result);
        }
    }
}
