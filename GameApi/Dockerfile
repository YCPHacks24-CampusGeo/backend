# Use the .NET 8.0 SDK image as base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG TARGETARCH

# Set the working directory in the container
WORKDIR /app

# Copy the .NET project file and restore dependencies
COPY *.csproj ./

# Copy nuget if present
# COPY NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore -a $TARGETARCH

# Copy the remaining source code
COPY . ./

# Build the application
RUN dotnet publish -a $TARGETARCH -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ARG TARGETARCH

# Set the working directory for the runtime
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build-env /app/out .

# Command to run the application
ENTRYPOINT ["dotnet", "GameApi.dll"]