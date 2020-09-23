
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Salary.Model;

namespace Salary.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public Account accounts { get; set; }

        private DatabaseContext db;

        public string msg;

        public SignInModel(DatabaseContext _db)
        {
            db = _db;

        }
        public void OnGet()
        {
            accounts = new Account();

        }

        public IActionResult OnPost()
        {
            var acc = Login(accounts.Username, accounts.Password);
            if (acc == null)
            {
                msg = "invalid";
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }
            
        }
        public Account Login(string username, string password)
        {
            var accounts = db.Accounts.SingleOrDefault(a => a.Username.Equals(username));
            if (accounts != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, accounts.Password))
                {
                    return accounts;
                }

            }
            return null;


        }

    }
}