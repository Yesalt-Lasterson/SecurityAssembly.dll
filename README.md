# SecurityAssembly.dll
This is my personal project and there are 2 other projects that use this for testing purposes not actually good security but be like anyway.
## Documentation
Here's how to use this .dll, first u need to refrence the .dll on whatever u are using and do 'using Permissions;' and if u have IDE u can probably do rest but if whatever reason u dont; well here is manual documentation. now there is an xml documentation as well just so u know. There are three types
'struct SecurityRights', 'interface IPermissionsLevel', 'enum PermissionLvl' and here are the methods of the struct 
'HasRequiredPermissions', 'ToSecurityRights' everithing else is private u no need. Enum has these values 'Suspended', 'Untrusted', 'Member', 'MVP' <-- Don't use or else Exception 'Master', 'Moderator', 'Admin', 'OWNER' and those are all of those values and for the interface its just a copy of the enum values just has type PermissionLvl the enum also are properties.

New type CustomSecurityRights

-Full Access to everything

### Best Practices

Write all instances in 1 class
and write every parameter with a variable
to avoid the risk of Magic Strings.

## TL;DR
Don't use MVP value in Enum or exception will happen
