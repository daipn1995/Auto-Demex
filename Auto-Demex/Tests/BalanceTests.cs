using Auto_Demex.Pages;

namespace Auto_Demex.Tests;

public class BalanceTests : TestBase
{
    [Test]
    public void UserCanViewAccountBalances()
    {
        Go.To<HomePage>()
                .ConnectWalletButton.WaitTo.WithinSeconds(10).BeVisible();
        On<KeplrPage>().SetupWallet();
        On<HomePage>().ConnectToKeplrWallet()
            .AccessBalancesPage()
            .TotalWalletBalance.Should.BeVisible()
            .AvailableBalance.Should.BeVisible();
        
        int totalBalance = (int)double.Parse(On<BalancesPage>().TotalWalletBalance.Value.Trim().Substring(1),
            System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint);
        int availableBalance = (int)double.Parse(On<BalancesPage>().AvailableBalance.Value.Split("Available:")[1].Trim().Substring(1),
            System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint);
        Assert.That(totalBalance, Is.InRange(300000000, 900000000));
    }
}