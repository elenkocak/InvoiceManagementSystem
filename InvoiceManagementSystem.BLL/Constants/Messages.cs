using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.BLL.Constants
{
    public static class Messages
    {

        public static string err_null = "err_null"; //null değer
        public static string success = "operation_success"; // işlem başarılı
        public static string unknown_err = "unknown_err"; //bilinmeyen hata oluştu
        public static string data_not_found = "data_not_found"; //data bulunamadı

        public static string delete_operation_is_successfull = "delete_operation_is_successfull"; //silme işlemi başarılı

        public static string delete_operation_fail = "delete_operation_fail"; //silme işlemi başarısız
        public static string update_operation_fail = "update_operation_fail";

        public static string status_updated_already_paid = "status updated to already paid";
        public static string data_is_required = " data_is_required"; //girilen parametre null geldi fakat girilmesi zorunlu alan

        #region User
        public static string user_already_has_an_invoice = "user_already_has_in_invoice"; // işlem başarılı
        public static string user_not_active = "user_not_active"; // işlem başarılı
        public static string user_wrong_password = "user_wrong_password"; // şifre hatalı
        #endregion

        #region Auth Messages
        public static string already_mail_registered = "err_mail_already_registered";
        public static string invalid_email = "err_invalid_email";

        public static string user_not_found = "err_user_not_found";
        public static string already_phone_number_exists = "err_phone_number_already_exists";
        public static string invalid_phone_number = "err_phone_number_already_exists";

        #endregion

        #region Token
        public static string generate_token_failed = "err_generate_token_failed";

        #endregion
    }
}
