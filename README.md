# DNS Atlas Corporation

DNS is a Service / API built using .NET Core for providing drones a bank location based on location coordinates.

## Prerequisites
```bash
- .NET Core SDK 2.2 https://dotnet.microsoft.com/download
```
## Installation

Steps to run the project

```bash
git clone https://github.com/abomadi/dns-atlas.git
cd DNS-HousingAnywhere
dotnet restore - restoring all dependency packages

RUN THE TESTS
dotnet test HA.DNS.Business.Tests # Run Unit Tests
dotnet test DNS-HousingAnywhere.IntegrationTest # Run Integration Tests

RUN THE APP/API
dotnet run #run the app on dev environment

```

## Docker Support
There is an ready image for docker to pull
```bash
docker pull abomadi/dnshaw:latest
```
Run Docker image using
```bash
docker run -d=false -p 80:80 --name dnshaw abomadi/dnshaw:latest
```

## Usage

```
Acces Api by requesting creating Post http request to
http://localhost/api/dns/getbanklocation

Request Body

Accept: */*
Accept-Encoding: gzip, deflate
Content-Type: application/json
Accept-Language: en-us

{
 "x": "123.12",
 "y": "456.56",
 "z": "789.89",
 "vel": "20.0"
}

Expected Result
{
    "loc": 1389.57
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
