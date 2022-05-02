# CleanArchitectureDemo2

## <a name="Migration"></a> Migration
### Powershell
Creating the first migration 
```
add-migration InitialCreate -p NorthWind.Repositories.EFCore -c NorthWindContext -o Migrations -s NorthWind.Repositories.EFCore
update-database -p NorthWind.Repositories.EFCore -s NorthWind.Repositories.EFCore
```