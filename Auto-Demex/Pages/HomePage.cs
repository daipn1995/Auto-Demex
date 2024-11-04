namespace Auto_Demex.Pages;

using _ = HomePage;

[Url("https://beta-app.dem.exchange/")]
public class HomePage : BasePage<_>
{
    [FindByXPath("//button[contains(.,'Connect Wallet')]")]
    public Button<_> ConnectWalletButton { get; private set; }
    [FindByXPath("(//*[contains(text(),'Keplr')])[last()]")]
    public Clickable<_> KeplrWalletOption { get; private set; }
    [FindByXPath("(//button[.='Connect'])[last()]")]
    public Clickable<_> KeplrConnectButton { get; private set; }
    [FindByXPath("//*[contains(@fill,'keplr-login-icon')]/../..")]
    public Clickable<_> WalletSetting { get; private set; }
    #region Wallet Setting Menu
    [FindByXPath("//li[contains(.,'Balances')]")]
    public Clickable<_> Balances { get; private set; }
    #endregion


    public _ ConnectToKeplrWallet()
    {
        ConnectWalletButton.Click();
        KeplrWalletOption.WaitTo.WithinSeconds(10).BeVisible();
        KeplrWalletOption.Click();
        KeplrConnectButton.Click();

        WaitFor(() =>
        {
            GoToLastWindow();
            On<KeplrPage>().ApproveButton.Click();
            GoToFirstWindow();
        });

        WaitSeconds(3);

        WaitFor(() =>
        {
            GoToLastWindow();
            On<KeplrPage>().ApproveButton.Click();
            GoToFirstWindow();
            WalletSetting.WaitTo.BeVisible();
        });

        GoToFirstWindow();

        return this;
    }

    public BalancesPage AccessBalancesPage()
    {
        WaitFor(() =>
        {
            WalletSetting.Click();
            Balances.Click();
        });

        return On<BalancesPage>();
    }

}
