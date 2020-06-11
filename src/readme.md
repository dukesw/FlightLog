# Flight Log

A simple tool for logging flights on RC aircraft. 

## Entity Framework Migrations

Use the following commands to manage EF Migrations from the Package Manager console. In this instance, the EF context is defined in the Infrastructure project: 

Add a new migration:  
`add-migration v2 -StartupProject Infrastructure -Project Infrastructure`

Apply a migration to the database:  
`update-database v2 -StartupProject Infrastructure`  
> To remove all migrations from a database, run `update-database 0 -StartupProject Infrastructure`

Remove a migration, once this has been unapplied from the database by running `update-database` with a lower migration version.  
`remove-migration -StartupProject Infrastructure -Project Infrastructure`