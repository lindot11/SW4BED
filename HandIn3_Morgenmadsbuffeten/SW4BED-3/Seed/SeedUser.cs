using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace SW4BED_3.SeedUser
{
    

    public class SeedUsers
    {
            public static void SeedReceptionist(UserManager<IdentityUser> userManager)
            {
                const string receptionistEmail = "Receptionist@localhost";
                const string receptionistPassword = "Receptionist@1";
                if (userManager == null)
                    throw new ArgumentNullException(nameof(userManager));
                if (userManager.FindByNameAsync(receptionistEmail).Result == null)
                {
                    var user = new IdentityUser();
                    user.UserName = receptionistEmail;
                    user.Email = receptionistEmail;
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync(user, receptionistPassword).Result;
                    if (result.Succeeded)
                    {
                        var adminUser = userManager.FindByNameAsync(receptionistEmail).Result;
                        var claim = new Claim("IsReceptionist", "true");
                        var claimAdded = userManager.AddClaimAsync(adminUser, claim).Result;
                    }
                }
            }
            public static void SeedWaiter(UserManager<IdentityUser> userManager)
            {
                const string waiterEmail = "Waiter@localhost";
                const string waiterPassword = "Waiter@1";
                if (userManager == null)
                    throw new ArgumentNullException(nameof(userManager));
                if (userManager.FindByNameAsync(waiterEmail).Result == null)
                {
                    var user = new IdentityUser();
                    user.UserName = waiterEmail;
                    user.Email = waiterEmail;
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync(user, waiterPassword).Result;
                    if (result.Succeeded)
                    {
                        var adminUser = userManager.FindByNameAsync(waiterEmail).Result;
                        var claim = new Claim("IsWaiter", "true");
                        var claimAdded = userManager.AddClaimAsync(adminUser, claim).Result;
                    }
                }
            }
          
    }
    
}
