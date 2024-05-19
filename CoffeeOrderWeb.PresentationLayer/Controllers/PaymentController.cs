using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;


        public PaymentController(UserManager<AppUser> userManager,IPaymentService paymentService, IOrderService orderService)
        {
            _userManager = userManager;
            _paymentService = paymentService;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
           var user = await _userManager.GetUserAsync(User);

            PaymentViewModel paymentViewModel = new PaymentViewModel()
            {
                City = user.City,
                FullAdress = user.FullAdress,
                Region = user.Region
            };

            return View(paymentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(PaymentViewModel paymentInfo) {
            
            var user = await _userManager.GetUserAsync(User);

            var orders = _orderService.GetClassifiedList(i => i.UserId == user.Id);

            if (paymentInfo.creditCard.IsSaved == true && paymentInfo.creditCard != null)
            {
                CreditCard creditCard = new CreditCard()
                {
                    CardName = paymentInfo.creditCard.cardName,
                    CardCvv = paymentInfo.creditCard.cardCvCode,
                    CardNumber = paymentInfo.creditCard.cardNumber,
                    CardDate = paymentInfo.creditCard.cardExpirationDate,
                    CardType = "Visa",
                    UserId = user.Id


                };

                PaymentInformation paymentInformation = new PaymentInformation()
                {
                    Cash = false,
                    PaymentAtAdress = false,
                    CreditCard = true,
                    // continue...
                    PaymentConfirmed = true,



                };
                _paymentService.Add(paymentInformation);
                _paymentService.Save();

                foreach (var order in orders)
                {
                    order.PaymentId = paymentInformation.PaymentId;
                    order.Status = OrderStatus.Processing;
                }

                

            }
            else
            {
                PaymentInformation paymentInformation = new PaymentInformation()
                {
                    PaymentConfirmed = false,
                    Cash = paymentInfo.Cash,
                    CreditCard = false,
                    PaymentAtAdress = paymentInfo.PayAtAdress,

                };
                _paymentService.Add(paymentInformation);
                _paymentService.Save();

                foreach (var order in orders)
                {
                    order.PaymentId = paymentInformation.PaymentId;
                    order.Status = OrderStatus.Processing;
                    _orderService.Update(order);
                }

            }
            
            _orderService.Save();

            



            return RedirectToAction("Index", "Home");
        }
    }
}
