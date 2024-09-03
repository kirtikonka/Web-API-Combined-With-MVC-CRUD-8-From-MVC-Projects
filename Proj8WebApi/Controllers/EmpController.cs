using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj8WebApi.Data;
using Proj8WebApi.Models;

namespace Proj8WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddNewEmp(Emp e)
        {
            db.employees.Add(e);
            db.SaveChanges();
            return Ok("Employee Added Successfully");
        }

        [Route("GetEmp")]
        [HttpGet]
        public IActionResult GetAllEmpData()
        {
            var d=db.employees.ToList();
            return Ok(d);
        }

        [Route("EditEmp/{id}")]
        [HttpGet]
        public IActionResult EditEmpData(int id)
        {
            var data = db.employees.Find(id);
            if (data != null)
            {

                db.employees.Update(data);
                db.SaveChanges();
            }
            return Ok("Emp Edited Successfully");
        }

        [Route("DelEmp/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmpData(int id)
        {
            var data = db.employees.Find(id);
            if (data != null)
            {
                db.employees.Remove(data);
                db.SaveChanges();
            }
            return Ok("Emp Deleted Successfully");
        }

        [Route("UpdEmp")]
        [HttpPut]
        public IActionResult UpdateEmpData(Emp e)
        {
            db.employees.Update(e);
            db.SaveChanges();
            return Ok("Emp Updated Successfully");
        }

        [Route("AddMultiple")]
        [HttpPost]
        public IActionResult AddMultipeEmp(List<Emp> emps)
        {
            db.employees.AddRange(emps);
            db.SaveChanges();
            return Ok("Multiple Employees Added Successfully");
        }

        [Route("DelMultiple")]
        [HttpDelete]
        public IActionResult DelMultipleEmp([FromForm]List<int> ids)
        {
            var data = db.employees.Where(x=>ids.Contains(x.Id)).ToList();
            db.employees.RemoveRange(data);
            db.SaveChanges();
            return Ok("Multiple Employees Deleted Successfully");
        }

        [Route("SearchBy")]
        [HttpGet]
        public IActionResult SearchBy(string e)
        {
            var data = db.employees.Where(x=>e.Contains(x.Name)||e.Contains(x.Dept)||e.Contains(x.Salary.ToString())||e.Contains(x.Id.ToString()));
            return Ok(data);
        }
    }
}
