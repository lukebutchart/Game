using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class UI
    {
        public string Message { get; set; }
        //public bool NeedInput { get; set; } = false;
        public string InputMessage { get; set; }
        public string Input { get; set; }

        public void Run()
        {
            if (Message.Length > 0)
            {
                Console.WriteLine(Message);
            }

            if (InputMessage.Length > 0)
            {
                Console.WriteLine(InputMessage);
                Input = Console.ReadLine();
            }

            Message = "";
            InputMessage = "";
        }

        public string GetInput(string message = "", string inputMessage = "")
        {
            Message = message;
            InputMessage = inputMessage;
            Run();
            return Input;
        }
    }
}
