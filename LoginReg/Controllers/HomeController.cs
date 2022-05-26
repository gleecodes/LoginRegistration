using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
	private LoginRegContext dbContext;
        public HomeController(LoginRegContext context)
        {
            dbContext = context;
        }
        
        
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet("success")]
            public IActionResult Success()
            {
                return View();
            }


        [HttpPost("create")]
        public IActionResult Create(User NewUser)
        {       
        
        // Other code
                if(ModelState.IsValid)
                {
                    if(dbContext.Users.Any(u => u.Email == NewUser.Email))
                    {
                        ModelState.AddModelError("Email", "Email already in use!");
                         return View("Index");
                    }
                
                
                    else
                    {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    dbContext.Add(NewUser);
                    dbContext.SaveChanges();
                     return RedirectToAction("Success");
                    
                    }
                }
                return View("Index");
                }
        [HttpPost("Login")]
        public IActionResult Login(LogUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                //User myUser = dbContext.GetUser("eirika.sawh@gmail.com");
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                
                // Initialize hasher object
                var hasher = new PasswordHasher<LogUser>();
                
                // varify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    if(dbContext.Users.Any(u => u.Password == userSubmission.Password))
                    {
                        ModelState.AddModelError("Password", "INCORRECT!");
                         return View("Index");
                    }
                }
                else
                    {
                        return View("Success");
                    }
            }
        return RedirectToAction("Index");
        }   
    }          
}