﻿namespace CreditApplicationSystem.WebApi.Authentication
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public string JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}