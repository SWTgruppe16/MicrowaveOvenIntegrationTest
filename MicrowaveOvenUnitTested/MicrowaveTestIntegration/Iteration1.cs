using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Boundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace MicrowaveTestIntegration
{
    class Iteration1SUT
    {
        private ITimer fakeTimer;
        private IOutput fakeOutput;
        private IUserInterface fakeUserInterface;

        private Display display;
        private PowerTube powerTube;
        private CookController cookController;

        private EventArgs _timertick; 

        //Vi tror vi skal have et "private" et eller andet med et event her

        [SetUp]
        public void setUp()
        {
            fakeTimer = Substitute.For<ITimer>();
            fakeUserInterface = Substitute.For<IUserInterface>();
            fakeOutput = Substitute.For<IOutput>();
            display = new Display(fakeOutput);
            cookController = new CookController(fakeTimer, display, powerTube, fakeUserInterface);
            fakeUserInterface = Substitute.For<IUserInterface>();
            _timertick = new EventArgs();
            //Og noget mere med det event her
        }

        [Test] //Vi vil gerne teste at display viser timeren, når timeren startes
        public void cookcotroler_display_Integration_Test()
        {
            cookController.OnTimerTick(null, null); //åh nej hvad skal der stå?
        }


    }

}