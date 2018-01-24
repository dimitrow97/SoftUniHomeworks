using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // 19.Deposits Sum for Ollivander Family
            //DepositSumForOllivanderFamily();

            // 20.Deposits Filter
            //DepositFilter();
        }

        public static void DepositFilter()
        {
            GringottsContext context = new GringottsContext();

            const decimal lowestAmount = 150000m;
            Dictionary<string, decimal?> filteredDepositGroups = new Dictionary<string, decimal?>();
            foreach (var group in context.WizzardDeposits.Select(x => x.DepositGroup).Distinct())
            {
                filteredDepositGroups[group] = context.WizzardDeposits.Where(x => x.DepositGroup == group).Where(w => w.MagicWandCreator == "Ollivander family").Sum(x => x.DepositAmount);
            }

            foreach (var filteredDepositGroup in filteredDepositGroups.Where(g => g.Value < lowestAmount).OrderByDescending(g => g.Value))
            {
                Console.WriteLine($"{filteredDepositGroup.Key} - {filteredDepositGroup.Value}");
            }
        }

        public static void DepositSumForOllivanderFamily()
        {
            GringottsContext context = new GringottsContext();

            foreach (var group in context.WizzardDeposits.Select(x => x.DepositGroup).Distinct())
            {
                Console.WriteLine($"{group} {context.WizzardDeposits.Where(x => x.DepositGroup == group).Where(w => w.MagicWandCreator == "Ollivander family").Sum(x => x.DepositAmount)}");
            }
        }
    }
}
