
using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Responses;
using Institute.BLL.Validations;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Institute.BLL.Validations;
using Institute.DAL.Entities.Production;

namespace Institute.BLL.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository professorRepository;
        private readonly ILogger<ProfessorService> logger;

        public ProfessorService(IProfessorRepository professorRepository,
                              ILogger<ProfessorService> logger)
        {
            this.professorRepository = professorRepository;
            this.logger = logger;
        }



        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professors = professorRepository.GetEntities();

                result.Data = professors.Select(st => new Models.ProfessorModel()
                {
                    Id = st.Id,
                    HireDate = st.HireDate,
                    FirstName = st.FirstName,
                    LastName = st.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los profesores";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professor = professorRepository.GetEntity(Id);

                result.Data = new Models.ProfessorModel()
                {
                    Id = professor.Id,
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    HireDate = professor.HireDate
                };

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo el profesor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ServiceResult RemoveProfessor(ProfessorRemoveDto professorRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var professorToRemove = professorRepository.GetEntity(professorRemoveDto.Id);

                professorToRemove.Id = professorRemoveDto.Id;
                professorToRemove.UserDeleted = true;
                professorToRemove.Deleted = true;
                professorToRemove.DeletedDate = DateTime.Now;

                professorRepository.Remove(professorToRemove);

                result.Message = "Profesor eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el profesor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ProfessorResponse SaveProfessor(ProfessorSaveDto professorSaveDto)
        {
            ProfessorResponse result = new ProfessorResponse();

            result = (ProfessorResponse)ValidationsProfessor.IsValidProfessor(professorSaveDto, professorRepository);
            
            if (result.Success)
            {
                DAL.Entities.Production.Professor professorToAdd = new DAL.Entities.Production.Professor()
                {
                    LastName = professorSaveDto.LastName,
                    HireDate = (DateTime)professorSaveDto.HireDate,
                    FirstName = professorSaveDto.FirstName,
                    CreationDate = DateTime.Now,
                    CreationUser = professorSaveDto.UserId
                };

                professorRepository.Save(professorToAdd);

                result.ProfessorId = professorToAdd.Id;

                result.Message = "Profesor agregado correctamente";

            }

            return result;
        }



        public ProfessorUpdateResponse UpdateProfessor(ProfessorUpdateDto professorUpdateDto)
        {
            ProfessorUpdateResponse result = new ProfessorUpdateResponse();

            result = (ProfessorUpdateResponse)ValidationsProfessor.IsValidProfessor(professorUpdateDto, professorRepository);

            try
            {
                var professorToUpdate = professorRepository.GetEntity(professorUpdateDto.ProfessorId);

                professorToUpdate.FirstName = professorUpdateDto.FirstName;
                professorToUpdate.LastName = professorUpdateDto.LastName;
                professorToUpdate.HireDate = (DateTime)professorUpdateDto.HireDate;
                professorToUpdate.ModifyDate = DateTime.Now;
                professorToUpdate.UserMod = professorUpdateDto.UserId;
                professorToUpdate.Id = professorUpdateDto.ProfessorId;

                professorRepository.Update(professorToUpdate);

                result.Message = "Profesor actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el profesor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }


    }
}
