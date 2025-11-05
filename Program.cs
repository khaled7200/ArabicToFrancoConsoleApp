namespace ServicesManagerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File.Delete("output.txt");
            }
            catch (Exception)
            {

            }
        

            var str = File.ReadAllText("addresses.txt");

            var lines=str.Split('\n');

            lines = lines.Where(y =>!string.IsNullOrEmpty(y)).ToArray();
            foreach (var line in lines) {
            
                var x = FrancoConverter.ConvertArabicToFranco(line.ToString()).ToUpper();

           File.AppendAllText("output.txt",x+"\n \n");

            Console.WriteLine(x);
            }

        


            Console.WriteLine("----------DONE----------------");
            Console.ReadLine();
        }
    }
}
