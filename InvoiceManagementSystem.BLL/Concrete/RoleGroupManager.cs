using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.Entity.Concrete;
using InvoiceManagementSystem.Entity.Dtos.RoleGroupDtos;
using InvoiceManagementSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class RoleGroupManager : IRoleGroupService
    {
        private readonly IRoleGroupDal _roleGroupDal;
        private readonly IRoleGroupPermissionsDal _roleGroupPermissions;
        private readonly ISessionService _sessionService;
        private readonly IPermissionsDal _permissionDal;
        public RoleGroupManager(IRoleGroupDal roleGroupDal, IRoleGroupPermissionsDal roleGroupPermissions, IPermissionsDal permissionDal, ISessionService sessionService)
        {
            _roleGroupDal = roleGroupDal;
            _roleGroupPermissions = roleGroupPermissions;
            _permissionDal = permissionDal;
            _sessionService = sessionService;
        }

        public IDataResult<List<RoleGroupListDto>> GetList(string token)
        {
            try
            {
                var tokenCheck = _sessionService.TokenCheck(token);
                if (token==null)
                {
                    return new ErrorDataResult<List<RoleGroupListDto>>(new List<RoleGroupListDto>(), tokenCheck.Message, tokenCheck.MessageCode);
                }
                var roleGroups = _roleGroupDal.GetList();

                var roleGroupListDto = new List<RoleGroupListDto>();
                foreach (var roleGroup in roleGroups)
                {
                    var roleGroupPermissions = _roleGroupPermissions.GetList(x => x.RoleGroupId == roleGroup.Id);

                    foreach (var item in roleGroupPermissions)
                    {
                        var permissionName = _permissionDal.Get(x => x.Id == item.PermissionId);
                    }
                    var permissionIds = new List<object>();
                    var permissionNames = new List<object>();
                    foreach (var roleGroupPermission in roleGroupPermissions)
                    {
                        permissionIds.Add(roleGroupPermission.PermissionId);
                        var permissionName = _permissionDal.Get(x => x.Id == roleGroupPermission.PermissionId).Name;
                        permissionNames.Add(permissionName);
                    }
                    var test=new List<object>();
                    permissionIds.AddRange(permissionNames);

                    var roleGroupLists = new RoleGroupListDto
                    {
                        Id = roleGroup.Id,
                        Name = roleGroup.Name,
                        Status = roleGroup.Status,
                        CreatedDate = roleGroup.CreatedDate,
                        ExpireDate = roleGroup.ExpireDate,
                        ModifiedDate = roleGroup.ModifiedDate,
                        //PermissionIds = permissionIds,
                        //PermissionNames = permissionNames,
                       PermissionIdAndName=permissionIds 
                    };
                    roleGroupListDto.Add(roleGroupLists);
                }
                return new SuccessDataResult<List<RoleGroupListDto>>(roleGroupListDto);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
