namespace CameraServicesPlatform.BackEnd.Common.DTO.Payment.PaymentRespone
{
    public class VNPayResponseDto
    {
        public string OrderDescription { get; set; }
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
        public string Amount { get; set; }
        public string PayDate { get; set; }
    }
}