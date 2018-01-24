namespace _5_Photographers
{
    using Models;
    class StartUp
    {
        static void Main(string[] args)
        {
            PhotoContext context = new PhotoContext();

            Photographer pesho = new Photographer()
            {
                Username = "Pesho",
                Password = "123456pesho",
                RegisterDate = new System.DateTime(2017, 3, 12),
                BirthDate = new System.DateTime(1997, 4, 1)
            };

            Photographer ivailo = new Photographer()
            {
                Username = "IvoAndonov",
                Password = "SamrtZaDjaro",
                RegisterDate = new System.DateTime(2017, 3, 12),
                BirthDate = new System.DateTime(1987, 5, 3)
            };

            Photographer mitko = new Photographer()
            {
                Username = "Mitaka",
                Password = "MitakaBaby",
                RegisterDate = new System.DateTime(2017, 3, 12),
                BirthDate = new System.DateTime(1995, 9, 15)
            };

            context.Photographers.Add(mitko);
            context.Photographers.Add(ivailo);
            context.Photographers.Add(pesho);
            context.SaveChanges();
        }
    }
}
