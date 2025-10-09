# M4.04 - CosmosDB med Blazor WebApp
# Lavet af Rasmus Møller Kristensen

## Projektets formål
Projektets formål er at lave en Blazor WebApp, som kan oprette og vise 
supporthenvendelser. Data bliver gemt og hentet fra en **CosmosDB database**.

## Funktionalitet
- Oprette supporthenvendelse
- Vis supporthenvendelser
- Data gemmes i CosmosDB med partition key /category
- Validering med DataAnnotations

## Teknologier
- _Dotnet_
- _Azure CosmosDB (NoSQL)_
- _Microsoft.Azure.Cosmos_

## Oprettelse af CosmosDB database som passer til løsningen med Azure CLI
1. **Opret CosmosDB konto:**
- az cosmosdb create \
  --name <vælg-accountnavn> \
  --resource-group <dit-resource-gruppe-navn> \
  --locations regionName=<vælg-region> \
2. **Opret databasen:**
- az cosmosdb sql database create \
  --account-name <skriv-valgt-accountnavn> \
  --resource-group <dit-resource-group-navn> \
  --name <navngiv-databasen>
3. **Opret container:**
- az cosmosdb sql container create \
  --account-name <dit-accountnavn> \
  --resource-group <dit-resource-group-navn> \
  --database-name <database-navn> \
  --name <navngiv-container> \
  --partition-key-path "<vælg-sti-til-cointainer"
4. **Forbind WebApp til CosmosDB**
- Find connection string i Azure Portal.
- Indsæt den i appsettings.json

### Hvad er nået:
- Blazor WebApp som der virker
- Sat op med Azure CosmosDB
- Lavet datamodel med korrekt partition key
- Data hentes og gemmes

### Hvad mangler / næste skridt:
- Mulighed for at **redigere** og **slette** henvendelser
- Tilføje **søgning** på kategori
- Sætte webappen op med **Azure App Service**
- Forbedre designet

### Klon projektet
```bash
git clone https://github.com/EAA24RAMK/M4_04_CosmosDB_WebApp.git

