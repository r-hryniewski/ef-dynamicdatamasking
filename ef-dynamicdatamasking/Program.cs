using System;
using System.Linq;

namespace ef_dynamicdatamasking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Before running this demo execute sample_azuresql.sql (follow instructions in comments), it was tested on Azure SQL at 28-03-2017
            //After that fill in two connection strings in app.config with your connection data. 
            //After executing mentioned .sql file MaskedModel connection string should use provided user and password, for UnmaskedModel connection string you should provide you own user and password for identity with admin privileges and/or UNMASK permissions (statement to grant them are line bellow, it should be used in scope of database)
            //GRANT UNMASK TO username
            //GO

            using (var dbContext = new UnmaskedModel())
            {
                var persons = dbContext.People.AsNoTracking().ToList();

                foreach (var person in persons)
                {
                    Console.WriteLine($"Unmasked - Name: {person.Name} LastName: {person.LastName} Date of Birth: {person.DateOfBirth} Rating: {person.Rating}");
                }
            }

            using (var dbContext = new MaskedModel())
            {
                var persons = dbContext.People.AsNoTracking().ToList();

                foreach (var person in persons)
                {
                    Console.WriteLine($"Masked - Name: {person.Name} LastName: {person.LastName} Date of Birth: {person.DateOfBirth} Rating: {person.Rating}");
                }
            }
            Console.ReadKey();
        }
    }
}
