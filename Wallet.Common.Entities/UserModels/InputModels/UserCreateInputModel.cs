﻿namespace Wallet.Common.Entities.User.InputModels
{
    public class UserCreateInputModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
