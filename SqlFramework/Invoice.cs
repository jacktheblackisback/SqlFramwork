using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFramework
{
    public class Invoice : MainObject
    {
        public int InvoiceId { get; set; }
        public int SupplierId { get; set; }
        public int PaymentMethodId { get; set; }
        public int PackageStatusId { get; set; }
        public int OrderNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public string TrackingNumber { get; set; } = "";
        public int? MonthReceivedId { get; set; }
    }

    public class InvoiceTotals : MainObject
    {
        public decimal InvoiceTotal { get; set; }
    }
}