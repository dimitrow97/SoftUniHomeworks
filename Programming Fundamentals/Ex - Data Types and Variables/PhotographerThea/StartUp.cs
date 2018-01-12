namespace PhotographerThea
{
    using System;

    class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfPictures = int.Parse(Console.ReadLine());
            var filterTime = int.Parse(Console.ReadLine());
            var filterFactor = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());

            var filteredPictures = (long)Math.Ceiling(numberOfPictures * ((double)filterFactor / 100));
            var totalFilterTime = (long)numberOfPictures * filterTime;
            var totalUploadTime = filteredPictures * uploadTime;

            var resultInSecond = totalUploadTime + totalFilterTime;

            Console.WriteLine(ConvertSecondsToDate(resultInSecond));
        }

        private static string ConvertSecondsToDate(double seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(seconds));            
            return t.ToString(@"d\:hh\:mm\:ss");
        }
    }
}
