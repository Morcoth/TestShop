using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.DTO.Identity
{
    public class PasswordHashDTO : UserInfoDTO
    {
        public string Hash { get; set; }

    }
}
