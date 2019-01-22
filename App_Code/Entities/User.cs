using System;
using System.Collections.Generic;
using System.Web;

public class User
{
       public int id {get; set;}
       public string name {get; set;}
       public string password {get; set;}
       public string email {get; set;}
       public string type {get; set;}

       public User(int id, string name, string password, string email, string type)
       {
           this.id=id;
           this.name = name;
           this.password=password;
           this.email=email;
           this.type=type;
       }

       public User(string name, string password, string email, string type)
       {
           this.name = name;
           this.password = password;
           this.email = email;
           this.type = type;
       }

}