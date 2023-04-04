using Autofac;
using AutoMapper;
using InvoiceManagementSystem.BLL.Abstract;
using InvoiceManagementSystem.BLL.Concrete;
using InvoiceManagementSystem.DAL.Abstract;
using InvoiceManagementSystem.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace InvoiceManagementSystem.BLL.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<ApartmentManager>().As<IApartmentService>();
            builder.RegisterType<EfApartmentDal>().As<IApartmentDal>();

            builder.RegisterType<UserApartmentManager>().As<IUserApartmentService>();
            builder.RegisterType<EfUserApartmentDal>().As<IUserApartmentDal>();

            builder.RegisterType<BillManager>().As<IBillService>();
            builder.RegisterType<EfBillDal>().As<IBillDal>();

            builder.RegisterType<UserBillManager>().As<IUserBillService>();
            builder.RegisterType<EfUserBillDal>().As<IUserBillDal>();

            builder.RegisterType<EfBillTypesDal>().As<IBillTypesDal>();
          
        }
    }
}
