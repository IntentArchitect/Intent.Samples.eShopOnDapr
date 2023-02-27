Read here about Migrations using EF Core: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations
You can perform these commands in Visual Studio IDE (VS) using the Package Manager Console (View > Other Windows > Package Manager Console)
or using the dotnet Command Line Interface (CLI) instructions.
Substitute the {Keywords} below with the appropriate migration name when executing these commands.

Create a new migration:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Add-Migration -Name {ChangeName} -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef migrations add {ChangeName} --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure"

Remove last migration:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Remove-Migration -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef migrations remove --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure"

Update schema to the latest version:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Update-Database -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef database update --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure" 

Upgrade/downgrade schema to specific version:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Update-Database -Migration {Target} -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef database update {Target} --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure"

Generate a script which detects the current database schema version and updates it to the latest:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Script-Migration -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef migrations script --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure"

Generate a script which upgrades from and to a specific schema version:
-------------------------------------------------------------------------------------------------------------------------------------------------------
VS:  Script-Migration {Source} {Target} -StartupProject "eShopOnDapr.Web.HttpAggregator.Api" -Project "eShopOnDapr.Web.HttpAggregator.Infrastructure"
CLI: dotnet ef migrations script {Source} {Target} --startup-project "eShopOnDapr.Web.HttpAggregator.Api" --project "eShopOnDapr.Web.HttpAggregator.Infrastructure"

Drop all tables in schema:
-------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @SCHEMA AS varchar(max) = 'eShopOnDapr.Web.HttpAggregator'
DECLARE @EXECUTE_STATEMENT AS varchar(max) = (SELECT STUFF((SELECT CHAR(13) + CHAR(10) + [Statement] FROM (
    SELECT 'ALTER TABLE ['+@SCHEMA+'].['+[t].[name]+'] DROP CONSTRAINT ['+[fk].[name]+']' AS [Statement] FROM [sys].[foreign_keys] AS [fk] INNER JOIN [sys].[tables] AS [t] ON [t].[object_id] = [fk].[parent_object_id] INNER JOIN [sys].[schemas] AS [s] ON [s].[schema_id] = [t].[schema_id] WHERE [s].[name] = @SCHEMA
    UNION ALL
    SELECT 'DROP TABLE ['+@SCHEMA+'].['+[t].[name]+']' AS [Statement] FROM [sys].[tables] AS [t] INNER JOIN [sys].[schemas] AS [s] ON [s].[schema_id] = [t].[schema_id] WHERE [s].[name] = @SCHEMA
) A FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''))
EXECUTE(@EXECUTE_STATEMENT)
