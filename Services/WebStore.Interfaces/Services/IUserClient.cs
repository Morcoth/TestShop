using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IUserClient :  IUserStore<User>, 
                                    IUserClaimStore<User>, 
                                    IUserPasswordStore<User>, 
                                    IUserEmailStore<User>, 
                                    IUserPhoneNumberStore<User>,
                                    IUserLoginStore<User>, 
                                    IUserLockoutStore<User>,
                                    IUserTwoFactorRecoveryCodeStore<User>
    {
    }
}
