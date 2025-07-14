FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY TrainReservation.Api/*.csproj ./TrainReservation.Api/
COPY TrainReservation.Service/*.csproj ./TrainReservation.Service/

RUN dotnet restore

COPY . .
WORKDIR /app/TrainReservation.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/TrainReservation.Api/out .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "TrainReservation.Api.dll"]
