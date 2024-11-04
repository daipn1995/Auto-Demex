namespace Auto_Demex.Pages;

using _ = BalancesPage;

[Url("https://beta-app.dem.exchange/")]
public class BalancesPage : BasePage<_>
{
    [FindByXPath("//*[text()='Total Wallet Balance']/following-sibling::*/*[contains(text(),'$')]")]
    public Text<_> TotalWalletBalance { get; private set; }
    [FindByXPath("//*[contains(text(),'Available:')]")]
    public Text<_> AvailableBalance { get; private set; }
}
