﻿
using API.DTO_s.User_RolesDTO_s;
using Core.Login_RegisterDTO_s;
using Infrastructure.User_RolesDTO_s;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserAccount
    {
        Task CreateAsync(RegisterDTO register);

        Task LoginAsync(LoginDTO login);

        Task RefreshTokenAsync(RefreshTokenDTO refreshToken);
    }
}