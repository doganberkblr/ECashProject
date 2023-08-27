using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DTOLayer.DTOS.CustomerAccountProcessDTOS;
using ECashProject.DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(ICustomerAccountProcessService customerAccountProcessService)
        {
            _customerAccountProcessService = customerAccountProcessService;
        }

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDTO.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();
            sendMoneyForCustomerAccountProcessDTO.SenderID = user.Id;
            sendMoneyForCustomerAccountProcessDTO.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcessDTO.ProcessType = "Havale";
            sendMoneyForCustomerAccountProcessDTO.ReceiverID = receiverAccountNumberID;
            //_customerAccountProcessService.TInsert();
            return RedirectToAction("Index","Deneme");
        }
    }
}

