using System;
using System.Collections.Generic;
using System.Text;

namespace Travel_Agency
{
    class Client
    {
       public string name;
       public string sname;
       public string phone;
       public string email;

       public  Client(string name , string sname , string phone , string email)
        {
            this.name = name;
            this.sname = sname;
            this.phone = phone;
            this.email = email;        
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {name}   Фамилия: {sname}   Номер телефона: {phone}   Email : {email}");
        }




    }



}
