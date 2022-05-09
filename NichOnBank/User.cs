using System;
using System.Collections.Generic;
using System.Text;

namespace NichOnBank
{
    class User
    {
        public int ID { get; set; }
        public string UFName { get; set; }
        public string ULName { get; set; }
        public DateTime DOT { get; set; }

        public User()
        {

        }

        public User(int uId, string uFirstName, string uLastName, DateTime uDateOfBirth)
        {
            this.ID = uId;
            this.UFName = uFirstName;
            this.ULName = uLastName;
            this.DOT = uDateOfBirth;
        }

        public void PrintUserDetails()
        {
            Console.WriteLine($"User ID: {this.ID}");
            Console.WriteLine($"User First Name: {this.UFName}");
            Console.WriteLine($"User Last Name: {this.ULName}");
            Console.WriteLine($"User Date of Birth: {this.DOT.ToString("dd-MMM-yyyy")}");
        }
    }
}
