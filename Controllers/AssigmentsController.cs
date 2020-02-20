using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIN.Data;
using PIN.Models;


namespace PIN.Controllers
{
    public class AssigmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<MyIdentityRole> roleManager;


        public AssigmentsController(ApplicationDbContext context, UserManager<AppUser> userManager,
                                    RoleManager<MyIdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;        
            this.roleManager = roleManager;
        }
       
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Create() {       
            return View(new MyIdentityRole()); 
        }
        
   
        [HttpPost]
        public async Task<IActionResult>Create(MyIdentityRole nRole)
        {           
                if (ModelState.IsValid)
                {
                    var result = await roleManager.FindByNameAsync(nRole.Name);
                    if (result == null){
                        IdentityResult newresult = await roleManager.CreateAsync(nRole);
                        if (newresult.Succeeded)
                            ViewBag.status = "Operation done successfully.";
                        else
                            ViewBag.status = "Operation failed";
                    }
                }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            MyIdentityRole role = await roleManager.FindByIdAsync(id);
           
                if (role != null) 
                {
                    IdentityResult result = await roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    return RedirectToAction("Index"); 
                }  
                 else { return RedirectToPage("Index"); }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Join(string id)
        {

            MyIdentityRole role = await roleManager.FindByIdAsync(id);
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Join(MyIdentityRole role)
        {

            var userID = userManager.GetUserId(User);
            var appUser = userManager.FindByIdAsync(userID).Result;
            var nrole = await roleManager.FindByIdAsync(role.Id);

            if (ModelState.IsValid)
            {
                var result = userManager.IsInRoleAsync(appUser, nrole.Name).Result;
                if(result)
                    await userManager.AddToRoleAsync(appUser, nrole.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            var userID = userManager.GetUserId(User);
            var appUser = userManager.FindByIdAsync(userID).Result;
            var nrole = await roleManager.FindByIdAsync(id);

            if (ModelState.IsValid)
            {
                var result = userManager.IsInRoleAsync(appUser, nrole.Name).Result;
                if (result)
                    await userManager.RemoveFromRoleAsync(appUser, nrole.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        

    }
}