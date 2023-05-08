using InvoiceManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Dtos.RoleGroupDtos
{
    public class RoleGroupListDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate  { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Status { get; set; }
       public List<object> PermissionNames { get; set; }
        public List<object> PermissionIds { get; set; }

        public List<object> PermissionIdAndName { get; set; }
    }
 
}
