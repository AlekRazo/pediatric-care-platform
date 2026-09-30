# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the project files (.csproj) first
COPY Pediatria.Domain/Pediatria.Domain.csproj Pediatria.Domain/
COPY Pediatria.Application/Pediatria.Application.csproj Pediatria.Application/
COPY Pediatria.Infrastructure/Pediatria.Infrastructure.csproj Pediatria.Infrastructure/
COPY Pediatria.WebAPI/Pediatria.WebAPI.csproj Pediatria.WebAPI/
COPY Pediatria.slnx .

RUN dotnet restore Pediatria.WebAPI/Pediatria.WebAPI.csproj

# Copy everything and publish
COPY . .
WORKDIR "/src/Pediatria.WebAPI"
RUN dotnet publish "Pediatria.WebAPI.csproj" -c Release -o /app/publish \
--no-restore \
/p:UseAppHost=false

# Stage 2 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Create a non-root user for security
# RUN adduser --disabled-password --gecos "" appuser
# USER appuser
USER $APP_UID

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Pediatria.WebAPI.dll"]