using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.Interface
{
    public interface IUserBL
    {
        Task AddPerson(string firstName, string lastName);
        IEnumerable<string> GetPeopleData();
    }
}
