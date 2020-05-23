using System;

namespace AcademiaDemo.Domain.Entities
{
    public class Item
    {
        public Item(
            string description,
            decimal price
        )
        {
            Id = Guid.NewGuid();
            Description = description;
            Price = price;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; set; }
    }
}
