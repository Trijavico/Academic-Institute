using Microsoft.Extensions.Logging;
using Institute.DAL.Interfaces;
using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dtos;
using Institute.BLL.Models;
using Institute.BLL.Responses;
using Institute.BLL.Validations;
using System;
using System.Linq;

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

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Student student = studentRepository.GetEntity(Id);

                StudentModel model = new StudentModel()
                {
                    EnrollmentDate = student.EnrollmentDate.Value,
                    EnrollmentDateDisplay = student.EnrollmentDate.Value.ToString("dd/mm/yyyy"),
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
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var students = studentRepository.GetEntities();

                result.Data = students.Select(st => new Models.StudentModel()
                {
                    Id = st.Id,
                    EnrollmentDate = st.EnrollmentDate.Value,
                    EnrollmentDateDisplay = st.EnrollmentDate.Value.ToString("dd/mm/yyyy"),
                    FirstName = st.FirstName,
                    LastName = st.LastName
                }).ToList();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtiendo los estudiantes";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetStudentsGrades()
        {
            throw new System.NotImplementedException();
        }
        public ServiceResult RemoveStudent(StudentRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Student studentToRemove = studentRepository.GetEntity(removeDto.Id); 

                studentToRemove.Id = removeDto.Id;
                studentToRemove.UserDeleted = removeDto.UserDeleted;
                studentToRemove.Deleted = true;
                studentToRemove.DeletedDate = DateTime.Now;

                studentRepository.Remove(studentToRemove);

                result.Message = "Estudiante eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el estudiante";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }
        public StudentSaveResponse SaveStudent(StudentSaveDto studentSaveDto)
        {
            StudentSaveResponse result = new StudentSaveResponse();

            try
            {
                

                var resutlIsValid = ValidationsPerson.IsValidPerson(studentSaveDto);

                if (resutlIsValid.Success)
                {
                    if (studentSaveDto.EnrollmentDate.HasValue)
                    {
                        
                        if (studentRepository.Exists(st => st.FirstName == studentSaveDto.FirstName
                                                        && st.LastName == studentSaveDto.LastName
                                                        && st.EnrollmentDate.Value.Date == studentSaveDto.EnrollmentDate.Value.Date
                                                        ))
                        {
                            result.Success = false;
                            result.Message = "Este estudiante ya se encuentra registrado.";
                            return result;
                        }

                        DAL.Entities.Student studentToAdd = new DAL.Entities.Student()
                        {
                            LastName = studentSaveDto.LastName,
                            EnrollmentDate = studentSaveDto.EnrollmentDate,
                            FirstName = studentSaveDto.FirstName,
                            CreationDate = DateTime.Now,
                            CreationUser = studentSaveDto.UserId
                        };

                        studentRepository.Save(studentToAdd);

                        result.Matricula = studentToAdd.Id.ToString();

                        result.Message = "Estudiante agregado correctamente";

                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "La fecha de inscripci?n es requerida.";
                        return result;
                    }
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
        public StudentUpdateResponse UpdateStudent(StudentUpdateDto studentSaveDto)
        {
            StudentUpdateResponse result = new StudentUpdateResponse();

            try
            {
                

                var resultIsValid = ValidationsPerson.IsValidPerson(studentSaveDto);

                if (resultIsValid.Success)
                {

                    if (studentSaveDto.EnrollmentDate.HasValue)
                    {
                        DAL.Entities.Student studentToUpdate = studentRepository.GetEntity(studentSaveDto.Id); 

                        studentToUpdate.FirstName = studentSaveDto.FirstName;
                        studentToUpdate.LastName = studentSaveDto.LastName;
                        studentToUpdate.EnrollmentDate = studentSaveDto.EnrollmentDate;
                        studentToUpdate.ModifyDate = DateTime.Now;
                        studentToUpdate.UserMod = studentSaveDto.UserId;
                        studentToUpdate.Id = studentSaveDto.Id;

                        studentRepository.Update(studentToUpdate);

                        result.Message = "Estudiante actualizado correctamente";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "La fecha de inscripci?n es requerida.";
                        return result;
                    }

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
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }

            return result;

        }

    }
}