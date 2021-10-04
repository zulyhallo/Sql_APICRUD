using Sql_APICRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sql_APICRUD.Interfaces
{
    interface ITraveller
    {
        List<Traveller> GetTravellers();

        Traveller AddTraveller(Traveller trav);

        void DeleteTraveller(Traveller trav);

        Traveller EditTraveller(Traveller trav);


    }
}
