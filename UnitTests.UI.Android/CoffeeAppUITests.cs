using OpenQA.Selenium.Appium;
using UITests;
using UnitTests.UI.Init;

namespace UnitTests.UI;

public class CoffeeAppUITests : BaseTest
{
    private AppiumSetup _appiumSetup = new();
    
    [SetUp]
    public void Setup()
    {
        App = _appiumSetup.RunBeforeAnyTests();
    }
     
    [Test]
    public void AppLaunches()
    {
        App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
        
        _appiumSetup.RunAfterAnyTests();
    }
    
    [Test]
    public void ClickCounterTest()
    {
        try
        {
            var t = App.FindElement(MobileBy.AccessibilityId("CoffeePageTitleLabel"));
            
            var element = FindUIElement("CoffeePageTitleLabel");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        _appiumSetup.RunAfterAnyTests();
    }
}