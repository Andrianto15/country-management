<!-- GETTING STARTED -->
## Country Management

### Prerequisites

Below is Nugget Package used in this project.
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Serilog.AspNetCore
- Serilog.Sinks.Console
- Serilog.Sinks.File
- Microsoft.AspNetCore.Authentication.JwtBearer
- System.IdentityModel.Tokens.Jwt

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/Andrianto15/country-management.git
   ```
1. Customize the ``Connection String`` in the ``appSettings.json`` file
1. Open NuGet package Manager Console
1. Type ``add-migration "initial migration"`` and then Enter
1. Type ``update-database`` and then Enter


### Healthcheck API
```sh
https://localhost:7116/health
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>