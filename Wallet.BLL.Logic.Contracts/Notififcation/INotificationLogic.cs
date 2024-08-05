﻿using EmailService.Common.Contracts;

namespace Wallet.BLL.Logic.Contracts.Notififcation
{
    public interface INotificationLogic
    {
        Task SendAsync(EmailServiceMessage message);
    }
}
