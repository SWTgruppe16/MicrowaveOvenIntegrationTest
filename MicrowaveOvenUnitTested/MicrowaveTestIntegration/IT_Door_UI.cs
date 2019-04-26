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
    public class Door_UI_integrationTest
    {
        private IButton powerButton;
        private IButton timeButton;
        private IButton startCancelButton;
        private IDoor door;
        private IUserInterface ui;


        private ILight light;
        private ICookController cooker;
        private IOutput output;
        private ITimer timer;
        private IPowerTube powerTube;
        private IDisplay display;
        private Door _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new Door();
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

        [Test]
        public void Door_event_send_opened()
        {
            _uut.Opened
            Assert.That(), Is.EqualTo());
        }

        [Test]
        public void Door_event_send_closed()
        {
            _uut.Closed
            Assert.That(), Is.EqualTo());
        }

        [Test]
        public void Door_event_recieved()
        {
            _uut.
            Assert.That(), Is.EqualTo());
        }





    }
}
