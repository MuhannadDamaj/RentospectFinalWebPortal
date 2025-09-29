﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using RentospectWebApp.DTOs;
using System.ComponentModel.Design;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RentospectWebApp.Auth
{

    public class AuthStateProvider : AuthenticationStateProvider
    {
        private const string AuthType = "rentospect-auth";
        private const string UserDataKey = "udata";
        private Task<AuthenticationState> _authStateTask;
        public LoggedInUser _user { get; private set; }
        public IJSRuntime _jSRuntime { get; }

        public AuthStateProvider(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
            SetAuthStateTask();
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            _authStateTask;

        public async Task SetLoginAsync(LoggedInUser user)
        {
            _user = user;
            await _jSRuntime.InvokeVoidAsync("localStorage.setItem",
                                              UserDataKey,
                                              _user.ToJson());
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_authStateTask);

        }
        public async Task SetLogoutAsync()
        {
            _user = null;
            SetAuthStateTask();
            NotifyAuthenticationStateChanged(_authStateTask);
            await _jSRuntime.InvokeVoidAsync("localStorage.removeItem", UserDataKey);
        }
        public bool IsInitializing { get; private set; } = true;
        public async Task InitializeAsync()
        {
            try
            {
                var userData = await _jSRuntime.InvokeAsync<string>("localStorage.getItem", UserDataKey);

                if (string.IsNullOrWhiteSpace(userData))
                    return;
                var loggedInUser = LoggedInUser.LoadForm(userData);
                if (loggedInUser == null || loggedInUser.ID == 0)
                    return;
                await SetLoginAsync(loggedInUser);
            }
            catch { }
            finally
            {
                IsInitializing = false;
            }
            

        }
        private void SetAuthStateTask()
        {
            if (_user == null) // user not logget yet
            {
                InitialSet();
                return;
            }
            if (_user.ID == 0) // user not logget yet
            {
                InitialSet();
                return;
            }
            if (_user.ID > 0)
            {
                {
                    var identity = new ClaimsIdentity(_user.ToClaims(), AuthType);
                    var principal = new ClaimsPrincipal(identity);
                    var authState = new AuthenticationState(principal);
                    _authStateTask = Task.FromResult(authState);
                }
            }
        }
        private void InitialSet()
        {
            var identity = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);
            _authStateTask = Task.FromResult(authState);
        }

    }
}
