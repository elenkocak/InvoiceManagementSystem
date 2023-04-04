using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.Entity.Concrete;
using InvoiceManagementSystem.Entity.Dtos.UserApartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class UserApartmentManager : IUserApartmentService
    {
        private readonly IUserApartmentDal _userApartmentDal;
        private readonly IUserService _userService;
        private readonly IApartmentService _ApartmentService;
        public UserApartmentManager(IUserApartmentDal userApartmentDal, IUserService userService, IApartmentService apartmentService)
        {
            _userApartmentDal = userApartmentDal;
            _userService = userService;
            _ApartmentService = apartmentService;

        }

       
        

    }
}
