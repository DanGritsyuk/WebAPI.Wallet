using Microsoft.Extensions.Logging;
using Wallet.BLL.Logic.Contracts.Users;
using Wallet.Common.Entities.User.InputModels;
using Wallet.Common.Entities.User.DB;
using Wallet.DAL.Repository.Contracts;
using Wallet.DAL.Repository.EF;
using System.Transactions;
using EmailService.Common.Contracts;
using Wallet.BLL.Logic.Contracts.Notififcation;

namespace Wallet.BLL.Logic.Users
{
    public class UserLogic : IUserLogic
    {

        private readonly IUserRepository _userRepository;
        private readonly IEFUserRepository _eFUserRepository;
        private readonly INotificationLogic _notification;
        private readonly ILogger<UserLogic> _logger;

        public UserLogic(
            IEFUserRepository eFUserRepository,
            INotificationLogic notification,
            ILogger<UserLogic> logger)
        {
            //_userRepository = userRepository;
            _eFUserRepository = eFUserRepository;
            _notification = notification;
            _logger = logger;
        }

        public async Task CreateUserAsync(UserCreateInputModel userInputModel)
        {
            try
            {
                using(var transaction = new TransactionScope())
                ValidateUser(userInputModel);

                var user = new User
                {
                    Name = userInputModel.Name,
                    Email = userInputModel.Email,
                    Login = userInputModel.Login,
                    Password = userInputModel.Password,
                    Surname = userInputModel.Surname
                };

                await _eFUserRepository.Create(user);
                _logger.LogInformation($"Id user: {user.Id}");

                var emailMsg = new EmailServiceMessage("Вы зарегистрированы", "Поздравляю, Вы зарегестрированны!", user.Email);
                await _notification.SendAsync(emailMsg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при создании User");
                throw;
            }
        }


        public async Task<List<User>> Get()
        {
            return await _eFUserRepository.GetAllAsync();
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _eFUserRepository.GetAsync(id);
            user.Name = "Tom";
            await _eFUserRepository.SomeWorkAsync();
            return user;
        }

        private void ValidateUser(UserCreateInputModel user)
        {
            List<string> exceptionsMessages = new List<string>();

            if (user == null)
            {
                exceptionsMessages.Add("User не может быть null");
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                exceptionsMessages.Add("Namee не может быть null или пустым");
            }

            if (exceptionsMessages.Any())
            {
                foreach (var exception in exceptionsMessages)
                {
                    _logger.LogError(exception);
                }
                throw new ArgumentException();
            }
        }
    }
}
