FROM microsoft/dotnet:1.1.1-runtime

ENV ASPNETCORE_ENVIRONMENT Production

COPY ContactsManager /app
WORKDIR /app

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]