
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement textBoxPesel;
    static IWebElement SprawdzOferty;
    static IWebElement WyborOferty;
    static IAlert alert;
    // static IWebElement WniosekStandardowy;

    static void Main()
    {
        //driver.Navigate().GoToUrl("http://testing.todvachev.com/special-elements/text-input-field/");

        string url = "http://finddb98:78/Pages/NewAgreementPage.aspx";
        driver.Navigate().GoToUrl(url);

        //WNIOSKOWANY KREDYT
        var dropDownMenu = driver.FindElement(By.CssSelector("#ctl00_cphMain_ddlSubjects"));
        var TypUlicy = new SelectElement(dropDownMenu);
        TypUlicy.SelectByValue("11");
        Thread.Sleep(500);
        textBoxPesel = ElementException("ctl00_cphMain_tbPESEL");
        textBoxPesel.SendKeys("70103181951");
        Thread.Sleep(500);

        driver.FindElement(By.ClassName("siteTitle")).Click();
        Thread.Sleep(1000);

        SprawdzOferty = ElementException("ctl00_cphMain_checkAvaibleOffersButton_checkAvaibleOffersButton_checkAvaibleOffersButton");
        Thread.Sleep(1000);
        SprawdzOferty.Click();
        Thread.Sleep(1000);
        SprawdzOferty.Click();
        Thread.Sleep(1000);

        driver.FindElement(By.ClassName("siteTitle")).Click();
        Thread.Sleep(1000);
        KlikniecieWPole(ElementException("ctl00_cphMain_standardAgreementButton_header"));
        Thread.Sleep(3000);


        //WNIOSEK
        CzekajAzElementWidoczny("ctl00_cphMain_tabCredit_applicationCashCreditID_txtCashCreditValue");
        driver.FindElement(By.Id("ctl00_cphMain_tabCredit_applicationCashCreditID_txtCashCreditValue")).SendKeys("50000");
        driver.FindElement(By.Id("ctl00_cphMain_tabCredit_applicationCashCreditID_txtMonthsPeriod")).SendKeys("12");
        var TypOfertyMenu = driver.FindElement(By.CssSelector("#ctl00_cphMain_tabCredit_applicationCashCreditID_ddlOfferType"));
        var TypOfertyMenuE = new SelectElement(TypOfertyMenu);
        TypOfertyMenuE.SelectByValue("3128");
        Thread.Sleep(500);
        driver.FindElement(By.Id("ctl00_cphMain_ctrlNavigationBottom_btnForward_btnForward_btnForward")).Click();
        Thread.Sleep(2000);

        //DANE PODSTAWOWE

        //var ulica = ElementException("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtStreet");
        //PrzekazanieWartosciDoPola(ulica, "Długa");
        //PrzekazanieWartosciDoPola(ulica, "Krótka");

        CzekajAzElementWidoczny("ctl00_cphMain_tabCredit_ctrlDebtorPesel_tbPesel");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorPesel_tbPesel", "80081563203");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorNames_tbFirstName1", "Kinga");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorNames_tbLastName2", "Webdriver");
        KlikniecieWPole(ElementException("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtZipCode"));
        Thread.Sleep(2000);
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtZipCode", "59-300");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtCity", "Lubin");
        Thread.Sleep(1000);
        //IWebElement TypyUlic = driver.FindElement(By.Id("ctl00_cphMain_tabCredit_ctrlDebtorAddress_ddlStreetTypes"));
        //SelectElement WybranyTyp = new SelectElement(TypyUlic);
        //WybranyTyp.SelectByText("Ulica");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_ddlStreetTypes", "710");
        Thread.Sleep(500);

        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtStreet", "Koniec Świata");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_txtHouseNumber", "66");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorFirstDoc_tbSeries", "NTM");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorFirstDoc_tbNumber", "260837");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorFirstDoc_ctrlIssueDate_txtDate", "2010-02-02");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorFirstDoc_ctrlExpirationDate_txtDate", "2020-02-02");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorFirstDoc_tbIssuingBody", "Prezydent Lubina");
        Thread.Sleep(500);
        //KlikniecieWPoleJS("ctl00_cphMain_tabCredit_ctrlDebtorAddress_lblHeader");
        //Thread.Sleep(500);

        KlikniecieWPoleJS("ctl00_cphMain_ctrlNavigationBottom_btnSave_btnSave_btnSave");
        Thread.Sleep(500);
        alert = driver.SwitchTo().Alert();
        alert.Accept();

        KlikniecieWPoleJS("ctl00_cphMain_btnGenerateDocumentation_btnGenerateDocumentation_btnGenerateDocumentation");
        KlikniecieWPoleJS("ctl00_cphMain_cpErrorDebtorAgreementsUncheckedPopup_btnConfirm_btnConfirm_btnConfirm");

        KlikniecieWPoleJS("ctl00_cphMain_ctrlNavigationBottom_btnForward_btnForward_btnForward");
        alert = driver.SwitchTo().Alert();
        alert.Accept();
        Thread.Sleep(1000);


        //INNE SPRAWY
        CzekajAzElementWidoczny("ctl00_cphMain_btnGenerateDocumentation_btnGenerateDocumentation_btnGenerateDocumentation");
        KlikniecieWPole(ElementException("ctl00_cphMain_btnGenerateDocumentation_btnGenerateDocumentation_btnGenerateDocumentation"));
        KlikniecieWPole(ElementException("ctl00_cphMain_ctrlNavigationBottom_btnForward_btnForward_btnForward"));
        KlikniecieWPole(ElementException("ctl00_cphMain_cpCancelApplications_btnConfirm_btnConfirm_btnConfirm"));


        //DANE SZCZEGÓŁOWE
        CzekajAzElementWidoczny("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlNationality");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlEducation", "3881");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlMaritalStatus", "3872");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlChildren", "3863");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_mothersName", "Papa");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlResidentialPremises", "3946");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlApartmentOwnership", "3848");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_txtYearsPeriod", "6");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlCarOwnership", "3874");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlBankAccountType", "3836");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorAdditional_ddlOccupation", "3909");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorContact_tbPrivateCell", "666999666");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorCharges_rptLimitItems_ctl00_tbLimit", "500");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorCharges_rptLimitItems_ctl01_tbLimit", "0");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorCharges_rptLimitItems_ctl02_tbLimit", "0");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorCharges_rptLimitItems_ctl03_tbLimit", "0");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorCharges_rptLimitItems_ctl04_tbLimit", "0");
        Thread.Sleep(3000);
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_ddlIncomeType", "5768");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_ddlIncomeSector", "3968");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_tbIncomeAmount", "10000");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_ctrlIncomeDateFrom_txtDate", "2010-02-02");
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_tbNip", "6181012144");
        KlikniecieWPoleJS("ctl00_cphMain_tabCredit_ctrlDebtorIncome_btnAdd_btnAdd_btnAdd");
        Thread.Sleep(2000);
        CzekajAzElementNiewidoczny("ctl00_cphMain_Image1");
        KlikniecieWPoleJS("ctl00_cphMain_ctrlNavigationBottom_btnForward_btnForward_btnForward");
        KlikniecieWPoleJS("ctl00_cphMain_cpAgreementsUncheckedDebtor_btnConfirm_btnConfirm_btnConfirm");
        Thread.Sleep(2000);
        CzekajAzElementWidoczny("ctl00_cphMain_TabOffers_ctrLiabilities_ddlfirstInstalmentDate");

        //OFERTA
        PrzekazanieWartosciDoPolaJS("ctl00_cphMain_TabOffers_ctrLiabilities_ddlfirstInstalmentDate", "2019-03-22 00:00:00");
        KlikniecieWPoleJS("ctl00_cphMain_TabOffers_ctrLiabilities_btnRecalulateOffers_btnRecalulateOffers_btnRecalulateOffers");
        CzekajAzElementNiewidoczny("overlay");
        KlikniecieWButton("ctl00_cphMain_TabOffers_rbSelectCashCredit");
        KlikniecieWPoleJS("ctl00_cphMain_cpConfirmInsurenceStandardCredit_btnConfirm_btnConfirm_btnConfirm");
        KlikniecieWPoleJS("ctl00_cphMain_btnGenerateDocumentation_btnGenerateDocumentation_btnGenerateDocumentation");
        KlikniecieWPoleJS("ctl00_cphMain_ctrlNavigationBottom_btnForward_btnForward_btnForward");
        alert = driver.SwitchTo().Alert();
        alert.Accept();
        Thread.Sleep(500);
        CzekajAzElementWidoczny("ctl00_cphMain_tabCredit_ctrlDebtorEmployer_tbConfirmationPerson");
        Thread.Sleep(5000);

        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine($"Pojawił się wyjątek: {exception.Message}");
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}

        Thread.Sleep(3000);

        driver.Quit();
    }


    //METODY !!

    //Sprawdzenie czy pole widoczne
    public static bool CzyWidoczne(string kodElementu)
    {
        return ElementException(kodElementu).Displayed;
        //if (driver.FindElement(By.Id(kodElementu)).Displayed)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

    //Oczekiwanie na pobranie elementu
    public static IWebElement ElementException(string kodElementu)
    {
        bool staleElement = true;
        IWebElement element = null;

        while (staleElement)
        {
            try
            {
                element = driver.FindElement(By.Id(kodElementu));
                staleElement = false;

            }
            catch (StaleElementReferenceException e)
            {
                staleElement = true;
            }
            catch (NoSuchElementException e)
            {
                staleElement = true;
            }

        }

        return element;
    }


    //Przekzanie wartości w pole, przesłanie i kliknięcie
    public static void PrzekazanieWartosciDoPola(string idPola, string wartoscPola)
    {
        ElementException(idPola).SendKeys(wartoscPola);
    }

    public static void PrzeslanieWartosciDoPola(IWebElement element, string wartoscPola)
    {
        if (element != null)
            element.SendKeys(wartoscPola);
    }

    public static void PrzekazanieWartosciDoPolaJS(string idPola, string wartoscPola)
    {
        string js = $"$('#{idPola}').val('{wartoscPola}')";
        IJavaScriptExecutor exec = (IJavaScriptExecutor)driver;
        exec.ExecuteScript(js);
    }

    public static void KlikniecieWPoleJS(string idPola)
    {
        string js = $"$('#{idPola}').click()";
        IJavaScriptExecutor exec = (IJavaScriptExecutor)driver;
        exec.ExecuteScript(js);
    }

    public static void KlikniecieWButton(string idPola)
    {
        string js=$"$('#{idPola}').prop('checked', true)";
        IJavaScriptExecutor exec = (IJavaScriptExecutor)driver;
        exec.ExecuteScript(js);
    }

    public static void KlikniecieWPole(IWebElement element)
    {
        if (element != null)
            element.Click();
    }


    //Czekanie na widoczność elementue
    public static bool CzekajAzElementWidoczny(string kodElementu)
    {
        bool elementNiewidoczny = true;
        while (elementNiewidoczny)
        {
            if (CzyWidoczne(kodElementu))
            {
                elementNiewidoczny = false;
            }
            else
            {
                Thread.Sleep(500);
            }
        }

        return true;
    }

    public static bool CzekajAzElementNiewidoczny(string kodElementu)
    {
        bool elementWidoczny = true;
        while (elementWidoczny)
        {
            if (CzyWidoczne(kodElementu) == false)
            {
                elementWidoczny = false;
            }
            else
            {
                Thread.Sleep(500);
            }
        }
        return true;
    }
}

