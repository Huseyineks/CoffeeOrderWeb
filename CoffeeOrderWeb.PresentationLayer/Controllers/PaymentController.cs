using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Globalization;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ICreditCardService _creditCardService;


        public PaymentController(UserManager<AppUser> userManager,IPaymentService paymentService, IOrderService orderService, ICreditCardService creditCardService)
        {
            _userManager = userManager;
            _paymentService = paymentService;
            _orderService = orderService;
            _creditCardService = creditCardService;
        }
        public async Task<IActionResult> Index()
        {
           var user = await _userManager.GetUserAsync(User);
           var orders = _orderService.GetClassifiedList(i => i.UserId == user.Id).Where(i => i.Status == OrderStatus.InBasket).ToList();
           float totalPrice = 0;

            foreach (var order in orders)
            {
                if (order.ProductPrice.Contains(','))
                {
                    order.ProductPrice = order.ProductPrice.Replace(',', '.');
                }
                totalPrice += float.Parse(order.ProductPrice, NumberStyles.Float, CultureInfo.InvariantCulture);
            }
            ViewBag.TotalPrice = totalPrice;
            PaymentViewModel paymentViewModel = new PaymentViewModel()
            {
                City = user.City,
                FullAdress = user.FullAdress,
                Region = user.Region,
                PostalCode = user.PostalCode,
                orders = orders,

            };

            

            return View(paymentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(PaymentViewModel paymentInfo) {
            
            var user = await _userManager.GetUserAsync(User);

            var orders = _orderService.GetClassifiedList(i => i.UserId == user.Id);
            orders = orders.Where(i => i.Status == OrderStatus.InBasket).ToList();

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
                
                _creditCardService.Add(creditCard);
                _creditCardService.Save();

                PaymentInformation paymentInformation = new PaymentInformation()
                {
                    CashOrPayAtAdress = paymentInfo.CashOrPayAtAdress,
                    CreditCard = true,
                    // continue...
                    PaymentConfirmed = true,
                    totalPrice = paymentInfo.TotalPrice



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
                   
                    CreditCard = false,

                    CashOrPayAtAdress = paymentInfo.CashOrPayAtAdress,

                    totalPrice = paymentInfo.TotalPrice


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

        public async Task<IActionResult> RemoveOrder(Guid guid)
        {
            var order = _orderService.Get(i => i.RowGuid == guid);
            var user = await _userManager.GetUserAsync(User);
            var orders = _orderService.GetClassifiedList(i => i.Status == OrderStatus.InBasket && i.UserId == user.Id);
            if (order.ProductPrice.Contains(','))
            {
                order.ProductPrice = order.ProductPrice.Replace(',', '.');
            }
            var floatPrice = float.Parse(order.ProductPrice, NumberStyles.Float, CultureInfo.InvariantCulture);
            var price = floatPrice - floatPrice / order.ProductCount;
            if (order.ProductCount == 1 && orders.Count == 1)
            {


                _orderService.Remove(order);
                _orderService.Save();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                if(order.ProductCount == 1)
                {

                    _orderService.Remove(order);
                    _orderService.Save();
                    return RedirectToAction("Index", "Payment");

                }
                order.ProductCount--;
                order.ProductPrice = price.ToString();
                _orderService.Update(order);
            }
            
            _orderService.Save();

            return RedirectToAction("Index","Payment");

        }
    }
}
