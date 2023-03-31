using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.BLL.Constants;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.Entity.Concrete;
using InvoiceManagementSystem.Entity.Dtos;
using InvoiceManagementSystem.Entity.Dtos.ApartmentDtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentDal _apartmentDal;

        public ApartmentManager(IApartmentDal apartmentDal)
        {
            _apartmentDal = apartmentDal;
        }

        public IDataResult<object> Add(AddMultipleApartmentDto addMultipleApartmentDto)
        {
            try
            {
                if (addMultipleApartmentDto==null)
                {
                    return new ErrorDataResult<object>(null, "Alanlar boş geçilemez", Messages.err_null);
                }
                foreach (var item in addMultipleApartmentDto.Apartments)
                {
                    _apartmentDal.Add(new Apartment
                    {
                        WhichBlock = item.WhichBlock,
                        ApartmentNo = item.ApartmentNo,
                        FloorNumber = item.FloorNumber,
                        ApartmentSize = item.ApartmentSize,
                        ApartmentState=item.ApartmentState,
                        Status=item.Status
                    });
                }
                var count = addMultipleApartmentDto.Apartments.Count();
                return new SuccessDataResult<object>("Ok", $"{count} tane daire kaydı oluştu.", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<object>(null,e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<bool> Delete(int id)
        {
            try
            {
                if (id!= null)
                {
                    var result = _apartmentDal.Get(x => x.Id == id);
                    _apartmentDal.Delete(result);
                    return new SuccessDataResult<bool>(true, "kayıt silindi", Messages.success);

                }
                return new ErrorDataResult<bool>(false, "Alan boş geçilemez", Messages.err_null);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<bool>(false, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<ApartmentListDto> GetById(int id)
        {
            try
            {
                var apartment = _apartmentDal.Get(x => x.Id == id);
                var apartmentDto=new ApartmentListDto()
                {
                    WhichBlock = apartment.WhichBlock,
                    ApartmentNo = apartment.Id,
                    FloorNumber = apartment.FloorNumber,
                    ApartmentSize = apartment.ApartmentSize,
                    ApartmentState = apartment.ApartmentState,
                    Status = apartment.Status,
                  
                };
                
                return new SuccessDataResult<ApartmentListDto>(apartmentDto, "Ok", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<ApartmentListDto>(new ApartmentListDto(), e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<List<ApartmentListDto>> GetList()
        {
            try
            {
               var apartments=_apartmentDal.GetList();
                var apartmentsDto = new List<ApartmentListDto>();

                foreach (var apartment in apartments)
                {
                    apartmentsDto.Add(new ApartmentListDto
                    {
                        WhichBlock = apartment.WhichBlock,
                        ApartmentNo = apartment.ApartmentNo,
                        FloorNumber = apartment.FloorNumber,
                        ApartmentSize = apartment.ApartmentSize,
                        ApartmentState=apartment.ApartmentState,
                        Status=apartment.Status,

                    });
                }
                return new SuccessDataResult<List<ApartmentListDto>>(apartmentsDto, "Ok", Messages.success);
             
            }
            catch (Exception E)
            {

                return new ErrorDataResult<List<ApartmentListDto>>(new List<ApartmentListDto>(), E.Message, Messages.unknown_err);
            }
        }

        public IDataResult<bool> Update(ApartmentUpdateDto apartmentUpdateDto)
        {
            try
            {
                if (apartmentUpdateDto != null)
                {
                    var apartment = _apartmentDal.Get(x => x.Id == apartmentUpdateDto.Id);

                }
                return new ErrorDataResult<bool>(false, "Err", Messages.err_null);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
