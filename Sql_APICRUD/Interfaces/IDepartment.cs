using Sql_APICRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sql_APICRUD.Interfaces
{
    interface IDepartment
    {
        List<Department> GetDepartments();

        Department AddTraveller(Department dep);

        void DeleteTraveller(Department dep);

        Department EditTraveller(Department dep);
    }
}
