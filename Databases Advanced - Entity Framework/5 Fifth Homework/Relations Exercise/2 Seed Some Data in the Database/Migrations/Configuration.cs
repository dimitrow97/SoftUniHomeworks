namespace _2_Seed_Some_Data_in_the_Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2_Seed_Some_Data_in_the_Database.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;            
        }

        protected override void Seed(_2_Seed_Some_Data_in_the_Database.StudentContext context)
        {
            DateTime date = new DateTime(2015, 1, 20);
            Student mitko = new Student();
            mitko.Name = "Mitko";
            mitko.RegistrationDate = date;
            mitko.BirthDay = date;

            Student pesho = new Student();
            pesho.Name = "Pesho";
            pesho.RegistrationDate = date;
            pesho.BirthDay = date;

            Student ivan = new Student();
            ivan.Name = "Ivan";
            ivan.RegistrationDate = date;
            ivan.BirthDay = date;

            Resource organichna = new Resource();
            organichna.Name = "Organichna himiq";
            organichna.ResourcesType = ResourceType.Presentation;
            organichna.URL = "aeaeqweqeqw.com";

            Homework domashno = new Homework();
            domashno.Content = "Uravneniq";
            domashno.ContextsType = ContentType.pdf;
            domashno.SubmissionDate = date;

            domashno.Student = ivan;

            Course himiq = new Course();
            himiq.Name = "Himiq";
            himiq.StartDate = date;
            himiq.EndDate = date;
            himiq.Price = 200M;
            himiq.Students.Add(mitko);
            himiq.Students.Add(pesho);
            himiq.Students.Add(ivan);
            himiq.Resources.Add(organichna);
            himiq.Homeworks.Add(domashno);

            context.Students.AddOrUpdate(s => s.Name, ivan);
            context.Students.AddOrUpdate(s => s.Name, mitko);
            context.Students.AddOrUpdate(s => s.Name, pesho);

            context.Resources.AddOrUpdate(r => r.Name, organichna);

            context.Homeworks.AddOrUpdate(h => h.Content, domashno);
            
            context.Courses.AddOrUpdate(c => c.Name, himiq);

            context.SaveChanges();
        }
    }
}
