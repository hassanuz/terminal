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
            TearDown();
        }


        [TestInitialize]
        public void Clear()
        {
/*
            WindowsElement checkX = null;
            try
            {
                checkX = session.FindElementByAccessibilityId("CloseButton");
            }
            catch { }
            while (checkX != null)
            {
                session.FindElementByAccessibilityId("CloseButton").Click();
                try
                {
                    checkX = session.FindElementByAccessibilityId("CloseButton");
                } catch {
                    checkX = null;
                }
            }
            session.Keyboard.SendKeys(Keys.Enter);
            session.Keyboard.SendKeys(Keys.LeftControl + "t" + Keys.LeftControl);   

    */
        }


        [TestMethod]
        public void LaunchCMD()
        {
            WindowsElement plusTab = session.FindElementByXPath("/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"CASCADIA_HOSTING_WINDOW_CLASS\"][@Name=\"C:\\WINDOWS\\System32\\WindowsPowerShell\\v1.0\\powershell.exe\"]/Pane[@ClassName=\"Windows.UI.Composition.DesktopWindowContentBridge\"][@Name=\"DesktopWindowXamlSource\"]/Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]/SplitButton[@ClassName=\"Windows.UI.Xaml.Controls.SplitButton\"]");
            //Store.Click();
            PointerInputDevice penDevice = new PointerInputDevice(PointerKind.Touch);
            ActionSequence sequence = new ActionSequence(penDevice, 0);
            ActionSequence sequence2 = new ActionSequence(penDevice, 0);
            sequence.AddAction(penDevice.CreatePointerMove(plusTab, 30, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerUp(PointerButton.TouchContact));
            session.PerformActions(new List<ActionSequence> { sequence });
            Thread.Sleep(1000);
            sequence2.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 200, TimeSpan.Zero));
            sequence2.AddAction(penDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence2.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 200, TimeSpan.FromMilliseconds(50)));
            sequence2.AddAction(penDevice.CreatePointerUp(PointerButton.TouchContact));
            session.PerformActions(new List<ActionSequence> { sequence2 });
            Assert.IsNotNull(session.FindElementByName("C:\\WINDOWS\\System32\\WindowsPowerShell\\v1.0\\powershell.exe"));
        }

        [TestMethod]
        public void Feedback()
        {
            WindowsElement plusTab = session.FindElementByXPath("/Pane[@ClassName=\"#32769\"][@Name=\"Desktop 1\"]/Window[@ClassName=\"CASCADIA_HOSTING_WINDOW_CLASS\"][@Name=\"C:\\WINDOWS\\System32\\WindowsPowerShell\\v1.0\\powershell.exe\"]/Pane[@ClassName=\"Windows.UI.Composition.DesktopWindowContentBridge\"][@Name=\"DesktopWindowXamlSource\"]/Pane[@ClassName=\"Windows.UI.Input.InputSite.WindowClass\"]/SplitButton[@ClassName=\"Windows.UI.Xaml.Controls.SplitButton\"]");
            //Store.Click();
            PointerInputDevice penDevice = new PointerInputDevice(PointerKind.Touch);
            ActionSequence sequence = new ActionSequence(penDevice, 0);
            ActionSequence sequence2 = new ActionSequence(penDevice, 0);
            sequence.AddAction(penDevice.CreatePointerMove(plusTab, 30, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerDown(PointerButton.TouchContact));
            sequence.AddAction(penDevice.CreatePointerMove(CoordinateOrigin.Pointer, 0, 0, TimeSpan.Zero));
            sequence.AddAction(penDevice.CreatePointerUp(PointerButton.TouchContact));
            session.PerformActions(new List<ActionSequence> { sequence });
            Thread.Sleep(1000);
            WindowsElement FeedBackButton = session.FindElementByName("Feedback");
            FeedBackButton.Click();
            session.Keyboard.SendKeys(Keys.Alt + Keys.Tab + Keys.Alt + Keys.Tab);
        }

        [TestMethod]
        public void CreateAndCloseMultipleTabs()
        {
            Assert.IsNotNull(session.FindElementByAccessibilityId("CloseButton"));
            session.Keyboard.SendKeys(Keys.LeftControl + "t" + Keys.LeftControl);
            session.Keyboard.SendKeys(Keys.LeftControl + "t" + Keys.LeftControl);
            session.FindElementByAccessibilityId("CloseButton").Click();
            Thread.Sleep(1000);
            session.FindElementByAccessibilityId("CloseButton").Click();
            Thread.Sleep(1000);

            WindowsElement closeButton = null;
            try
            {
                closeButton = session.FindElementByAccessibilityId("CloseButton");
            }
            catch { }
            Assert.IsNotNull(closeButton);
        }
    }
}
