﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sql_APICRUD.Models;

namespace Sql_APICRUD.Controllers //Methods eklemek,silmek vs
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                              select DepartmentId,DepartmentName from dbo.Department ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            string query = @"
                              Insert into dbo.Department values(@DepartmentName) ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");

        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
                              Update dbo.Department set DepartmentName=@DepartmentName 
                              where DepartmentId=@DepartmentId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Updated Successfully");

        }

        [HttpDelete ("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                              Delete from dbo.Department 
                              where DepartmentId=@DepartmentId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Deleted Successfully");

        }
    }
}
