using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.Entity.Concrete;
using InvoiceManagementSystem.Entity.Dtos.UserBillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class UserBillManager : IUserBillService
    {
        private readonly IUserBillDal _userBill;

        public UserBillManager(IUserBillDal userBill)
        {
            _userBill = userBill;
        }

   
    }
}
