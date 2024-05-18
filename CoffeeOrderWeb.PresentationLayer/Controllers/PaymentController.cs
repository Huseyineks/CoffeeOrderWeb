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


        public PaymentController(UserManager<AppUser> userManager,IPaymentService paymentService)
        {
            _userManager = userManager;
            _paymentService = paymentService;
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
        public IActionResult Index(PaymentViewModel paymentInfo) {
            
            var user = _userManager.GetUserAsync(User);

            if(paymentInfo.creditCard.IsSaved == true && paymentInfo.creditCard != null)
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
                    

                };

            }



            return View();
        }
    }
}
