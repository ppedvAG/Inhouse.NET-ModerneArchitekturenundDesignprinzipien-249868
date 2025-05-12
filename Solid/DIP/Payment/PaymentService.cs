using Solid.DIP.Shopping;

namespace Solid.DIP.Payment
{
    internal class PaymentService : IPaymentService
    {
        public void MakePayment()
        {
            Console.WriteLine("Payment made");
        }
    }
}
