using System;
using System.Collections.Generic;
using TodoApi.Entities;

namespace TodoApi.Service
{
    public interface IStudenService
    {
        void CreatedStuden(Student s);
        List<Student> getAll();
    }
}