using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebStore.Domain.DTO.Identity
{
    public abstract class ClaimInfoDTO :UserInfoDTO
    {
        public IEnumerable<Claim> Claims { get; set; }

    }
}
