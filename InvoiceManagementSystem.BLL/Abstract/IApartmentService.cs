using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Entity.Dtos;
using InvoiceManagementSystem.Entity.Dtos.ApartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Abstract
{
    public interface IApartmentService
    {
        IDataResult<object> Add(AddMultipleApartmentDto addMultipleApartmentDto);
        IDataResult<ApartmentUpdateDto> Update(ApartmentUpdateDto apartmentUpdateDto);
        IDataResult<bool> Delete(int id);
        IDataResult<List<ApartmentListDto>> GetList();
        IDataResult<ApartmentListDto> GetById(int id);

    }
}
