FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY toomanycookbooks.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish toomanycookbooks.csproj -c Release -o /app/publish


FROM nginx:alpine AS final

ENV DOTNET_ENVIRONMENT=Production
ENV API_URL=https://localhost:7130/API

COPY --from=build /src/subst.sh /docker-entrypoint.d/subst.sh
RUN chmod +x /docker-entrypoint.d/subst.sh

WORKDIR /usr/share/nginx/html

COPY --from=build /app/publish/wwwroot/ .
COPY nginx.conf /etc/nginx/nginx.conf