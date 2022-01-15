using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessage.Duplicate);

            var customer = new CustomerDiscount(command.ProductId, command.DiscountRate, command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(), command.Reason);
            _customerDiscountRepository.Create(customer);
            _customerDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.Id);

            if (customerDiscount == null)
                operation.Failed(ApplicationMessage.NotFound);

            if (_customerDiscountRepository.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            customerDiscount.Edit(command.ProductId,command.DiscountRate,command.StartDate.ToGeorgianDateTime(),command.EndDate.ToGeorgianDateTime(),command.Reason);
            _customerDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}