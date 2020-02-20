using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIN.Data;
using PIN.Models;
using System.Threading.Tasks;

namespace PIN.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> loginManager;
        private readonly RoleManager<MyIdentityRole> roleManager;


        public AccountController(ApplicationDbContext context,UserManager<AppUser> userManager,
           SignInManager<AppUser> loginManager,
           RoleManager<MyIdentityRole> roleManager)
        {
            this. _context = context;
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }

        
        public IActionResult Applications()
        {
             
            return View(userManager.Users);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(string id)
        {
            var appUser = await _context.Users.FindAsync(id);
            appUser.EmailConfirmed = true;
            if (appUser != null)
            {
                var result = userManager.AddToRoleAsync(appUser,
                                            "NormalUser").Result;
                if (result.Succeeded) 
                    await _context.SaveChangesAsync();              
            
            }
            return RedirectToAction(nameof(Applications));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var appUser = await _context.Users.FindAsync(id);
            if (appUser != null)
            {
               _context.Users.Remove(appUser);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Applications));
        }

       

    }
}