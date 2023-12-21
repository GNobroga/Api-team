FROM mcr.microsoft.com/dotnet/sdk:7.0 AS stage

WORKDIR /api 

COPY . .

RUN dotnet publish -c Release -o ./publish 

FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app 

COPY --from=stage /api/publish .

EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT [ "dotnet" ]

CMD ["api-team.dll"]