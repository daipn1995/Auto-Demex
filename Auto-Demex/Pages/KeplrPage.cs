namespace Auto_Demex.Pages;

using Auto_Demex.Configuration;
using _ = KeplrPage;

[Url("chrome-extension://dmkamcknogkgcdfhhbddcghachkejeap/register.html#")]
public class KeplrPage : BasePage<_>
{
    #region Register home page
    [FindByXPath("//button[contains(.,'Import an existing wallet')]")]
    public Clickable<_> ImportExistingWalletButton { get; private set; }
    [FindByXPath("//button[contains(.,'Use recovery phrase or private key')]")]
    public Clickable<_> UsePrivateKeyButton { get; private set; }
    #endregion
    #region Step 1/3
    [FindByXPath("//button[contains(.,'Private key')]")]
    public Clickable<_> PrivateKeyOption { get; private set; }
    [FindByCss("[type='password']")]
    public PasswordInput<_> PrivateKeyTextBox { get; private set; }
    [FindByXPath("//button[contains(.,'Import') and @type='submit']")]
    public Clickable<_> ImportButton { get; private set; }
    #endregion
    #region Step 2/3
    [FindByCss("[name='name']")]
    public Input<string, _> WalletName { get; private set; }
    [FindByCss("[name='password']")]
    public Input<string, _> Password { get; private set; }
    [FindByCss("[name='confirmPassword']")]
    public Input<string, _> ConfirmPassword { get; private set; }
    [FindByXPath("//button[contains(.,'Next') and @type='submit']")]
    public Button<_> NextButton { get; private set; }
    #endregion
    #region Step 3/3 and so on
    [FindByXPath("//button[contains(.,'Save')]")]
    public Button<_> SaveButton { get; private set; }
    [FindByXPath("//button[contains(.,'Finish')]")]
    public Button<_> FinishButton { get; private set; }
    #endregion

    #region Dialog
    [FindByXPath("//button[contains(.,'Approve')]")]
    public Button<_> ApproveButton { get; private set; }
    #endregion

    public _ SetupWallet()
    {
        WaitFor(() => Go.ToNextWindow<_>());
        WaitFor(() =>
        {
            RefreshPage();

            ImportExistingWalletButton.Click();
            UsePrivateKeyButton.Click();

            PrivateKeyOption.Click();
            PrivateKeyTextBox.Set(AtataConfiguration.Global.PrivateKey);
            ImportButton.Click();

            WalletName.Set(Randomizer.GetString());
            Password.Set(AtataConfiguration.Global.WalletPassword);
            ConfirmPassword.Set(AtataConfiguration.Global.WalletPassword);
            NextButton.Click();

            SaveButton.WaitTo.WithinSeconds(10).BeVisible();
            SaveButton.Click();
            FinishButton.WaitTo.BeVisible();

            AtataContext.Current.Driver.Close();
        });
        GoToFirstWindow();

        return this;
    }
}