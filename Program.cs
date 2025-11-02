namespace ServicesManagerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var x = FrancoConverter.ConvertArabicToFranco("اهلا كيف حالك").ToUpper();

       ////     File.AppendAllText("addresses.txt",x+"\n \n");

            Console.WriteLine("Hello, World!");
        }
    }
}
