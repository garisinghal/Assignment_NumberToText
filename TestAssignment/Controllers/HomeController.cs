using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    // Method to consume the REST web service
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Intializing the model to read the input value from view
            InformationModel information = new InformationModel();

            // Reading the Parameters from view
            var name = Request.Params["name"];
            var amount = Request.Params["amount"];

            //Try-Catch block for exception handling
            try
            {
                //Consuming the web service
                if (!string.IsNullOrWhiteSpace(amount))
                {
                    using (var client = new HttpClient())
                    {
                        string url = System.Configuration.ConfigurationManager.AppSettings["urlPath"];
                        client.BaseAddress = new Uri(url +"/api/");

                        //HTTP GET
                        var responseTask = client.GetAsync("Information/GetNameAndAmount/" + name + "/" + amount + "/");
                        responseTask.Wait();

                        //Collecting the Response
                        var result = responseTask.Result;
                        decimal _decimalResult;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<InformationModel>();
                            readTask.Wait();
                            information = readTask.Result;

                            // Rounding off the number after decimal
                            decimal _amount = Convert.ToDecimal(amount);
                            amount = Math.Round(_amount, 2).ToString();
                            information.MyOriginalNumber = amount;
                        }
                        //Error response from Web API
                        //Error msgs can be managed in a error log file				
                        else if (string.IsNullOrEmpty(name))
                        {
                            //When Name is not entered
                            information = ErrorMessages(1, name, amount);
                        }
                        else if (!decimal.TryParse(amount, out _decimalResult))
                        {
                            //When Amount is not in right format
                            information = ErrorMessages(5, name, amount);
                        }
                        else
                        {
                            //When Web Service is not working fine
                            information = ErrorMessages(2, name, amount);
                        }
                    }

                }
                else if (!string.IsNullOrEmpty(amount))
                {
                    //When Number is not Entered
                    information = ErrorMessages(3, name, amount);
                }
            }
            //Exception Handling
            //Error msgs can be managed in a error log file
            catch
            {
                //Exception Handling
                information = ErrorMessages(4, name, amount);
            }
            return View(information);
        }

        private InformationModel ErrorMessages(int i, string name, string amount)
        {
            InformationModel information = new InformationModel();
            information.MyName = name;
            information.MyOriginalNumber = amount;
            switch (i)
            {
                case 1:
                    information.MyCurrentcyNumberText = "Please Enter the Name";
                    break;
                case 2:
                    information.MyCurrentcyNumberText = "API in not working fine";
                    break;
                case 3:
                    information.MyCurrentcyNumberText = "Please Enter the Amount";
                    break;
                case 4:
                    information.MyCurrentcyNumberText = "Sorry! there is some error, Please Try again";
                    break;
                case 5:
                    information.MyCurrentcyNumberText = "Format of Amount is incorrect";
                    break;
                default:
                    return information;
            }
            return information;
        }
    }
}