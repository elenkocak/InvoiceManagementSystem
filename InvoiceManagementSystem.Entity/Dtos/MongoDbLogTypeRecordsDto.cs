using InvoiceManagementSystem.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Dtos
{
    public class MongoDbLogTypeRecordsDto:IDto
    {
        public int LogType { get; set; }
        //public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
