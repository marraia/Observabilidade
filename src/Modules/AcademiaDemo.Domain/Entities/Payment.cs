using System;

namespace AcademiaDemo.Domain.Entities
{
    public class Payment
    {
        public Payment(
            string cardNumber,
            int subDivision,
            decimal total
        )
        {
            Id = Guid.NewGuid();
            CardNumber = cardNumber;
            SubDivision = subDivision;
            Total = total;
        }

        public Payment(
            Guid id,
            string cardNumber,
            int subDivision,
            decimal total,
            decimal totalSubDivision
        )
        {
            Id = id;
            CardNumber = cardNumber;
            SubDivision = subDivision;
            Total = total;
            TotalSubDivision = totalSubDivision;
        }

        public Guid Id { get; private set; }
        public string CardNumber { get; private set; }
        public int SubDivision { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalSubDivision { get; private set; }

        public bool ValidateCreditCard()
        {
            var valid = true;

            if (CardNumber == "1234567890123456" 
                    || CardNumber.Length < 16)
                valid = false;

            return valid;
        }

        public void CalculatedSubDivision()
        {
            TotalSubDivision = Total;

            if (SubDivision > 0)
            {
                TotalSubDivision = Total / SubDivision;
            }
        }
    }
}
