﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }


        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();

            var path = "Slide";
            var picPath = _fileUploader.Upload(command.Picture, path);
            var slide = new Slide(picPath, command.PictureAlt, command.PictureTitle, command.Heading,
                command.Title,
                command.Text, command.BtnText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Success();

        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(command.Id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.NotFound);

            var picPath = _fileUploader.Upload(command.Picture, "Slide");
            slide.Edit(picPath,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.BtnText,command.Link);
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.NotFound);
            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.Get(id);

            if (slide == null)
                return operation.Failed(ApplicationMessage.NotFound);
            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Success();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }
    }
}
