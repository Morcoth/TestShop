﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _Employes = new List<Employee>
        {
            new Employee { Id = 1, SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 25 },
            new Employee { Id = 2, SurName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", Age = 30 },
            new Employee { Id = 3, SurName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", Age = 35 },
        };

        public IEnumerable<Employee> GetAll() => _Employes;

        public Employee GetById(int id) => _Employes.FirstOrDefault(e => e.Id == id);

        public void AddNew(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (_Employes.Contains(employee) || _Employes.Any(e => e.Id == employee.Id)) return;

            employee.Id = _Employes.Count == 0 ? 1 : _Employes.Max(e => e.Id) + 1;
            _Employes.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null) return;
            //if(ReferenceEquals(employee, null)) return;
            _Employes.Remove(employee);
        }

        public void SaveChanges() { }

        public Employee Update(int id, Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            var db_employee = GetById(id);
            if (db_employee is null) throw new InvalidOperationException($"Сотрудник {employee} не найден ");
            db_employee.Age = employee.Age;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.SurName = employee.SurName;
            return db_employee;
        }
    }
}
