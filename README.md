## Scope

This API includes the following:

 - Role based JWT authentication.
 - Web API Helper which standardizes responses, maps errors, etc...
 - An implementation of Serilog for logging.
 - A core library with the following
   - Custom data model attributes
   - Database adapter
   - Helper functions for hashing, encrypting, compression, random number & character generation, etc...
 - A constants library for commonly used constants.

## Notice

**Before using the code in production**

###### Change the following values

 - In appsettings.json
    1. Database connection string.
    2. JWT secret, issuer and audience
 - Update the login controller, user lib & auth lib.
 - In program.cs
   1. Update CORS websites list

###### Remove the following
 - Values controller, values lib & corresponding interfaces
