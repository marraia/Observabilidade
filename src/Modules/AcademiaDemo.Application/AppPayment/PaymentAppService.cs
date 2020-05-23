using AcademiaDemo.Application.AppPayment.Input;
using AcademiaDemo.Application.Interfaces;
using AcademiaDemo.Domain.Entities;
using AcademiaDemo.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Application.AppPayment
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentAppService(
            IPaymentRepository paymentRepository
        )
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> InsertAsync(PaymentInput input)
        {
            var payment = new Payment(input.CardNumber, input.SubDivision, input.Total);

            if (!payment.ValidateCreditCard())
                throw new ArgumentException("Cartão de crédito inválido");

            payment.CalculatedSubDivision();

            await _paymentRepository
                    .InsertAsync(payment)
                    .ConfigureAwait(false);

            return payment;
        }
    }
}
