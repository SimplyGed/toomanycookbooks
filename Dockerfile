FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY toomanycookbooks.csproj .

RUN dotnet restore

COPY . .

RUN dotnet build toomanycookbooks.csproj -c Release -o /app/build


FROM build AS publish

RUN dotnet publish toomanycookbooks.csproj -c Release -o /app/publish


FROM nginx:alpine AS final

ENV DOTNET_ENVIRONMENT=Production
ENV API_URL=https://localhost:7130/API

WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .

CMD chmod +x ./subst.sh
COPY subst.sh /docker-entrypoint.d

COPY nginx.conf /etc/nginx/nginx.conf