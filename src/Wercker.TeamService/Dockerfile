#any other version throws sdk command error
FROM microsoft/aspnetcore-build:2.0

ARG source

WORKDIR /app

EXPOSE 80
#make sure obj/Docker/publish folder exists in side d project
COPY ${source:-obj/Docker/publish} .


ENTRYPOINT ["dotnet", "Wercker.TeamService.dll"]
