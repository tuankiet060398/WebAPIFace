using Microsoft.AspNetCore.Mvc;
using System;
using TodoApi.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using TodoApi.Service;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private readonly IStudenService studenService;
        private readonly ApplicationDbContext application;
        public TestAPIController (IStudenService studenService, ApplicationDbContext application){
            this.studenService = studenService;
            this.application = application;
        }
        [HttpGet("{id}", Name = "GetTodo")] public ActionResult<Student> GetById(long id) 
        {    
            var item = application.Students.Find(id);     
            if (item == null)    
            {         
                return NotFound();     
            }     
            return item; 
        }
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var studenService1 = studenService;
            return studenService1.getAll();
        }
        [HttpPost]
        public void CreateStudent([FromBody] Student s)
        {
            studenService.CreatedStuden(s);           
        }

    }
}