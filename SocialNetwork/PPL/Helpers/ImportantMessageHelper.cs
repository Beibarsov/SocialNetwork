using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PPL.Helpers
{
    public static class ImportantMessageHelper
    {
        public static void AlertMessageWriteLine(string message)
        {
            var consoleOriginalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = consoleOriginalColor;
        }

        public static void NoticeMessageWriteLine(string message)
        {
            var consoleOriginalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = consoleOriginalColor;
        }

        public static void SuccessMessageWriteLine(string message)
        {
            var consoleOriginalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = consoleOriginalColor;
        }
    }
}
