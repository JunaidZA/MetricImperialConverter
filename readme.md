# Unit Convertor
An API that converts units from Imperial to Metric and vice versa.
Currently supported units are Temperature, Length and Mass

### Temperature
Celsius to Farenheit 
Farenheit to Celsius

### Length
Feet to Metres
Metres to Feet

### Mass
Pounds to Kilograms
Kilograms to Pounds

## Usage

### Requirements
- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

## Contributing

### Database
A SQLite database file is automatically created in the root folder of the API, seeded with initial data directly from the context.

### Hosting
Runs in a Linux Docker container

### New Conversion Types
Any new conversion types will need to be added to the ConversionType enum as well as the DB Context with seed data. 
The format for the conversion formula is any valid math expression with a placeholder of "{value}" for the value to be injected in eg: "{value} + 2 - 5" with a value of 10 would be expressed as "10 + 2 - 5". 

