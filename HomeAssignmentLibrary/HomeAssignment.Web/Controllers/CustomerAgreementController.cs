using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using HomeAssignment.Web.Models;


namespace HomeAssignment.Web.Controllers
{
    public class CustomerAgreementController : Controller
    {
        public ActionResult Index()
        {
            const string BASE_RATE_CODE = "VILIBOR1m";
            const string CUSTOMER_ID = "da2fd609-d754-4feb-8acd-c4f9ff13ba96";

            var customers = CustomerList();
            var baseRateCodes = new List<SelectListItem>
            {
                new SelectListItem{Text="VILIBOR1m",Value="VILIBOR1m" },
                new SelectListItem{Text="VILIBOR3m",Value="VILIBOR3m" },
                new SelectListItem{Text="VILIBOR6m",Value="VILIBOR6m" },
                new SelectListItem{Text="VILIBOR1y",Value="VILIBOR1y" }
            };

            IEnumerable<CustomerAgreementViewModel> agreements = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50001/api/");

                //HTTP GET
                var responseTask = client.GetAsync($@"customers/{CUSTOMER_ID}/agreements/baseRateCode={BASE_RATE_CODE}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CustomerAgreementViewModel>>();
                    readTask.Wait();

                    agreements = readTask.Result;
                }
                else
                {
                    agreements = Enumerable.Empty<CustomerAgreementViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            ViewBag.CustomersList = customers;
            ViewBag.BaseRateCodes = baseRateCodes;
            
            return View(agreements);
        }

        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50001/api/");
                //HTTP GET
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CustomerViewModel>>();
                    readTask.Wait();

                    customers = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            ViewBag.ApplicationTypes = customers;
            return customers;
        }
    }
}