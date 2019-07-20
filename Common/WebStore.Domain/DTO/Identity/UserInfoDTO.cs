using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;


namespace WebStore.Domain.DTO.Identity
{
    public abstract class UserInfoDTO
    {
        public User User { get; set; }

    }
}
