using DatabaseAccessClass.DataAccess;
using DatabaseAccessClass.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessClass.Logic
{
    public class PersonCRUD
    {
        public static List<Person> GetAllPeople()
        {
            string sql = "select * from dbo.Persons";
            return SQLDataAccess.LoadData<Person>(sql);
        }
        public static void InsertPerson(string Name, string Email, int Age, string Password ,string Country)
        {
            DateTime dateTime = DateTime.Now;

            string formatted = string.Format(CultureInfo.InvariantCulture, "{0:fffff}", dateTime);

            Person person = new Person
            {
                Id = Convert.ToInt32(formatted),
                Name = Name,
                Email = Email,
                Age = Age,
                Password = Password,
                Country = Country
            };


            string sql = @"insert into dbo.Persons (Id, Name, Email, Age, Password, Country)
                           values (@Id ,@Name, @Email, @Age, @Password, @Country)";
            SQLDataAccess.SaveData(sql, person);
        }
        public static void UpdatePerson(Person person)
        {
            string sql = @"update dbo.Persons
                           set Name = @Name, Email = @Email, Age = @Age, Password = @Password, Country = @Country
                           where Id = @Id";
            SQLDataAccess.SaveData(sql, person);
        }
        public static void DeletePerson(Person person)
        {
            string sql = @"delete from dbo.Persons
                           where Id = @Id";
            SQLDataAccess.SaveData(sql, person);
        }
    }
}
