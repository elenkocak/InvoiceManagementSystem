using InvoiceManagementSystem.BLL.Constants;
using InvoiceManagementSystem.Core.Entities.Concrete;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Entity.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Abstract
{
    public interface IUserService
    {
        IDataResult<UserAddMultipleDto> Add(UserAddMultipleDto userAddDto);
        IDataResult<UserUpdateDto> Update(UserUpdateDto userUpdateDto);
        IDataResult<List<UserListDto>> GetList();
        IDataResult<UserListDto> GetById(int id);
        IDataResult<User> Delete(int id);
        IDataResult<User> MakePassiveUser(int id);
       
    }
}
