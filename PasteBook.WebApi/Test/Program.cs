using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PasteBook.WebApi.Data;
using System;
using System.Linq;

namespace Test
{
    class DB : PasteBookDb
    {   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationHelper.GetInstance().GetProperty<string>("ConnectionString"));
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            DB dB = new DB();
            var users = dB.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine(JsonConvert.SerializeObject(user));
            }
        }
    }
}
