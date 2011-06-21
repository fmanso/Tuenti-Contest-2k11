using System;
using System.Collections.Generic;
using System.Linq;

namespace C10_KeyCombos
{
    class Program
    {
        static void Main()
        {
            List<String[]> combos = new List<string[]>();
            List<String> commands = new List<string>();
            var numberOfKeyCombos = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfKeyCombos; i++)
            {
                var combo = Console.ReadLine();                
                var command = Console.ReadLine().Trim();                
                combos.Add(combo.Split(' '));
                commands.Add(command);
            }
            var numberOfTestCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                var combo = Console.ReadLine();
                Console.WriteLine(GetCommand(combo.Split(' '), combos, commands));
            }
        }

        private static string GetCommand(string[] split, List<string[]> combos, List<string> commands)
        {
            for (int i = 0; i < combos.Count; i++)
            {
                bool found = true;
                foreach (var key in split)
                {
                    if (!combos[i].Contains(key))
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return commands[i];
            }
            return null;
        }
    }
}
