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


        [SetUp]
        public void setUp()
        {
            fakeTimer = Substitute.For<ITimer>();
            fakeUserInterface = Substitute.For<IUserInterface>();
            fakeOutput = Substitute.For<IOutput>();
            display = new Display(fakeOutput);
            cookController = new CookController(fakeTimer, display, powerTube, fakeUserInterface);
            fakeUserInterface = Substitute.For<IUserInterface>();
        }

        //[Test]
        //public void cookcotroler_display_Integration_Test()
        //{ 
        // cookController.OnTimerTick();
        //}


    }

}