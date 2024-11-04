using System.Diagnostics;
using OpenQA.Selenium;

namespace Auto_Demex.Pages;

/// <summary>
/// Define common elements for all pages
/// </summary>
public abstract class BasePage<TOwner> : Page<TOwner>
    where TOwner : BasePage<TOwner>
{
    protected TPageObject On<TPageObject>() where TPageObject : PageObject<TPageObject>
        => AtataContext.Current.PageObject as TPageObject ?? Go.To<TPageObject>(navigate: false);

    /// <summary>
    /// Users wait for a while as user behaviours
    /// </summary>
    public TOwner WaitForReading(int timeInSeconds = 1)
    {
        WaitSeconds(timeInSeconds);

        return (TOwner)this;
    }

    public TOwner WaitFor(Action action, int timeoutsInSeconds = 15,
        string errorMessage = "Retrying to do action...")
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        bool isQuoteStarted = false;
        while (!isQuoteStarted && stopwatch.Elapsed.TotalSeconds <= timeoutsInSeconds)
        {
            try
            {
                action.Invoke();
                isQuoteStarted = true;
            }
            catch (Exception e)
            {
                AtataContext.Current.Log.Warn($"{errorMessage} - {e.Message}");
            }
        }
        stopwatch.Stop();

        return (TOwner)this;
    }

    public TOwner WaitForJQueryLoaded(bool isThrownException = false)
    {
        try
        {
            SpinWait.SpinUntil(() => (bool)((IJavaScriptExecutor)AtataContext.Current.Driver).ExecuteScript("return jQuery.active == 0"),
            TimeSpan.FromSeconds(5));
        }
        catch (Exception e)
        {
            if (isThrownException)
                throw;
            AtataContext.Current.Log.Info($"Waiting for JQuery and got error: {e.Message}");
        }

        return (TOwner)this;
    }

    public TOwner GoToLastWindow()
    {
        Go.ToWindow<KeplrPage>(AtataContext.Current.Driver.WindowHandles.Last());
        return (TOwner)this;
    }

    public TOwner GoToFirstWindow()
    {
        Go.ToWindow<KeplrPage>(AtataContext.Current.Driver.WindowHandles[0]);
        return (TOwner)this;
    }
}
