using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModel
{
    public class UsersViewModel
    {
        public UsersViewModel(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
