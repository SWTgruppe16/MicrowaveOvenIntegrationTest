using NUnit.Framework;
using System;
using System.Collections.Generic;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveTestIntegration
{

    [TestFixture]
    public class IT_Button_UI
    {
        private IButton powerButton;
        private IButton timeButton;
        private IButton startCancelButton;
        private IDoor door;
        private IDisplay display;
        private ILight light;
        private ICookController cooker;
        private IUserInterface ui;
        private IOutput output;
        private ITimer timer;
        private IPowerTube powerTube;

        [SetUp]
        public void SetUp()
        {
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            door = new Door();
            output = new Output();
            powerTube = new PowerTube(output);
            display = new Display(output);
            light = new Light(output);
            timer = new Timer();
            cooker = new CookController(timer, display, powerTube);
            ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);
            //evt lav fakes, det gør programmet nemmere at teste. IT test er en "unittest" af controlleren. 
        }



            
    }
}
