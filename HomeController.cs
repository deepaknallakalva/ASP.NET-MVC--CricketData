using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CricketData.Models;
using CricketData.Models.Entities;
using CricketData.Models.ViewModels;
using CricketData.Infrastructure;
using CricketData.HashingAndSalting;

namespace CricketData.Controllers


{
    public class HomeController : Controller
    {
        private IStoreDomainModel repository;

        public HomeController(IStoreDomainModel repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return Countries();
        }

        public ViewResult Country(int countryID)
        {

            Country country = repository.Countries.Single(s => s.CountryId == countryID);

            CountryViewModel countryViewModel = new CountryViewModel(country, true);
            ViewBag.Customer = GetCustomer();
            return View(countryViewModel);

        }
        public ViewResult Player(int playerID)
        {
            Player player = repository.Players.Single(p => p.PlayerId == playerID);
            PlayerViewModel playerViewModel = new PlayerViewModel(player, true);
            ViewBag.Customer = GetCustomer();
            return View(playerViewModel);
        }

        public ViewResult Countries()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel(repository.Countries);
            
            return View("Countries", countriesViewModel);
        }

        public ViewResult Players()
        {


           PlayersViewModel playersViewModel = new PlayersViewModel(repository.Players);
            ViewBag.Customer = GetCustomer();
            return View("Players", playersViewModel);
        }
        public ViewResult Customers()
        {

            CustomersViewModel customersViewModel = new CustomersViewModel();
            foreach (Customer customer in repository.Customers)
            {
                customersViewModel.CustomerViewModels.Add(new CustomerViewModel(customer));
            }
            ViewBag.Customer = GetCustomer();
            return View("Customers", customersViewModel);
        }
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

       

        [HttpPost]
        public ViewResult Register(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid) 
            {
                customerViewModel.GeneratePasswordHash();
                if (!repository.AddCustomer(customerViewModel.Customer)) 
                    return View();
                Customer customer = repository.Customers.Single(c => (c.Email == customerViewModel.Email
                                                            && c.PasswordHash == customerViewModel.PasswordHash));
                SaveCustomer(new CustomerViewModel(customer));
                ViewBag.Customer = GetCustomer();
                return Customers();

            }
            else //invalid
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult Login()
        {

            return View();
        }

        public ViewResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) 
            {
                PasswordManager pwdManager = new PasswordManager();

                Customer customer = repository.Customers.Single(c => c.Email == loginViewModel.Email);

                bool result = pwdManager.IsPasswordMatch(loginViewModel.Password, customer.Salt, customer.PasswordHash);
                if (result)
                {
                    SaveCustomer(new CustomerViewModel(customer));
                    ViewBag.Customer = GetCustomer();
                    return Countries();
                }
                return View();

            }
            else 
            {
                return View();
            }
        }
        private CustomerViewModel GetCustomer()
        {
            CustomerViewModel customer = HttpContext.Session.GetJson<CustomerViewModel>("Customer") ?? new CustomerViewModel();
            return customer;
        }
        private void SaveCustomer(CustomerViewModel customer)
        {
            HttpContext.Session.SetJson("Customer", customer);
        }


        [HttpGet]
        public ViewResult ModifyPlayer(int playerID)
        {
            if (GetCustomer() != null)
            {
                if (GetCustomer().PrivilegeId ==1)
                {
                    Player player = repository.Players.Single(p => p.PlayerId == playerID);

                    PlayerViewModel playerViewModel = new PlayerViewModel(player, repository.Countries);
                    ViewBag.Customer = GetCustomer();
                    return View(playerViewModel);
                }
            }

            return View("Error"); 
        }

        public RedirectToActionResult ModifyPlayer(PlayerViewModel playerViewModel)
        {
            if (GetCustomer() != null)
            {
                if (GetCustomer().PrivilegeId ==1)
                {
                    playerViewModel.UpdateCountries(playerViewModel.SelectedCountries, repository.Countries);
                    repository.UpdatePlayer(playerViewModel.Player);
                    return RedirectToAction("Player", new { playerID = playerViewModel.Id });
                }
            }
            return RedirectToAction("Error"); 
        }

        [HttpGet]
        public ViewResult GetComment(int playerID,int customerID)
        {
            ViewBag.Customer = GetCustomer();
            return View();
        }

        [HttpPost]
        public ViewResult GetComment(CommentViewModel commentviewmodel,int playerID,int customerID)
        {
            Customer customer = repository.Customers.Single(x => x.CustomerId == customerID);
            string customername = customer.FirstName;
            repository.AddComment(commentviewmodel.comment, playerID,customerID,customername);
            Player player = repository.Players.Single(x => x.PlayerId == playerID);
            PlayerViewModel playerViewModel = new PlayerViewModel(player, repository.Countries);
            ViewBag.Customer = GetCustomer();

            return View("Player",playerViewModel);
        }

        [HttpGet]
        public ViewResult GetCom(int playerID)
        {

             var Commente = from c in repository.Comment 
                           where c.PlayerId == playerID
                           select new CommentViewModel(c.UserComment,c.CustomerId,c.name) { };
                           

           


            var listofcomments = Commente.ToList();

          
            return View(listofcomments);
        }
    }
    }

