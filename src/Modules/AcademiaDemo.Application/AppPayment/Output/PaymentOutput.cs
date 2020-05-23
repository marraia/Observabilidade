using System;

namespace AcademiaDemo.Application.AppPayment.Output
{
    public class PaymentOutput
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public int SubDivision { get; set; }
        public decimal Total { get; set; }
        public decimal TotalSubDivision { get; set; }
    }
}
