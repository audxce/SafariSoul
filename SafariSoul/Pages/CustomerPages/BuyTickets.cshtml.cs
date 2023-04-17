using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;
using SafariSoul.Pages.Login;
using System.Transactions;

namespace SafariSoul.Pages.CustomerPages
{
	public class BuyTicketsModel : PageModel
	{
        private readonly ZooDbContext _context;

        public BuyTicketsModel(ZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionCustomerViewModel TransactionCustomer { get; set; }

        public IActionResult OnGet()
        {
            int? customerId = HttpContext.Session.GetInt32(LoginModel.SessionKeyCID);
            if (customerId == null)
            {
                return NotFound("Unable to load user with associated CustomerId.");
            }

            var customer = _context.Customers.Find(customerId.Value);
            if (customer == null)
            {
                return NotFound("Unable to load customer with associated CustomerId.");
            }

            // Populate ViewData with the loaded customer object
            ViewData["Customer"] = customer;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // Output the validation error to the user
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            int? customerId = HttpContext.Session.GetInt32(LoginModel.SessionKeyCID);
            if (customerId == null)
            {
                return NotFound("Not able to load user with associated CustomerId.");
            }

            // Update the transaction's date and time and customer ID

            // Update the customer's credit card number and address
            var customer = await _context.Customers.FindAsync(customerId.Value);
            if (customer == null)
            {
                return NotFound("Unable to load customer with associated CustomerId.");
            }

            TransactionCustomer.Transaction.CustomerId = customerId.Value;

            _context.ZooTransactions.Add(TransactionCustomer.Transaction);
            await _context.SaveChangesAsync();

            customer.Address = TransactionCustomer.Customer.Address;
            customer.CreditCardNo = TransactionCustomer.Customer.CreditCardNo;
            _context.Attach(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Successful"); // Redirect to a confirmation page or the main page
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
