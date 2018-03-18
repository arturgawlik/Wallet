using Microsoft.AspNetCore.Identity;
using WalletDomain.Domain;

namespace WalletInfrastructure.AbstractionImplementation
{
    public class ApplicationUser : IdentityUser, IAbstractionApplicationUser
    {
    }
}