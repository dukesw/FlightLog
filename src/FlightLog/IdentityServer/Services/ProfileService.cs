using DukeSoftware.FlightLog.ApplicationCore.IdentityServer;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DukeSoftware.FlightLog.ApplicationCore.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<FlightLogUser> _claimsFactory;
        private readonly UserManager<FlightLogUser> _userManager;

        public ProfileService(UserManager<FlightLogUser> userManager, IUserClaimsPrincipalFactory<FlightLogUser> claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            // Add custom claims in token here based on user properties or any other source
            if (user.AccountId != 0)
            {
                claims.Add(new Claim("accountid", user.AccountId.ToString()));
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            // TODO Sort out some better logic for this
            context.IsActive = user.AccountId > 0;  // Not active unless they have a "valid" account assigned
        }
    }
}