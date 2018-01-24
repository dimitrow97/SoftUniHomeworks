using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Gringotts_Database
{
    public class WizardDeposits
    {
        private string firstName;
        private string lastName;
        private string notes;
        private int age;
        private string magicWandCreator;
        private int magicWandSize;
        private string depositGroup;

        public int Id { get; set; }
        public string FirstName {
            get
            {
                return this.firstName;
            }
            set
            {
                this.ValidateStringLength(value, 50);
                this.firstName = value;
            }
        }        
        public string LastName {
            get
            {
                return this.lastName;
            }
            set
            {
                ValidateStringLength(value, 60);
                this.lastName = value;
            }
        }
        public string Notes
        {             
            get
            {
                return this.notes;
            }
            set
            {
                ValidateStringLength(value, 1000);
                this.notes = value;
            }
        }        
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Negative!");
                this.age = value;
            }                        
        }
        public string MagicWandreator
        {
            get
            {
                return this.magicWandCreator;
            }
            set
            {
                ValidateStringLength(value, 100);
                this.magicWandCreator = value;
            }
        }
        public int MagicWandSize
        {
            get
            {
                return this.magicWandSize;
            }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Must be more than 1!");
                this.magicWandSize = value;
            }
        }
        public string DepositGroup
        {
            get
            {
                return this.depositGroup;
            }
            set
            {
                ValidateStringLength(value, 20);
                this.depositGroup = value;
            }
        }
        public DateTime DepositStartDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public decimal DepositCharge { get; set; }
        public DateTime DepositExpirationDate { get; set; }
        public bool IsDepositExpired { get; set; }

        private void ValidateStringLength(string value, int max)
        {
            if (value.Length > max)
                throw new ArgumentException("Value exceeds max length!");
        }
    }
}
