using InvoiceManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Entity.Dtos.ConnectionDtos
{
    public class MongoDbConnectionDto:IDto
    {
        public string MongoConnectionString = "mongodb://localhost:27017";
        public string LogDb = "InvoiceManagementSystem-db";
        public string LogDbCollection = "LogRecords";
    }
}
