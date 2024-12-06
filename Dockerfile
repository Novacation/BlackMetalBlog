FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install ICU package for full globalization support

RUN apt-get update \
    && apt-get install -y curl gnupg \
    && curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

COPY . /source

WORKDIR /source

# Restore dependencies with caching
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore

ARG TARGETARCH

RUN bash -c "dotnet publish -a \${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app"




FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app .

USER $APP_UID

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

# Run the application
ENTRYPOINT ["dotnet", "BlackMetalBlog.dll"]
