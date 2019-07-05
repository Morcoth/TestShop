using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebStore.Domain.Entities;

namespace WebStore.Domain.DTO.Identity
{
    public class ReplaceClaimDTO : ClaimInfoDTO
    {
        public Claim Oldclaim { get; set; }
        public Claim Newclaim { get; set; }
    }
}
