# 构建阶段
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src/PersonalBlog
# 复制项目文件并还原依赖  源路径+目标路径
COPY PersonalBlog/*.csproj PersonalBlog/
RUN dotnet restore PersonalBlog/*.csproj
# 复制所有文件并构建
COPY PersonalBlog/. PersonalBlog/
RUN dotnet publish -c Release -o /app/publish
# 运行阶段
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PersonalBlog.dll"]