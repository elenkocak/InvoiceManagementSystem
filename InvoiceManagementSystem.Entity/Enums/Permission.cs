using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Enums
{
    public static class Permission
    {
        #region Users
        public static string per_adduser = "user_add";
        public static string per_getbyiduser = "user_get_by_id";
        #endregion

        #region Apartment
        public static string per_addapartment = "apartment_add";
        public static string per_delapartment = "apartment_delete";
        public static string per_get_by_id = "apartment_get_by_id";
        public static string per_update_apartment = "apartment_update";
        public static string per_getlist_apartment = "apartment_getlist";
        #endregion
    }
}
