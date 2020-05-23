using System;

namespace AcademiaDemo.Domain.Entities
{
    public class Stock
    {
        public Stock(
            Guid itemId,
            int ammount
        )
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            Ammount = ammount;
        }

        public Guid Id { get; private set; }
        public Guid ItemId { get; private set; }
        public int Ammount { get; private set; }

        public void Withdraw()
        {
            if (Ammount <= 0)
                throw new Exception("Sem estoque");

            Ammount--;
        }
    }
}
