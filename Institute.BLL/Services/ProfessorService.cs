using Institute.BLL.Contracts;
using Institute.BLL.Validations;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Institute.DAL.Entities.Production;
using Institute.BLL.Dto;
using Institute.BLL.Core;

namespace Institute.BLL.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly ILogger<ProfessorService> _logger;

        public ProfessorService(IProfessorRepository professorRepository,
                              ILogger<ProfessorService> logger)
        {
            _professorRepository = professorRepository;
            _logger = logger;
        }



        public ServiceResult<IEnumerable<ProfessorDTO>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<ProfessorDTO>>();

            try
            {
                IEnumerable<Professor> professors = _professorRepository.GetEntities();

                result.Data = professors.Select(st => new ProfessorDTO()
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
                _logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ServiceResult<ProfessorDTO> GetById(int Id)
        {
            var result = new ServiceResult<ProfessorDTO>();

            try
            {
                var professor = _professorRepository.GetEntity(Id);

                result.Data = new ProfessorDTO()
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
                _logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ServiceResult<ProfessorDTO> RemoveProfessor(ProfessorDTO professorReceived)
        {
            var result = new ServiceResult<ProfessorDTO>();

            try
            {
                var professorToRemove = _professorRepository.GetEntity(professorReceived.Id);

                professorToRemove.Id = professorReceived.Id;
                professorToRemove.UserDeleted = true;
                professorToRemove.Deleted = true;
                professorToRemove.DeletedDate = DateTime.Now;

                _professorRepository.Remove(professorToRemove);

                result.Message = "Profesor eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el profesor";
                _logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }




        public ServiceResult<ProfessorDTO> SaveProfessor(ProfessorDTO professorReceived)
        {
            var result = new ServiceResult<ProfessorDTO>();

            var isValidProfessorResult = ValidationsProfessor.IsValidProfessor(professorReceived, _professorRepository);
            
            if (isValidProfessorResult.Success)
            {
                Professor professorToAdd = new Professor()
                {
                    LastName = professorReceived.LastName,
                    HireDate = professorReceived.HireDate,
                    FirstName = professorReceived.FirstName,
                    CreationDate = DateTime.Now,
                    CreationUser = professorReceived.Id,
                };

                _professorRepository.Save(professorToAdd);
                result.Message = "Profesor agregado correctamente";

            }

            return result;
        }

        public ServiceResult<ProfessorDTO> UpdateProfessor(ProfessorDTO professorReceived)
        {
            var result = new ServiceResult<ProfessorDTO>();

            result = ValidationsProfessor.IsValidProfessor(professorReceived, _professorRepository);

            try
            {
                Professor professorToUpdate = _professorRepository.GetEntity(professorReceived.Id);

                professorToUpdate.FirstName = professorReceived.FirstName;
                professorToUpdate.LastName = professorReceived.LastName;
                professorToUpdate.HireDate = professorReceived.HireDate;
                professorToUpdate.ModifyDate = DateTime.Now;
                professorToUpdate.UserMod = professorReceived.Id;
                professorToUpdate.Id = professorReceived.Id;

                _professorRepository.Update(professorToUpdate);

                result.Message = "Profesor actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el profesor";
                _logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }


    }
}
