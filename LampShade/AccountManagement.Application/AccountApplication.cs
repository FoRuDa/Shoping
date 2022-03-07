using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication :IAccountApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;

        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher, IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exist(x => x.UserName == command.UserName || x.Mobile==command.Mobile))
                return operation.Failed(ApplicationMessage.Duplicate);

            var path = $"ProfilePhoto/{command.FullName}";
            var photoPath = _fileUploader.Upload(command.ProfilePhoto, path);
            if (string.IsNullOrWhiteSpace(photoPath))
                photoPath = $"/ProfilePhoto/user-icon.png";
            var password = _passwordHasher.Hash(command.Password);
            var account = new Account(command.FullName, command.UserName, password, command.Mobile,
                command.RoleId, photoPath);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (_accountRepository.Exist(x => x.UserName == command.UserName && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            var photoPath = _fileUploader.Upload(command.ProfilePhoto, $"ProfilePhoto/{command.FullName}");
            account.Edit(command.FullName,command.UserName,command.Mobile,command.RoleId,photoPath);
            _accountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessage.PassNotMach);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.UserName);
            if (account == null)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            (bool Verufied,bool NeedsUpgread)result=_passwordHasher.Check(account.Password, command.Password);
            if (!result.Verufied)
                return operation.Failed(ApplicationMessage.WrongUserPass);

            var authViewModel = new AuthViewModel (  account.Id, account.FullName, account.UserName,  account.RoleId);
            _authHelper.Signin(authViewModel);
            return operation.Success();
        }

        public OperationResult Logout()
        {
            var operation = new OperationResult();
            _authHelper.SignOut();
            return operation.Success();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
