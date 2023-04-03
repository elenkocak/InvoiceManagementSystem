﻿using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.BLL.Constants;
using InvoiceManagementSystem.Core.Entities.Concrete;
using InvoiceManagementSystem.Core.Result;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.Entity.Concrete;
using InvoiceManagementSystem.Entity.Dtos.UserBillDtos;
using InvoiceManagementSystem.Entity.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Concrete
{
    public class UserBillManager : IUserBillService
    {
        private readonly IUserBillDal _userBillDal;
        private readonly IUserService _userService;
        private readonly IBillService _billService;
        public UserBillManager(IUserBillDal userBill, IUserService userService, IBillService billService)
        {
            _userBillDal = userBill;
            _userService = userService;
            _billService = billService;
        }

        public IDataResult<UserBillAddDto> Add(UserBillAddDto userBillAdd)
        {
            try
            {
                var usersBills = new UserBill();
                if (userBillAdd == null)
                {
                    return new ErrorDataResult<UserBillAddDto>(null, "Fatura-Kullanıcı atama işlemi için alanları doldurunuz !", Messages.err_null);
                }
                usersBills.BillId = userBillAdd.BillId;
                usersBills.UserId = userBillAdd.UserId;
                usersBills.Status = true;
                return new SuccessDataResult<UserBillAddDto>(userBillAdd, "Ekleme işlemi başarılı", Messages.success);

            }
            catch (Exception e)
            {
                return new ErrorDataResult<UserBillAddDto>(null, e.Message, Messages.unknown_err);
            }
        }


        public IDataResult<UserBillMultipleAddDto>AddMultiple(UserBillMultipleAddDto userBillMultipleAdd)
        {
            if (userBillMultipleAdd==null)
            {
                return new ErrorDataResult<UserBillMultipleAddDto>(null, "Alanlar boş geçilemez", Messages.err_null);
            }
            var userBill = new List<UserBill>();

            foreach (var item in userBillMultipleAdd.UserBillsAddDtos)
            {
                _userBillDal.Add(new UserBill
                {
                    BillId= item.BillId,
                    UserId=item.UserId,
                    Status=true
                });
            }
            var count = userBillMultipleAdd.UserBillsAddDtos.Count();
            return new SuccessDataResult<UserBillMultipleAddDto>(userBill, $"{count} tane kayıt başarıyla eklendi", Messages.success);
        }

        public IDataResult<UserBill> Delete(int id)
        {
            try
            {
                var result = _userBillDal.Get(x => x.Id == id);
                if (result != null)
                {
                    _userBillDal.Delete(result);
                    return new SuccessDataResult<UserBill>(result, "Kayıt başarıyla silindi", Messages.success);
                }
                return new ErrorDataResult<UserBill>(null, "Böyle bir kayıt bulunamadı", Messages.data_not_found);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<UserBill>(null, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<UserBill> DeletebyPassive(int id)
        {
            try
            {
                var result = _userBillDal.Get(x => x.Id == id);
                if (result != null)
                {
                    result.Status = false;
                    _userBillDal.Update(result);
                    return new SuccessDataResult<UserBill>(result, "Kayıt başarıyla silindi", Messages.success);
                }
                return new ErrorDataResult<UserBill>(null, "Kayıt bulunamadı", Messages.data_not_found);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<UserBill>(null, e.Message, Messages.unknown_err);

            }
        }

        public IDataResult<List<UserBillListDto>> GetActiveBills() //ÖDENMEMİŞ FATURALAR
        {
            try
            {
                var usersBills = _userBillDal.GetList().Where(x=>x.Status==true);
                var userBillDto = new List<UserBillListDto>();

                foreach (var userBill in usersBills)
                {
                    userBillDto.Add(new UserBillListDto
                    {
                        Id = userBill.Id,
                        BillId = userBill.BillId,
                        Status = userBill.Status,
                        UserId = userBill.UserId,
                    });

                }
                return new SuccessDataResult<List<UserBillListDto>>(userBillDto, "Ok", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<UserBillListDto>>(new List<UserBillListDto>(), e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<UserBillListDto> GetById(int id)
        {
            try
            {
                var result = _userBillDal.Get(x => x.Id == id);
                if (result == null)
                {
                    return new ErrorDataResult<UserBillListDto>(null, "Data is not found", Messages.data_not_found);
                }
                var userBillDto = new UserBillListDto()
                {
                    BillId = result.BillId,
                    Status = result.Status,
                    Id = result.Id,
                    UserId = result.UserId,
                };
                return new SuccessDataResult<UserBillListDto>(userBillDto, "OK", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<UserBillListDto>(null, e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<UserBillListDto>> GetList()
        {
            try
            {
                var userBills = _userBillDal.GetList();
                var userBillDto = new List<UserBillListDto>();

                foreach (var userBill in userBills)
                {
                    userBillDto.Add(new UserBillListDto
                    {
                        Id = userBill.Id,
                        BillId = userBill.BillId,
                        UserId = userBill.UserId,
                        Status = userBill.Status
                    });
                }
                return new SuccessDataResult<List<UserBillListDto>>(userBillDto, "OK", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<UserBillListDto>>(new List<UserBillListDto>(), e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<List<UserBillListDto>> GetPassiveBills() //ÖDENMİŞ FATURALAR-
        {
            try
            {
                var userBills = _userBillDal.GetList().Where(x => x.Status == false);
                var userBillDto = new List<UserBillListDto>();

                foreach (var userBill in userBills)
                {

                    userBillDto.Add(new UserBillListDto
                    {
                        Id = userBill.Id,
                        BillId = userBill.BillId,
                        Status = userBill.Status,
                        UserId = userBill.UserId
                    });

                }
                return new SuccessDataResult<List<UserBillListDto>>(userBillDto, "OK", Messages.success);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<UserBillListDto>>(new List<UserBillListDto>(), e.Message, Messages.unknown_err);
            }
        }

        public IDataResult<UserBillUpdateDto> Update(UserBillUpdateDto userUpdateDto)
        {
            try
            {
                var result = _userBillDal.Get(x => x.Id == userUpdateDto.Id);
                if (result==null)
                {
                    return new ErrorDataResult<UserBillUpdateDto>(null, "Data is not found", Messages.data_not_found);
                }

                result.UserId=userUpdateDto.UserId;
                result.BillId = userUpdateDto.BillId;
                result.Id = userUpdateDto.Id;
                result.Status = userUpdateDto.Status;

                return new SuccessDataResult<UserBillUpdateDto>(userUpdateDto, "OK", Messages.success);
            }
            catch (Exception E)
            {

                return new ErrorDataResult<UserBillUpdateDto>(null, E.Message, Messages.unknown_err);

            }
        }
    }
}
