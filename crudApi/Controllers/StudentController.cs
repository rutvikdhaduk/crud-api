using crudApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace crudApi.Controllers
{

    [Route("Student")]
    [ApiController]
    public class StudentController : Controller
    {
        //public MongoDbContext _db { get; set; }
        public PostgreSqlDbContext _pdb { get; set; }

        //public StudentController(MongoDbContext mongoDbContext, PostgreSqlDbContext postgreSqlDbContext)
        //{
        //    _db = mongoDbContext;
        //    _pdb = postgreSqlDbContext;
        //}

        public StudentController(PostgreSqlDbContext postgreSqlDbContext)
        {
            _pdb = postgreSqlDbContext;
        }

        [HttpGet]
        public List<Student> Students()
        {
            //var res = _db.Students.AsQueryable().ToList();
            var res = _pdb.Students.ToList();
            return res;
        }

        [HttpGet]
        [Route("Other")]
        public List<Student> OtherStudents()
        {
            var res = _pdb.Students.ToList();
            return res;
        }

        [HttpPost]
        public Student AddStudent(Student student)
        {
            //_db.Students.InsertOne(student);
            _pdb.Students.Add(student);
            _pdb.SaveChanges();
            return student;
        }
    }
}
