#any other version throws sdk command error
FROM microsoft/aspnetcore-build:2.0

ARG source

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build

RUN dotnet publish -c Release -o ./obj/Docker/publish

EXPOSE 80
#make sure obj/Docker/publish folder exists in side d project
COPY ${source:-app/obj/Docker/publish} .


ENTRYPOINT ["dotnet", "Wercker.TeamService.dll"]
