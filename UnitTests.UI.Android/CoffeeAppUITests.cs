using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using UnitTests.UI.Init;

// [TestFixture]
// public class CoffeeAppUITests
// {
//     private AndroidDriver _app;
//     
//     private const string AndroidApkFileName = "/Users/vlad/Documents/GitHub/CodeChallenge/CodeChallenge/bin/Release/net8.0-android/com.companyname.codechallenge-Signed.apk";
//
//     private const string DescriptionText =
//         "A strong and concentrated coffee made by forcing hot water through finely-ground coffee beans.";
//
//     [SetUp]
//     public void Setup()
//     {
//         _app = (AndroidDriver)AppInitializer.StartAndroidApp(AndroidApkFileName); // Use StartiOSApp for iOS
//     }
//
//     [TearDown]
//     public void TearDown()
//     {
//         _app?.Quit();
//     }
//
//     [Test]
//     public void TapCoffeeProduct_ShouldNavigateToDetailPage()
//     {
//         FindUIElement 
//         var wait = new WebDriverWait(_app, TimeSpan.FromSeconds(10)); // Wait up to 10 seconds
//         
//         var coffeeItem2 = wait.Until(driver => driver.FindElement(MobileBy.AccessibilityId("CoffeePage_Title_Label")));
//         
//         // Example test to tap a coffee product and verify navigation
//         var coffeeItem = _app.FindElement(MobileBy.AccessibilityId("CoffeeItem_0"));
//         coffeeItem.Click();
//
//         var coffeeDescription = _app.FindElement(MobileBy.AccessibilityId("CoffeeDetailsPage_Description_Text"));
//         
//         Assert.That(DescriptionText, Is.EqualTo(coffeeDescription.Text));
//     }
// }

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and NUnit SetUpFixture attributes.
// Also see: https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html
namespace UnitTests.UI.Android;

// This is an example of tests that do not need anything platform specific.
// Typically you will want all your tests to be in the shared project so they are ran across all platforms.
public class UITest1 : BaseTest
{
    [Test]
    public void AppLaunches()
    {
        App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
    }
}