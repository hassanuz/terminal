//******************************************************************************
//
// Copyright (c) 2017 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Interactions;
using PointerInputDevice = OpenQA.Selenium.Appium.Interactions.PointerInputDevice;
using System.Collections.Generic;

namespace Cascadia.UI.Tests
{
    
    [TestClass]
    public class TestScenarios : CascadiaTestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            WindowsElement closeButton = session.FindElementByAccessibilityId("CloseButton");
            closeButton.Click();
            TearDown();
        }


        [TestInitialize]
        public void Clear()
        {
      
        }


        [TestMethod]
        public void LaunchCMD()
        {

            ActionsLaunch("cmd");
            Thread.Sleep(2000);
            Assert.IsNotNull(session.FindElementByAccessibilityId("Console Window"));
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "w" + Keys.Shift + Keys.LeftControl);


        }
        [TestMethod]
        public void LaunchAbout()
        {
            ActionsLaunch("About");
            Thread.Sleep(2000);
            session.Keyboard.SendKeys(Keys.Escape);

        }
        private void ActionsLaunch(String type)
        {

            int Y = 300;

            if (type.Contains("cmd"))
            {
                Y = 100;
            }
            else if (type.Contains("About"))
            {
                Y = 450;
            }
            else
            {
               Y = 650;
            }

            WindowsElement plusTab = session.FindElementByAccessibilityId("TabView");
            PointerInputDevice penDevice = new PointerInputDevice(PointerKind.Touch);
            ActionSequence sequence = new ActionSequence(penDevice, 0);
            ActionSequence sequence2 = new ActionSequence(penDevice, 0);

            sequence.AddAction(penDevice.CreatePointerMove(plusTab, 210, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerUp(PointerButton.TouchContact));
            session.PerformActions(new List<ActionSequence> { sequence });
           
            Thread.Sleep(2000);
            sequence2.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, Y, TimeSpan.Zero));
            sequence2.AddAction(penDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence2.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 1, TimeSpan.FromMilliseconds(50)));
            sequence2.AddAction(penDevice.CreatePointerUp(PointerButton.TouchContact));
            session.PerformActions(new List<ActionSequence> { sequence2 });
        }
        private WindowsElement FindElementByAbsoluteXPath(string xPath, int nTryCount = 10)
        {
            WindowsElement uiTarget = null;

            while (nTryCount-- > 0)
            {
                try
                {
                    uiTarget = session.FindElementByXPath(xPath);
                }
                catch
                {
                }

                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                }
            }

            return uiTarget;
        }
  
        [TestMethod]
        public void CreateAndCloseMultipleTabs()
        {
            Assert.IsNotNull(session.FindElementByAccessibilityId("CloseButton"));
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift +  "2" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "2" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "2" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "2" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "w" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "w" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "w" + Keys.Shift + Keys.LeftControl);
            Thread.Sleep(1000);
            session.Keyboard.SendKeys(Keys.LeftControl + Keys.LeftShift + "w" + Keys.Shift + Keys.LeftControl);
            session.FindElementByClassName("TermControl").Click();
            WindowsElement closeButton = null;
            try
            {
                closeButton = session.FindElementByAccessibilityId("CloseButton");
            }
            catch { }
            //Assert.IsNull(closeButton);
        }
    }
}
