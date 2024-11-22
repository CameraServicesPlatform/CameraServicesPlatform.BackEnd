using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class HistoryTransactionResponse
    {
        public string HistoryTransactionId { get; set; }
        public string AccountID { get; set; }
        public string? StaffID { get; set; }
        public double Price { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
