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
            
            var drivetOption = new AppiumOptions();
            drivetOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");

            AppiumDriver<AndroidElement> _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), drivetOption);

            /*var context = ((IContextAware)_driver).Contexts;
            string webviewContext = null;
            for(var i = 0; i < context.Count; i++)
            {
                Console.WriteLine(context[i]);
                if(context[i].Contains("WEBVIEW"))
                {
                    webviewContext = context[i];
                    break;
                }
            }
            
            ((IContextAware)_driver).Context = webviewContext;
            */
            var Text = _driver.FindElementsByXPath("//*[@class='android.widget.TextView']");

            foreach(var text in Text)
            {
                if(text.Text.Contains("Свободная энциклопедия\r\n…более, чем на 300 языках"))
                {
                    Console.WriteLine("Test: COMPLETE!!!");
                    Console.WriteLine("Output: " + text.Text);
                    break;
                }
                else
                {
                    Console.WriteLine("Test: FAILD!!!");
                    Console.WriteLine("Output: " + text.Text);
                }
            }
        }
    }
}
