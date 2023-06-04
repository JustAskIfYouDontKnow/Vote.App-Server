﻿using VoteApp.Database;
using VoteApp.Database.User;
using VoteApp.Models.API.User;

namespace VoteApp.Host.Service;

public class UserService : IUserService
{
    private readonly IDatabaseContainer _databaseContainer;

    public UserService(IDatabaseContainer databaseContainer)
    {
        _databaseContainer = databaseContainer;
    }

    public async Task<int> GetUserIdFromValidCookies(HttpContext httpContext)
    {
        var userIdClaim = httpContext.User.FindFirst(UserClaims.Id.ToString());
    
        if (userIdClaim == null)
        {
            throw new UnauthorizedAccessException();
        }

        if (!int.TryParse(userIdClaim.Value, out var userId))
        {
            throw new ArgumentException("User ID must be int");
        }

        return userId;
    }


    public async Task<UserModel> Create(RequestRegisterUser requestRegisterUser)
    {
       return await _databaseContainer.UserWeb.CreateUser(
            requestRegisterUser.Login,
            requestRegisterUser.FirstName,
            requestRegisterUser.LastName,
            requestRegisterUser.Phone,
            requestRegisterUser.Password);
        
    }
}