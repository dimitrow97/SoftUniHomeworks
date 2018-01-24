using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Oldest_Family_Member
{
    class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.familyMembers.OrderByDescending(w => w.Age).FirstOrDefault();
        }

        public List<Person>FamilyMmembers
        {
            get
            {
                return this.familyMembers;
            }
        }
    }
}
