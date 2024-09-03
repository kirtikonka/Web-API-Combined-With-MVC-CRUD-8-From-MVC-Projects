﻿using Microsoft.AspNetCore.Http;
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
            return Ok("Edited Successfully");
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
            return Ok("Deleted Successfully");
        }
    }
}