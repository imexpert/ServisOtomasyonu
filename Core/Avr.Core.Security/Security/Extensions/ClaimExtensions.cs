using System.Collections.Generic;
using System.Security.Claims;

namespace Avr.Core.Security.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
    }
}
