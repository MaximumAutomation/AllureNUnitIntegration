using System;
using TechTalk.SpecFlow;

namespace SeleniumNUnit.TestCases
{
    [Binding]
    public class OptionalStepDefinitions
    {
        [Given(@"I am logged in to application")]
        public void GivenIAmLoggedInToApplication()
        {
            throw new PendingStepException();
        }

        [When(@"I add book")]
        public void WhenIAddBook()
        {
            throw new PendingStepException();
        }

        [When(@"I go to checkout page")]
        public void WhenIGoToCheckoutPage()
        {
            throw new PendingStepException();
        }

        [Then(@"I have (.*) books? in cart")]
        public void ThenIHaveBookInCart(int p0)
        {
            throw new PendingStepException();
        }
    }
}
