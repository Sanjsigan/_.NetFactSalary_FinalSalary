using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salary.Model;

namespace Salary.Pages
{
    public class signupModel : PageModel
    {

        [BindProperty]
        public Account account { get; set; }

        private DatabaseContext db;

        public signupModel(DatabaseContext _db)
        {
            db = _db;

        }

        public void OnGet()
        {
            account = new Account();
        }
        public IActionResult OnPost()
        {
            account.Password =(account.Password);
            db.Accounts.Add(account);
            db.SaveChanges();
            return RedirectToPage("SignIn");

        }
    }
}
