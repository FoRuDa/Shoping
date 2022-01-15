using System.Collections.Generic;
using System.Text.Json;
using _0_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();

            if (_colleagueDiscountRepository.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessage.Duplicate);

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);

            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (_colleagueDiscountRepository.Exist(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.Duplicate);

            colleagueDiscount.Edit(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return operation.Success();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}