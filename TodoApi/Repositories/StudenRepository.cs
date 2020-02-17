using System.Linq;
using TodoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories
{
    public class StudenRepository : Repository<Student>
    {
        private readonly ApplicationDbContext application;


        public StudenRepository(DbContext dbContext, ApplicationDbContext application) : base(dbContext)
        {
            this.application = application;
        }

    }
}