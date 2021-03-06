﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublisherService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            IEnumerable<Publisher> publishers = _unitOfWork.PublisherRepository.GetAll();
            var publisherModels = Mapper.Map<IEnumerable<PublisherModel>>(publishers);
            return publisherModels;
        }

        public void Add(PublisherModel model)
        {
            var publisher = Mapper.Map<Publisher>(model);
            _unitOfWork.PublisherRepository.Insert(publisher);
            _unitOfWork.SaveChanges();
        }

        public PublisherModel GetModelByCompanyName(string companyName)
        {
            Publisher publisher = _unitOfWork.PublisherRepository
                .Get(p => p.PublisherLocalizations.Any(loc => loc.CompanyName == companyName))
                .First();

            var model = Mapper.Map<PublisherModel>(publisher);
            return model;
        }

        public PublisherModel GetModelById(int publisherId)
        {
            Publisher publisher = _unitOfWork.PublisherRepository.GetById(publisherId);
            var model = Mapper.Map<PublisherModel>(publisher);
            return model;
        }

        public bool PublisherExists(string companyName, int currentPublisherId)
        {
            bool publisherExists = _unitOfWork.PublisherRepository
                .Get(p => p.PublisherLocalizations.Any(loc => loc.CompanyName.ToLower() == companyName.ToLower())
                    && p.PublisherId != currentPublisherId)
                .Any();

            return publisherExists;
        }

        public void Remove(int publisherId)
        {
            _unitOfWork.PublisherRepository.Delete(publisherId);
            _unitOfWork.SaveChanges();
        }

        public void Update(PublisherModel publisherModel)
        {
            Publisher publisher = _unitOfWork.PublisherRepository.Get(r => r.PublisherId == publisherModel.PublisherId).First();

            if (publisher.PublisherLocalizations != null)
            {
                publisher.PublisherLocalizations.ToList().ForEach(loc => _unitOfWork.PublisherLocalizationRepository.Delete(loc));
                _unitOfWork.SaveChanges();
            }

            Mapper.Map(publisherModel, publisher);

            _unitOfWork.PublisherRepository.Update(publisher);
            _unitOfWork.SaveChanges();
        }
    }
}