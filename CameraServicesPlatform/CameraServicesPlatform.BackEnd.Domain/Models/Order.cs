using CameraServicesPlatform.BackEnd.Domain.Enum;
using CameraServicesPlatform.BackEnd.Domain.Enum.Delivery;
using CameraServicesPlatform.BackEnd.Domain.Enum.Order;
using System.ComponentModel.DataAnnotations;

namespace CameraServicesPlatform.BackEnd.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }


        public Guid SupplierID { get; set; }


        public string Id { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double? TotalAmount { get; set; }
        public OrderType OrderType { get; set; }

        // Rental properties
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public RentalDurationUnit DurationUnit { get; set; }
        public int DurationValue { get; set; }
        public DateTime? ReturnDate { get; set; }

        public string? ShippingAddress { get; set; }
        public DeliveryStatus? DeliveriesMethod { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double? Deposit {  get; set; }
        public Supplier? Supplier { get; set; }
        public Account? Account { get; set; }

        public Guid? OrderDetailID { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetail { get; set; }

        public Transaction? Transaction { get; set; }
        public Payment? Payment { get; set; }

        public bool? IsExtend { get; set; }
        public bool? IsPayment { get; set; }
        // Tiền giữ chỗ
        public double? ReservationMoney { get; set; }   

    }
}
