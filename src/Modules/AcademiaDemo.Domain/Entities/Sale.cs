using System;
using System.Collections.Generic;

namespace AcademiaDemo.Domain.Entities
{
    public class Sale
    {
        public Sale(Payment payment)
        {
            Id = Guid.NewGuid();
            Payment = payment;
        }

        public Guid Id { get; private set; }
        public List<Item> Itens { get; private set; } = new List<Item>();
        public Payment Payment { get; private set; }

        public void AddItems(List<Item> items)
        {
            Itens = items;
        }
    }
}
