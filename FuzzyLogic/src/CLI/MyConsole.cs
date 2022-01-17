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
            _curIndex = 0;
            _sb.Clear();
            _leftPos = Console.CursorLeft;
            _topPos = Console.CursorTop;
            var ch = Console.ReadKey(true);
            while (ch.Key != ConsoleKey.Enter)
            {
                
                if (_keysHandlers.ContainsKey(ch.Key))
                {
                    _keysHandlers[ch.Key].Invoke();
                    _leftPos = Console.CursorLeft - _curIndex;
                    _topPos = Console.CursorTop;
                    RefreshLine();
                }
                else if (ch.Key == ConsoleKey.Backspace)
                {
                    if (_curIndex > 0)
                    {
                        --_curIndex;
                        _sb.Remove(_curIndex, 1);
                        Console.SetCursorPosition(_leftPos + _sb.Length, _topPos);
                        Console.Write(@" ");
                        RefreshLine();
                    }
                }
                else if (ch.Key == ConsoleKey.Delete)
                {
                    if (_curIndex < _sb.Length)
                    {
                        _sb.Remove(_curIndex, 1);
                        Console.SetCursorPosition(_leftPos + _sb.Length, _topPos);
                        Console.Write(@" ");
                        RefreshLine();
                    }
                }
                else if (ch.Key == ConsoleKey.LeftArrow && _curIndex > 0)
                {
                    --_curIndex;
                    Console.SetCursorPosition(_leftPos + _curIndex, _topPos);
                }
                else if (ch.Key == ConsoleKey.RightArrow && _curIndex < _sb.Length)
                {
                    ++_curIndex;
                    Console.SetCursorPosition(_leftPos + _curIndex, _topPos);
                }
                else if (ch.KeyChar != '\0')
                {
                    _sb.Insert(_curIndex, ch.KeyChar);
                    _curIndex++;
                    RefreshLine();
                }

                ch = Console.ReadKey(true);
            }
            Console.WriteLine();

            return _sb.ToString();
        }

        public string GetCurrentLine() => _sb.ToString();

        public void SetCurrentLine(string line)
        {
            Console.SetCursorPosition(_leftPos, _topPos);
            Console.Write(new string(' ', _sb.Length));
            _sb.Clear();
            _sb.Append(line);
            _curIndex = line.Length;
        }

        public void RefreshLine()
        {
            Console.SetCursorPosition(_leftPos, _topPos);
            Console.Write(GetCurrentLine());
            Console.SetCursorPosition(_leftPos + _curIndex, _topPos);
        }

        private int _leftPos;
        private int _topPos;
        private int _curIndex;
        private readonly StringBuilder _sb = new();
        private readonly Dictionary<ConsoleKey, Action> _keysHandlers = new();
    }
}