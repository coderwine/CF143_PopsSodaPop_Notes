# Basic Build Commands:

## Creating the Basic Layout:
After creating your project folder, within it  you will: 
**Add your Solution File**
```
dotnet new sln
```
or
```
dotnet new sln -n [File Name] 
```
**Create your gitignore**
```
dotnet new gitignore
```
---

### POCO: Plain Old Class Object:
```
dotnet new classlib -o [File Name]
dotnet sln add [Folder Path]
```
### Repository: 
```
dotnet new classlib -o [File Name]
dotnet sln add [Folder Path]
```
### UI (Console App):
```
dotnet new console -o [File Name]
dotnet sln add [Folder Path]
```
## Creating Testing:
```
dotnet new xunit -o [File Name]
dotnet sln add [Folder Path]
```

---
# Adding References:
Referencing is important so that your files are communicating with one another.

Inside each main folder (ex: PopsSodaPop.Repository), you will add reference to their needed namespaces.

```
dotnet add reference [File Path]
```
---
## Common Connections:

|Folder | Reference |
| -------------- | ------------- |
|Repository | Data
| UI    | Repository
|       | Data
|Data.Tests | Data
|Repository.Tests | Repository

*The Data folder holding your POCO won't need to reference any other files as this is our base file.*

---
