﻿using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Boundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace MicrowaveTestIntegration
{
    [TestFixture]
    public class Iteration1
    {
        //Fakes
        private ITimer fakeTimer; //Lavet som fake, fordi det ellers ville tage for lang tid at køre testprogrammet
        private ITimer timer;
        private IOutput fakeOutput;
        private IUserInterface fakeUserInterface;
        private IDoor fakeDoor;
        private ILight fakeLight;


        //System under test
        private IDisplay display;
        private IPowerTube powerTube;
        private CookController cookController;

        //buttons
        private IButton powerButton;
        private IButton timeButton;
        private IButton startCancelButton;


        [SetUp]
        public void setUp()
        {
            powerButton = Substitute.For<IButton>();
            timeButton = Substitute.For<IButton>();
            startCancelButton = Substitute.For<IButton>();

            //Fakes
            fakeDoor = Substitute.For<IDoor>();
            fakeLight = Substitute.For<ILight>();
            fakeTimer = Substitute.For<ITimer>(); //Lavet som fake, fordi det ellers ville tage for lang tid at køre testprogrammet
            timer = new Timer();

            fakeOutput = Substitute.For<IOutput>();
            display = new Display(fakeOutput);
            powerTube = new PowerTube(fakeOutput);

            cookController = new CookController(fakeTimer, display, powerTube);
            fakeUserInterface = new UserInterface(powerButton, timeButton, startCancelButton, fakeDoor, display, fakeLight, cookController);
            cookController.UI = fakeUserInterface;
  
        }
        
        #region Display

        [Test] 
        public void cookController_display_showtime_test()
        {
            //powerButton.Pressed += Raise.Event();
            //timeButton.Pressed += Raise.Event();
            //startCancelButton.Pressed += Raise.Event(); //The raise of these three events puts the microwave oven into cooking state

            cookController.StartCooking(50, TimeSpan.FromSeconds(60));

            fakeTimer.TimerTick += Raise.Event();

            fakeOutput.Received().OutputLine(Arg.Is<string>(str => str.Contains("Display shows: "))); //This tests that the display shows something, when OnTimerTick event is raised
        }

        #endregion

        #region PowerTube

        [Test]
        public void cookController_PowerTube_TurnOn()
        {
            int power = 50;

            powerButton.Pressed += Raise.Event();
            timeButton.Pressed += Raise.Event(); //The raise of these two events puts the microwave oven into set time state

            cookController.StartCooking(power, TimeSpan.FromSeconds(60));

            fakeOutput.Received().OutputLine(Arg.Is<string>(str => str.Contains($"PowerTube works with {power} W")));

        }

        [Test]
        public void cookController_PowerTube_TurnOff()
        {
            //powerButton.Pressed += Raise.Event();
            //timeButton.Pressed += Raise.Event();
            //startCancelButton.Pressed += Raise.Event(); //The raise of these three events puts the microwave oven into cooking state

            cookController.StartCooking(50, TimeSpan.FromSeconds(60));

            cookController.Stop();

            fakeOutput.Received().OutputLine(Arg.Is<string>(str => str.Contains("PowerTube turned off")));
        }

        [Test]
        public void cookController_TimerExpired_PowerTube_TurnOff()
        {
            //powerButton.Pressed += Raise.Event();
            //timeButton.Pressed += Raise.Event();
            //startCancelButton.Pressed += Raise.Event(); //The raise of these three events puts the microwave oven into cooking state

            cookController.StartCooking(50, TimeSpan.FromSeconds(60));

            fakeTimer.Expired += Raise.Event();

            fakeOutput.Received().OutputLine(Arg.Is<string>(str => str.Contains("PowerTube turned off")));
        }

        #endregion

        #region timer

        //timer test

        #endregion


    }

}