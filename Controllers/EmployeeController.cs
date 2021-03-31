using HRApp.Central;
using HRApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HRApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        

        // GET: EmployeeController/Details/5

        public ActionResult Details (int id)
        {
            Employee e = new Employee();
            using (IDbConnection db = new SqlConnection(Global.ConnectionString))
            {
                e = db.Query<Employee>($"SELECT * From Employees WHERE ID = " + id, new { id }).SingleOrDefault();

                return View(e);



            }
        }
        
        [HttpGet]
        public ActionResult EditForm(int id)
        {
            Console.WriteLine("We reach here");
            
            //List<Employee> employees = new List<Employee>();
            Employee e = new Employee();
            using (IDbConnection db = new SqlConnection(Global.ConnectionString))
            {
                e = db.Query<Employee>($"SELECT * From Employees WHERE ID = " + id, new { id }).SingleOrDefault();
               
                return View(e);
                


            }
        }

        // GET: EmployeeController/Create
        [HttpGet]
        public ActionResult CreateForm()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {   
            try
            { 
                using (IDbConnection db = new SqlConnection(Global.ConnectionString))
                {
                    string sqlQuery = $"INSERT INTO Employees (FirstName, LastName, MiddleName, Age, GradeLevel, JobTitle) VALUES ( '{employee.FirstName}','{employee.LastName}','{employee.MiddleName}','{employee.Age}','{employee.GradeLevel}','{employee.JobTitle}')";
                      

                    int rowsAffected = db.Execute(sqlQuery);
                    
                }
                return RedirectToAction("Index", "Home");
            
}            catch
            {
                using(IDbConnection db = new SqlConnection(Global.ConnectionString)){
                    
                }
                return View();
            }
        }


        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            
                using (IDbConnection db = new SqlConnection(Global.ConnectionString))
                {/*
                    var p = new DynamicParameters();
                    var sql = "exec [UpdateEmployees] @FirstName, @LastName, @Middlename,@Age, @GradeLevl,@JobTitle @ID";
                    p.Add("@FirstName", employee.FirstName);
                    p.Add("@LastName", employee.LastName);
                    p.Add("@Middlename", employee.MiddleName);
                    p.Add("@Age", employee.Age);
                    p.Add("@GradeLevel", employee.GradeLevel);
                    p.Add("@JobTitle", employee.JobTitle);
                    p.Add("@ID", employee.ID);
                    var result = db.Execute(sql, p);*/
                try {
                    string sqlQuery = "UPDATE Employees set FirstName='" + employee.FirstName +
                        "',LastName='" + employee.LastName +
                        "',MiddleName='" + employee.MiddleName +
                        "',Age='" + employee.Age +
                        "',GradeLevel='" + employee.GradeLevel +
                        "',JobTitle='"+ employee.JobTitle +
                        "' WHERE ID=" + employee.ID;

                    int rowsAffected = db.Execute(sqlQuery);
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return View();
                }
                    
            }
                    
            
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var p = new DynamicParameters();
            int result;
            
            using (IDbConnection db = new SqlConnection(Global.ConnectionString))
            {
                var statement = " exec [DeleteEmployees] @ID";
                p.Add("ID", id );
                
                result= db.Execute(statement, p);
                if (result <= 0) return RedirectToAction("Index","Home");
            }
            return StatusCode(500);
        }

        
    }
}
