using Blog.Application.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Extensions
{
   public static class IdentityResultExtensions
    {
        public static Result ToResult(this IdentityResult identityResult)
        {
            return identityResult.Succeeded ? Result.Success() : Result.Fail(identityResult.Errors.Select(e => e.Description));
        }
    }
}
