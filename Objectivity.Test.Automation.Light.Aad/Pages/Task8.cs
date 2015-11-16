using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Light.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Objectivity.Test.Automation.Light.Aad.Pages
{
    public class Task8 : PageBase
    {
        [FindsBy(How = How.Id, Using = "task8_form_name")]
        private IWebElement ImieNazwiskoText;
        [FindsBy(How = How.Id, Using = "task8_form_cardNumber")]
        private IWebElement NumerKartyText;
        [FindsBy(How = How.Id, Using = "task8_form_cardCvv")]
        private IWebElement CvvText;
        [FindsBy(How = How.CssSelector, Using = "button[type=submit]")]
        private IWebElement ZaplacButton;
        public Task8(IWebDriver driver) : base(driver)
        {
        }
        protected SelectElement TypKartySelect
        {
            get
            {
                return new SelectElement(Driver.FindElement(By.Id("task8_form_cardType")));
            }
        }
        protected SelectElement MiesiacSelect
        {
            get
            {
                return new SelectElement(Driver.FindElement(By.Id("task8_form_cardInfo_month")));
            }
        }
        protected SelectElement RokSelect
        {
            get
            {
                return new SelectElement(Driver.FindElement(By.Id("task8_form_cardInfo_year")));
            }
        }

        public void FillForm(string typKarty, string imieNazwisko, string nrKarty, string cvv, string miesiac, string rok)
        {
            TypKartySelect.SelectByText(typKarty);
            ImieNazwiskoText.SendKeys(imieNazwisko);
            NumerKartyText.SendKeys(nrKarty);
            CvvText.SendKeys(cvv);
            MiesiacSelect.SelectByText(miesiac);
            RokSelect.SelectByText(rok);
        }

        public void Submit()
        {
            ZaplacButton.Click();
        }
    }
}
