using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyLogic.CLI
{
    public class MyConsole
    {
        public void AddKeyHandler(ConsoleKey key, Action handler) => _keysHandlers.Add(key, handler);

        public string ReadLine()
        {
            sb.Clear();
            var ch = Console.ReadKey(true);

            while (ch.Key != ConsoleKey.Enter)
            {
                if (_keysHandlers.ContainsKey(ch.Key))
                    _keysHandlers[ch.Key].Invoke();
                else if (ch.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        --sb.Length;
                        Console.Write("\b \b");
                    }
                }
                else if (ch.KeyChar != '\0')
                {
                    sb.Append(ch.KeyChar);
                    Console.Write(ch.KeyChar);
                }
                ch = Console.ReadKey(true);
            }
            Console.WriteLine();

            return sb.ToString();
        }

        public string GetCurrentLine() => sb.ToString();

        public void SetCurrentLine(string line)
        {
            sb.Clear();
            sb.Append(line);
        }


        StringBuilder sb = new StringBuilder();
        private Dictionary<ConsoleKey, Action> _keysHandlers = new Dictionary<ConsoleKey, Action>();
    }
}