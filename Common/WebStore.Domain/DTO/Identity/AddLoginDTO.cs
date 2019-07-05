using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.DTO.Identity
{
    public class AddLoginDTO : UserInfoDTO
    {
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
