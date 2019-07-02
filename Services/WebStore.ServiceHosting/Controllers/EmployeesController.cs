using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Models;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeesController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _employeesData;
        public EmployeesController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody]Employee employee)
        {
            _employeesData.AddNew(employee);
        }
        [HttpDelete("id"), ActionName("Delete")]
        public void Delete(int id)
        {
            _employeesData.Delete(id);
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<Employee> GetAll()
        {
            return _employeesData.GetAll();
        }
        [HttpGet("{id}"), ActionName ("Get")]
        public Employee GetById(int id)
        {
            return _employeesData.GetById(id);
        }
        [NonAction]
        public void SaveChanges()
        {
            _employeesData.SaveChanges();
        }
        [HttpPut("{id}"), ActionName("Update")]
        public Employee Update(int id, [FromBody]Employee employee)
        {
            return _employeesData.Update(id, employee);
        }
    }
}