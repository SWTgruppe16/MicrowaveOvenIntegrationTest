﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit;
using NSubstitute;

namespace MicrowaveTestIntegration
{
    [TestFixture]
    public class Iteration3
    {
        //System under test
        private IDisplay display;
        private IUserInterface sut;
        private ILight light;
        
        //Fakes
        private ITimer fakeTimer; //Lavet som fake, fordi det ellers ville tage for lang tid at køre testprogrammet
        private IOutput fakeOutput;
        private IDoor fakeDoor;
        private IPowerTube fakePowerTube;

        private ICookController cookController;

        //buttons
        private IButton powerButton;
        private IButton timeButton;
        private IButton startCancelButton;

        [SetUp]
        public void SetUp()
        {
            fakeOutput = Substitute.For<IOutput>();
            fakeTimer = Substitute.For<ITimer>();
            fakeDoor = Substitute.For<IDoor>();
            fakePowerTube = Substitute.For<IPowerTube>();

            powerButton = Substitute.For<IButton>();
            timeButton = Substitute.For<IButton>();
            startCancelButton = Substitute.For<IButton>();

            display = Substitute.For<IDisplay>();
            light = new Light(fakeOutput);

            cookController = new CookController(fakeTimer, display, fakePowerTube);
            sut = new UserInterface(powerButton, timeButton, startCancelButton, fakeDoor, display, light, cookController);

            cookController = new CookController(fakeTimer, display, fakePowerTube, sut);

        }

        #region display

        [Test, Sequential]
        public void display_showPower_test_multi(
            [Values(1,2,3,4,5,6,7,8,9,10,11,12,13,14)] int n_presses,
            [Values(50,100,150,200,250,300,350,400,450,500,550,600,650,700)] int result_power 
        )
        {
            for (var i = 0; i < n_presses; ++i) {
                powerButton.Pressed += Raise.Event();
            }
            display.Received().ShowPower(result_power); //Tests if display shows correct power
        }

/*
        [Test]
        public void display_showTimer_Test(
            [Values(1,2,3,4,5,6,7,8,9,10)] int n_presses,
            [Values(TimeSpan.FromMinutes(1))] TimeSpan t
        )
        {
            for (var i = 0; i < n_presses; ++i) {
                timeButton.Pressed += Raise.Event();
            }
            
            display.Received().ShowTime(t);


        }

*/
        [Test, Sequential]
        public void display_showTimer_Test(
            [Values(1,2,3,4,5,6,7,8,9,10)] int n_presses
        )
        {
            powerButton.Pressed += Raise.Event();
            
            for (var i = 0; i < n_presses; ++i) {
                timeButton.Pressed += Raise.Event();
            }
            
            var t = TimeSpan.FromMinutes(n_presses);
            display.Received().ShowTime(t);


        }

        [Test, Sequential]
        public void display_showTimer_without_power_Test()
        {
            timeButton.Pressed += Raise.Event();   
            display.DidNotReceiveWithAnyArgs().ShowTime(TimeSpan.Zero);
        }

        #endregion

    }
}
