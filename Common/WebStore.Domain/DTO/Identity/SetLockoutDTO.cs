using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.DTO.Identity
{
    public class SetLockoutDTO: UserInfoDTO
    {
        public DateTimeOffset? LockOutEnd { get; set; }
    }

}
