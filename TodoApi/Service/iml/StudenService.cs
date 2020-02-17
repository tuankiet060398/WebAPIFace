using TodoApi.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TodoApi.Repositories;

namespace TodoApi.Service.iml
{
    public class StudenService : IStudenService
    {
        private readonly StudenRepository studentRepository;

        public StudenService(StudenRepository studentRepository){
            this.studentRepository = studentRepository;
        }

        public void CreatedStuden(Student s)
        {
            studentRepository.Add(s);
            studentRepository.SaveChanges();
        }

        public List<Student> getAll()
        {
            return studentRepository.GetAll().ToList();          
        }
    }
}