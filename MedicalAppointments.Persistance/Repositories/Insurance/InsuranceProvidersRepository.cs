﻿using MedicalAppointments.Domain.Entities.Insurance;
using MedicalAppointments.Domain.Result;
using MedicalAppointments.Persistance.Base;
using MedicalAppointments.Persistance.Context;
using MedicalAppointments.Persistance.Interfaces.Insurance;
using MedicalAppointments.Persistance.Models;
using MedicalAppointments.Persistance.Models.Insurance;
using MedicalAppointments.Persistance.Validators.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalAppointments.Persistance.Repositories.Insurance
{
    public class InsuranceProvidersRepository : BaseRepository<InsuranceProviders>, IInsuranceProvidersRepository
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private readonly ILogger<InsuranceProvidersRepository> logger;
        private readonly InsuranceProvidersValidator _validator;

        public InsuranceProvidersRepository(MedicalAppointmentContext medicalAppointmentContext, ILogger<InsuranceProvidersRepository> logger, InsuranceProvidersValidator validator) : base(medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            _validator = validator;
            this.logger = logger;
        }

        public async override Task<OperationResult> Save(InsuranceProviders entity)
        {
            OperationResult operationResult = new();

            _validator.ValidateNull(entity);
            _validator.ValidateSave(entity);

            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;

                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "There was an error saving the Insurance Provider.";
                this.logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
        public async override Task<OperationResult> Update(int id, InsuranceProviders entity)
        {
            OperationResult operationResult = new();

            _validator.ValidateNull(entity);
            _validator.ValidateUpdate(id, entity);

            try
            {
                InsuranceProviders? insuranceProvidersToUpdate = await _medicalAppointmentContext.InsuranceProviders.FindAsync(id);
                insuranceProvidersToUpdate.Name = entity.Name;
                insuranceProvidersToUpdate.ContactNumber = entity.ContactNumber;
                insuranceProvidersToUpdate.Email = entity.Email;
                insuranceProvidersToUpdate.Website = entity.Website;
                insuranceProvidersToUpdate.Address = entity.Address;
                insuranceProvidersToUpdate.City = entity.City;
                insuranceProvidersToUpdate.State = entity.State;
                insuranceProvidersToUpdate.Country = entity.Country;
                insuranceProvidersToUpdate.ZipCode = entity.ZipCode;
                insuranceProvidersToUpdate.CoverageDetails = entity.CoverageDetails;
                insuranceProvidersToUpdate.LogoUrl = entity.LogoUrl;
                insuranceProvidersToUpdate.IsPreferred = entity.IsPreferred;
                insuranceProvidersToUpdate.NetworkTypeID = entity.NetworkTypeID;
                insuranceProvidersToUpdate.CustomerSupportContact = entity.CustomerSupportContact;
                insuranceProvidersToUpdate.AcceptedRegions = entity.AcceptedRegions;
                insuranceProvidersToUpdate.MaxCoverageAmount = entity.MaxCoverageAmount;
                insuranceProvidersToUpdate.UpdatedAt = DateTime.Now;
                insuranceProvidersToUpdate.IsActive = entity.IsActive;
                insuranceProvidersToUpdate.UpdatedBy = entity.UpdatedBy;

                await _medicalAppointmentContext.SaveChangesAsync();

                operationResult.Success = true;
                operationResult.Message = "The insurance provider was successfully updated!";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "There was an error updating the insurance provider.";
                this.logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

        public async override Task<OperationResult> Remove(int id, InsuranceProviders entity)
        {
            OperationResult operationResult = new();

            _validator.ValidateNull(entity);
            _validator.ValidateRemove(id, entity);

            try
            {
                InsuranceProviders? insuranceProvidersToRemove = await _medicalAppointmentContext.InsuranceProviders.FindAsync(id);
                insuranceProvidersToRemove.IsActive = false;
                insuranceProvidersToRemove.UpdatedAt = DateTime.Now;
                insuranceProvidersToRemove.UpdatedBy = entity.UpdatedBy;

                await _medicalAppointmentContext.SaveChangesAsync();

                operationResult.Success = true;
                operationResult.Message = "The insurance provider was successfully disabled!";
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "There was an error removing the insurance provider.";
                this.logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new();
            try
            {
                operationResult.Data = await (from insuranceProviders in _medicalAppointmentContext.InsuranceProviders
                                              join networkType in _medicalAppointmentContext.NetworkType on insuranceProviders.NetworkTypeID equals networkType.NetworkTypeID
                                              join createdUser in _medicalAppointmentContext.Users on insuranceProviders.CreatedBy equals createdUser.UserID
                                              join updatedUser in _medicalAppointmentContext.Users on insuranceProviders.UpdatedBy equals updatedUser.UserID
                                              where insuranceProviders.IsActive == true
                                              orderby insuranceProviders.CreatedAt descending
                                              select new InsuranceProvidersNetworkTypeModel()
                                              {
                                                  Name = insuranceProviders.Name,
                                                  ContactNumber = insuranceProviders.ContactNumber,
                                                  Email = insuranceProviders.Email,
                                                  Website = insuranceProviders.Website,
                                                  Address = insuranceProviders.Address,
                                                  City = insuranceProviders.City,
                                                  State = insuranceProviders.State,
                                                  Country = insuranceProviders.Country,
                                                  ZipCode = insuranceProviders.ZipCode,
                                                  CoverageDetails = insuranceProviders.CoverageDetails,
                                                  LogoUrl = insuranceProviders.LogoUrl,
                                                  IsPreferred = insuranceProviders.IsPreferred,
                                                  NetworkTypeID = networkType.NetworkTypeID,
                                                  NetworkDescription = networkType.Description,
                                                  CustomerSupportContact = insuranceProviders.CustomerSupportContact,
                                                  AcceptedRegion = insuranceProviders.AcceptedRegions,
                                                  MaxCoverageAmount = insuranceProviders.MaxCoverageAmount,
                                                  CreatdAt = insuranceProviders.CreatedAt,
                                                  UpdatedAt = insuranceProviders.UpdatedAt,
                                                  CreatedBy = createdUser.FirstName + " " + createdUser.LastName,
                                                  UpdatedBy = updatedUser.FirstName + " " + updatedUser.LastName,
                                              }).AsNoTracking()
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "There was an error obtaining the Insurance Providers.";
                this.logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult operationResult = new();
            _validator.ValidateID(id);
            try
            {
                operationResult.Data = await (from insuranceProviders in _medicalAppointmentContext.InsuranceProviders
                                              join networkType in _medicalAppointmentContext.NetworkType on insuranceProviders.NetworkTypeID equals networkType.NetworkTypeID
                                              join createdUser in _medicalAppointmentContext.Users on insuranceProviders.CreatedBy equals createdUser.UserID
                                              join updatedUser in _medicalAppointmentContext.Users on insuranceProviders.UpdatedBy equals updatedUser.UserID
                                              where insuranceProviders.IsActive == true && insuranceProviders.InsuranceProviderID == id
                                              orderby insuranceProviders.CreatedAt descending
                                              select new InsuranceProvidersNetworkTypeModel()
                                              {
                                                  Name = insuranceProviders.Name,
                                                  ContactNumber = insuranceProviders.ContactNumber,
                                                  Email = insuranceProviders.Email,
                                                  Website = insuranceProviders.Website,
                                                  Address = insuranceProviders.Address,
                                                  City = insuranceProviders.City,
                                                  State = insuranceProviders.State,
                                                  Country = insuranceProviders.Country,
                                                  ZipCode = insuranceProviders.ZipCode,
                                                  CoverageDetails = insuranceProviders.CoverageDetails,
                                                  LogoUrl = insuranceProviders.LogoUrl,
                                                  IsPreferred = insuranceProviders.IsPreferred,
                                                  NetworkTypeID = networkType.NetworkTypeID,
                                                  NetworkDescription = networkType.Description,
                                                  CustomerSupportContact = insuranceProviders.CustomerSupportContact,
                                                  AcceptedRegion = insuranceProviders.AcceptedRegions,
                                                  MaxCoverageAmount = insuranceProviders.MaxCoverageAmount,
                                                  CreatdAt = insuranceProviders.CreatedAt,
                                                  UpdatedAt = insuranceProviders.UpdatedAt,
                                                  CreatedBy = createdUser.FirstName + " " + createdUser.LastName,
                                                  UpdatedBy = updatedUser.FirstName + " " + updatedUser.LastName,
                                              }).AsNoTracking()
                                            .ToListAsync();
                operationResult.Data = _validator.ValidateNullData(operationResult.Data);

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "There was an error obtaining the specific Insurance Providers.";
                this.logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;


        }
    }
}
