namespace CameraServicesPlatform.BackEnd.Common.DTO.Payment.PaymentRequest
{
    public class PaymentInformationRequest
    {
        public string OrderInfo { get; set; }
        public string AccountID { get; set; }

        public string CustomerName { get; set; }
        public double Amount { get; set; }
    }
}