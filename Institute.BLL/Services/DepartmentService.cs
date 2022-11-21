using Institute.BLL.Contracts;
using Institute.BLL.Models;
using Institute.BLL.Core;
using Institute.BLL.Dtos;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using System;

namespace Institute.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository departmentRespository;
        private readonly ILoggerService<DepartmentService> loggerService;

        public DepartmentService(DepartmentRepository departmentRepository,
                              ILoggerService<DepartmentService> loggerService
                              )
        {
            this.departmentRespository = departmentRepository;
            this.loggerService = loggerService;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.departmentRespository.GetEntity(Id);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el departamento";
                this.loggerService.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public DepartmentRepository GetDepartmentRespository()
        {
            return departmentRespository;
        }

        public ServiceResult GetAll(DepartmentRepository departmentRepository)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from Department in this.departmentRespository.GetEntities()
                             join depto in this.departmentRespository.GetEntities() on Department.DepartmentID equals depto.DepartmentID
                             select new Models.DepartmentModel()
                             {
                                 Credits = department.Credits,
                                 Department = department.Name,
                                 Id = department.DepartmentID,
                                 Title = department.Title
                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los departamentos";
                this.loggerService.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public ServiceResult SaveDepartment(SaveDepartmentDto saveDepartmentDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Department department = new Department()
                {
                    Credits = saveDepartmentDto.Credits,
                    Title = saveDepartmentDto.Title,
                    DepartmentId = saveDepartmentDto.DepartmentId
                };
            }
            catch (Exception ex)
            {
                result.Message = $"Error guardando el departamento {ex.Message}";
                this.loggerService.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult UpdateDepartment(UpdateDepartmentDto studentSaveDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveDepartment(SaveDepartmentDto saveDepartmentDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult UpdateDepartment(UpdateDepartmentDto saveDepartmentDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            throw new NotImplementedException();
        }
    }
}