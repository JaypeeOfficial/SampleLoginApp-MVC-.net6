using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SampleLoginApp.Data
{
    public class AppIdentity : IdentityUser
    {

        [StringLength(100)]
        public string CompanyName { get; set; }


    }
}
