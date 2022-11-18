namespace InternalMeeting.Repository
{
    public static class ConsoleMsg
    {
        public static void WrongInputMsg()
        {
            Console.WriteLine("Wrong input! press any key to continue");
            Console.ReadKey();
        }
        public static void EmptyInputMsg()
        {
            Console.WriteLine("Input must be not empty! press any key to continue");
            Console.ReadKey();
        }
        public static void ContinueMsg()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void BackToPreviouslyWindowMsg(int commandNumber)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{commandNumber} - Go back to previous window");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
