namespace UltimatR
{
    public interface IAppSetup
    {

        IAppSetup UseHeaderForwarding();
        IAppSetup UseStandardSetup(string[] apiVersions);

        IAppSetup UseDataClients();

        IAppSetup UseExternalProvider();

        IAppSetup UseInternalProvider();

        IAppSetup UseDataMigrations();

        IAppSetup UseJwtUserInfo();

        IAppSetup UseSwaggerSetup(string[] apiVersions);
    }
}