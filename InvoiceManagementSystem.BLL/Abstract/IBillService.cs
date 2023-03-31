using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.Entity.Dtos.BillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Abstract
{
    public interface IBillService
    {
        IDataResult<object> Add(AddMultipleBillDto addMultipleBillDto);
        IDataResult<bool> Update(UpdateBillDto updateBillDto);
        IDataResult<bool> UpdateIsBillPaymentStatus(int id);
        IDataResult<List<ListBillDto>> GetList();
        IDataResult<ListBillDto> GetById(int id);
        IDataResult<bool>Delete(int id);

    }
}
