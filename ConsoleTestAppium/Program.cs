using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;

namespace ConsoleTestAppium
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var driverOption = new AppiumOptions();
            drivetOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");

            AppiumDriver<AndroidElement> _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), drivetOption);

            var Text = _driver.FindElementsByXPath("//*[@class='android.widget.TextView']");

            foreach(var text in Text)
            {
                if(text.Text.Contains("Свободная энциклопедия\r\n…более, чем на 300 языках"))
                {
                    Console.WriteLine("Test: COMPLETED!!!");
                    Console.WriteLine("Output: " + text.Text);
                    break;
                }
                else
                {
                    Console.WriteLine("Test: FAILED!!!");
                    Console.WriteLine("Output: " + text.Text);
                }
            }
        }
    }
}
