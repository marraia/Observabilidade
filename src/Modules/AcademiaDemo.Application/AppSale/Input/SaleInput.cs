using AcademiaDemo.Application.AppPayment.Input;
using System;
using System.Collections.Generic;

namespace AcademiaDemo.Application.AppSale.Input
{
    public class SaleInput
    {
        public List<Guid> Itens { get; set; }
        public PaymentInput Payment { get; set; }
    }
}
