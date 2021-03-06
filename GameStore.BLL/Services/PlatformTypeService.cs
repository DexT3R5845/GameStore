﻿using System.Collections.Generic;
using AutoMapper;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Models;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;

namespace GameStore.BLL.Services
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformTypeService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public PlatformTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PlatformTypeModel> GetAll()
        {
            IEnumerable<PlatformType> platformTypes = _unitOfWork.PlatformTypeRepository.GetAll();
            var platformTypeModels = Mapper.Map<IEnumerable<PlatformTypeModel>>(platformTypes);
            return platformTypeModels;
        }
    }
}