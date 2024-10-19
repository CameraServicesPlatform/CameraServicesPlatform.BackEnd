using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraServicesPlatform.BackEnd.Application.IService
{
    public interface IPaymentService
    {
        Task<IActionResult> VNPayReturnAsync(string vnp_TxnRef, string vnp_TransactionStatus);
    }
}
