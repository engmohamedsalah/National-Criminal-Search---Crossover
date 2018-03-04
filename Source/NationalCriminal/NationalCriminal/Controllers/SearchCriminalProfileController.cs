using NationalCriminal.CriminalWCFService;
using NationalCriminal.DAL;
using NationalCriminal.Helper;
using NationalCriminal.Service;
using NationalCriminal.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NationalCriminal.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class SearchCriminalProfileController : Controller
    {
        /// <summary>
        /// The country service
        /// </summary>
        ICountryService _countryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCriminalProfileController"/> class.
        /// </summary>
        /// <param name="countryService">The country service.</param>
        public SearchCriminalProfileController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllCountry()
        {
            return View(_countryService.GetAll());
        }

        // GET: SearchCriminalProfile
        /// <summary>
        /// Landing page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //check if the user login or not
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            //add dropdown List of nationalities
            // _countryService = new CountryService(unitOfWork, new CountryRepository());
            try
            {
                var Countries = _countryService.GetAll();
                var listCountriesItems = new List<SelectListItem>();
                listCountriesItems.Add(new SelectListItem() { Text = "", Value = null });
                foreach (var Country in Countries)
                    listCountriesItems.Add(new SelectListItem() { Text = Country.Nationality, Value = Country.ID.ToString() });
                ViewBag.listCountriesItems = listCountriesItems;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UserMessage", new { messageContent = ex.Message, backAction = "Index", backController = "SearchCriminalProfile" });
            }
        }
        /// <summary>
        /// Does the search.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoSearch(SearchCriminalProfileViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            string message;
            try
            {
                //call WCF service
                SearchCriminalServiceClient wcf = new SearchCriminalServiceClient();
                var result = wcf.SearchCriminal(User.Identity.Name, model.Name, model.fromAge, model.toAge, model.fromHeight, model.toHeight, model.fromWeight, model.toWeight, model.NationalityId);
                //check if there is an error in the input or on calling the serivce
                if (result.ErrorCode == null)
                    message = Constant.SuccessfulMessage;
                else
                    message = MappingError.getErrorMessage(result.ErrorCode);

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                message = ex.Message.Replace(".","");
            }
           
            return RedirectToAction("Index", "UserMessage", new { messageContent = message, backAction = "Index", backController = "SearchCriminalProfile" });


        }



    }
}
