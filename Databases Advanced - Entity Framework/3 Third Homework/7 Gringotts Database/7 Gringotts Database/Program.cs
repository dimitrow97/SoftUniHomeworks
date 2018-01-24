using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Gringotts_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new GringottsContext();
            ctx.Database.Initialize(true);

            ctx.Deposits.Add(new WizardDeposits()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 200,
                DepositCharge = 0.2m,
                IsDepositExpired = false,
            });
            ctx.SaveChanges();

        }
    }
}
