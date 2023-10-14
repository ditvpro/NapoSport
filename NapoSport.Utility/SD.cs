using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Utility
{
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_Employee = "Employee";
        public const string Role_Admin = "Admin";

        public const string StatusPending = "Chưa xử lý";
        public const string StatusApproved = "Đã duyệt";
        public const string StatusInProcess = "Đang xử lý";
        public const string StatusShipped = "Đã giao hàng";
        public const string StatusCancelled = "Đã hủy";
        public const string StatusRefunded = "Đã hoàn tiền";

        public const string PaymentStatusPending = "Chưa thanh toán";
        public const string PaymentStatusApproved = "Đã thanh toán";
        public const string PaymentStatusDelayedPayment = "Thanh toán sau";
        public const string PaymentStatusRejected = "Không thanh toán";

        public const string SessionCart = "SessionShoppingCart";
    }
}
