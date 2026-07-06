# 构建阶段
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
# 复制项目文件并还原依赖
COPY *.csproj .
RUN dotnet restore
# 复制所有文件并构建
COPY . .
RUN dotnet publish -c Release -o /app/publish
# 运行阶段
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PersonalBlog.dll"]