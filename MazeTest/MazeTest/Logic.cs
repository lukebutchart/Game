using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Logic
    {
        public string gameState { get; set; } = "Begin";

        public bool End { get; set; } = false;

        public List<string> Input { get; set; }

        public void Run(Data data, UI ui)
        {
            while (!End)
            {
                End = true;

                Person player = new Person();
                PersonGenerator personGen = new PersonGenerator();

                if (gameState == "Begin")
                {
                    if (Input != null)
                    {
                        Input.Clear();
                    }

                    //ui.GetInput("Welcome!","What is your name?");

                    player = personGen.InstantiatePerson(data, ui.GetInput("Welcome!", "What is your name?"), ui.GetInput(inputMessage: "What is your gender?"));

                        // CHECK: May have issue with random seed being the same always now that it is stored in data.

                    gameState = "Middle";

                    End = false;
                }
            }
        }

        private void GetInput(UI ui)
        {
            ui.Message = "Welcome!";
            ui.InputMessage = "What is your name?";
            ui.Run();
            Input[0] = ui.Input;
        }
    }
}