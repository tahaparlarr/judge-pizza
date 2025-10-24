# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln .
COPY JudgePizzaApp/*.csproj ./JudgePizzaApp/
RUN dotnet restore

COPY JudgePizzaApp/. ./JudgePizzaApp/
WORKDIR /app/JudgePizzaApp
RUN dotnet publish -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "JudgePizzaApp.dll"]