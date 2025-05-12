using Solid.DIP.Payment;

namespace Solid.DIP.Shopping
{
    internal class ShoppingCart : IShoppingService
    {
        // Wir sollten hier NICHT gegen die konkrete Implementierung gehen
        public PaymentService _paymentService_BadSample = new PaymentService();

        private readonly IPaymentService _paymentService;

        // DIP: Die Abhängigkeit sollte von außen kommen
        public ShoppingCart(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void PayOrder()
        {
            _paymentService.MakePayment();
        }
    }
}
