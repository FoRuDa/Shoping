using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository:RepositoryBase<long,Account>,IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository( AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Mobile = x.Mobile,
                RoleId = x.RoleId
            }).FirstOrDefault(x => x.Id == id);
        }

        public Account GetBy(string userName)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserName == userName);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.Accounts.Include(x=>x.Role).Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                ProfilePhoto = x.ProfilePhoto,
                Mobile = x.Mobile,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate.ToFarsi(),
                
            });
            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query = query.Where(x =>x.FullName.Contains(searchModel.FullName) );

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (searchModel.RoleId>0)
                query = query.Where(x => x.RoleId==searchModel.RoleId);

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
