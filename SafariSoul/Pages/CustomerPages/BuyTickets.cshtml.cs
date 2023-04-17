using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.CustomerPages
{
	public class BuyTicketsModel : PageModel
	{
        private readonly ZooDbContext _context;

        public BuyTicketsModel(ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
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

        [BindProperty]
        public TransactionCustomerViewModel TransactionCustomer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)
            {
                return NotFound("Not able to load user with associated CustomerId.");
            }

            // Update the transaction's date and time and customer ID
            TransactionCustomer.Transaction.DateAndTime = DateTime.Now;
            TransactionCustomer.Transaction.CustomerId = customerId.Value;

            // Update the customer's credit card number and address
            var customer = await _context.Customers.FindAsync(customerId.Value);
            if (customer == null)
            {
                return NotFound("Unable to load customer with associated CustomerId.");
            }

            customer.CreditCardNo = TransactionCustomer.Customer.CreditCardNo;
            customer.Address = TransactionCustomer.Customer.Address;

            _context.ZooTransactions.Add(TransactionCustomer.Transaction);
            _context.Customers.Update(customer); // Update the existing customer object
            await _context.SaveChangesAsync();

            return RedirectToPage("./Successful");
        }
    }
}
