using Microsoft.Extensions.Logging;
using Institute.DAL.Interfaces;
using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Validations;
using Institute.DAL.Entities;

namespace Institute.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<StudentService> logger;
        public StudentService(IStudentRepository studentRepository,
                              ILogger<StudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
        }

        public ServiceResult<StudentDTO> GetById(int Id)
        {
            var result = new ServiceResult<StudentDTO>();

            try
            {
                Student student = studentRepository.GetEntity(Id);

                StudentDTO model = new StudentDTO()
                {
                    EnrollmentDate = student.EnrollmentDate,
                    EnrollmentDateDisplay = student.EnrollmentDate.ToString("dd/mm/yyyy"),
                    FirstName = student.FirstName,
                    Id = student.Id,
                    LastName = student.LastName
                };

                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el estudiante del Id.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public ServiceResult<IEnumerable<StudentDTO>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<StudentDTO>>();

            try
            {
                var students = studentRepository.GetEntities();

                result.Data = students.Select(st => new StudentDTO()
                {
                    Id = st.Id,
                    EnrollmentDate = st.EnrollmentDate,
                    EnrollmentDateDisplay = st.EnrollmentDate.ToString("dd/mm/yyyy"),
                    FirstName = st.FirstName,
                    LastName = st.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los estudiantes";
                logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        

        public ServiceResult<StudentDTO> RemoveStudent(StudentDTO studentReceived)
        {
            var result = new ServiceResult<StudentDTO>();

            try
            {
                Student studentToRemove = studentRepository.GetEntity(studentReceived.Id); 

                studentToRemove.Id = studentReceived.Id;
                studentToRemove.UserDeleted = true;
                studentToRemove.Deleted = true;
                studentToRemove.DeletedDate = DateTime.Now;

                studentRepository.Remove(studentToRemove);

                result.Message = "Estudiante eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult<StudentDTO> SaveStudent(StudentDTO studentReceived)
        {
            var result = new ServiceResult<StudentDTO>();

            try
            {
                var resutlIsValid = ValidationsPerson.IsValidPerson(studentReceived);

                if (resutlIsValid.Success)
                {
                    if (studentRepository
                        .Exists(st => st.FirstName == studentReceived.FirstName
                                        && st.LastName == studentReceived.LastName
                                        && st.EnrollmentDate.Date == studentReceived.EnrollmentDate.Date
                        ))
                    {
                        result.Success = false;
                        result.Message = "Este estudiante ya se encuentra registrado.";
                        return result;
                    }

                    Student studentToSave = new Student()
                    {
                        LastName = studentReceived.LastName,
                        EnrollmentDate = studentReceived.EnrollmentDate,
                        FirstName = studentReceived.FirstName,
                        CreationDate = DateTime.Now,
                        CreationUser = studentReceived.Id
                    };

                    studentRepository.Save(studentToSave);
                    result.Message = "Estudiante agregado correctamente";
                }
                else
                {
                    result.Success = resutlIsValid.Success;
                    result.Message = resutlIsValid.Message;
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult<StudentDTO> UpdateStudent(StudentDTO studenReceived)
        {
            var result = new ServiceResult<StudentDTO>();

            try
            {
                var resultIsValid = ValidationsPerson.IsValidPerson(studenReceived);

                if (resultIsValid.Success)
                {
                    Student studentToUpdate = studentRepository.GetEntity(studenReceived.Id); 

                    studentToUpdate.FirstName = studenReceived.FirstName;
                    studentToUpdate.LastName = studenReceived.LastName;
                    studentToUpdate.EnrollmentDate = studenReceived.EnrollmentDate;
                    studentToUpdate.ModifyDate = DateTime.Now;
                    studentToUpdate.UserMod = studenReceived.Id;
                    studentToUpdate.Id = studenReceived.Id;

                    studentRepository.Update(studentToUpdate);

                    result.Message = "Estudiante actualizado correctamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = resultIsValid.Message;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el estudiante";
                logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }

    }
}