using InvoiceXpress;
using InvoiceXpressWebAppClientSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InvoiceXpressWebAppClientSample.Controllers
{
    public class HomeController : Controller
    {
        private InvoiceXpressClient _invoiceXpress;

        public HomeController(InvoiceXpressClient invoiceXpress)
        {
            _invoiceXpress = invoiceXpress;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["ApiUrl"] = _invoiceXpress.ApiUrl;
            var invoices = await _invoiceXpress.Invoices.GetAll();
            return View(invoices);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
