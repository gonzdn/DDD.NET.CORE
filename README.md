# Net Core 5 Basic DDD Architecure with GraphQL

Basic DDD structure with GraphQL to refer as a base proyect to understand better how this works.

## Installation

Pretty straightforward, just modify the appsettings.json file located on GraphQLServer and DDD.NET.CORE.API projects by replacing your database connection.

```bash
DDD.NET.CORE.API/appsettings.json

GraphQLServer/appsettings.json
```

## Usage

1. Set the DDD.NET.CORE.API as the main project on the presentation layer
2. Open package administrator console, set the default project as DDD.NET.CORE.INFRAESTRUCTURE and apply the following commands:
```bash
add-migration Initial
update-database
```

Nugget libraries used on the DDD project:

```bash
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.Json
Swashbuckle.AspNetCore
```

Nugget libraries used on the GraphQL project:

```bash
HotChocolate.AspNetCore
HotChocolate.AspNetCore.Playground
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
