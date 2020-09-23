using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salary.Model;

namespace Salary.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public Account account { get; set; }

        private DatabaseContext db;

        public string msg;

        public SignInModel(DatabaseContext _db)
        {
            db = _db;

        }
        public void OnGet()
        {
            account = new Account();

        }

        public IActionResult OnPost()
        {
            var acc = Login(account.Username, account.Password);
            if (acc == null)
            {
                msg = "invalid";
            }
            else
            {
                return RedirectToPage("index");
            }
            return RedirectToPage("index");
        }


        public Account Login(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username));
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
                
            }
            return account;


        }

    }
}
