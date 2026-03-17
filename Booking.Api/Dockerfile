# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Booking.Api/Booking.Api.csproj", "Booking.Api/"]
COPY ["Booking.Domain/Booking.Domain.csproj", "Booking.Domain/"]
COPY ["Booking.Infrastructure/Booking.Infrastructure.csproj", "Booking.Infrastructure/"]
COPY ["Booking.Application/Booking.Application.csproj", "Booking.Application/"]

RUN dotnet restore "Booking.Api/Booking.Api.csproj"

COPY . .

RUN dotnet publish "Booking.Api/Booking.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Booking.Api.dll"]