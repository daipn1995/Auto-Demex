using Auto_Demex.Configuration;

namespace Auto_Demex;

public class TestBase
{
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        string driverAlias = TestContext.Parameters.Get("DriverAlias", "chrome");

        AtataContext.GlobalConfiguration
            .ApplyJsonConfig<AtataConfiguration>()
            .AddSecretStringToMaskInLog(AtataConfiguration.Global.PrivateKey)
            .UseDriver(driverAlias)
            .Screenshots.UseFullPageOrViewportStrategy()
            .UseNUnitTestSuiteName()
            .UseNUnitTestSuiteType()
            .UseNUnitAssertionExceptionType()
            .UseNUnitAggregateAssertionStrategy()
            .UseNUnitWarningReportStrategy()
            .UseNUnitAssertionFailureReportStrategy()
            .LogConsumers.AddNUnitTestContext().WithMinLevel(LogLevel.Info)
            .EventSubscriptions.LogNUnitError()
            .EventSubscriptions.TakeScreenshotOnNUnitError()
            .EventSubscriptions.TakePageSnapshotOnNUnitError()
            .EventSubscriptions.AddArtifactsToNUnitTestContext();

        AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
    }

    [SetUp]
    public static void SetUp() => AtataContext.Configure().Build();


    [TearDown]
    public static void TearDown() => AtataContext.Current?.Dispose();

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {

    }
    protected TPageObject On<TPageObject>() where TPageObject : PageObject<TPageObject>
        => AtataContext.Current.PageObject as TPageObject ?? Go.To<TPageObject>(navigate: false);
}