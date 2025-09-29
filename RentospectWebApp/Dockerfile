# Stage 1: Build the Blazor app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY RentospectWebApp/RentospectWebApp.csproj RentospectWebApp/
COPY RentospectWebShared/RentospectShared.csproj RentospectWebShared/
RUN dotnet restore RentospectWebApp/RentospectWebApp.csproj

# Copy the rest of the source code and build
COPY . .
RUN dotnet publish RentospectWebApp/RentospectWebApp.csproj -c Release -o /app/publish

# Stage 2: Serve with Nginx
FROM nginx:alpine
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80
EXPOSE 80
