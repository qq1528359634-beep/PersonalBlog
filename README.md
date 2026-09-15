# PersonalBlog
My Personal Blog
## 技术栈
C# / .NET 10 / ASP.NET Core / Razor Pages
Entity Framework Core / PostgreSQL / Docker

## 核心功能
✓ 博客文章 CRUD
✓ Markdown 编辑与渲染
✓ 管理员登录认证
✓ 评论功能
✓ PostgreSQL 数据持久化
✓ Docker 容器化部署

## 系统架构

Browser → Razor Pages/Controller → Service Layer → Entity Framework Core → PostgreSQL

## 我的实现

- 使用 ASP.NET Core 构建 Web 应用
- 使用 Dependency Injection 管理 Service
- 使用 EF Core + PostgreSQL 实现数据持久化
- 使用 Cookie Authentication 实现管理员认证
- 使用 EF Core Migration 管理数据库结构

## 技术上的实践

### Service Layer

PostService 将文章相关业务逻辑与页面层分离。

### Database

通过 EF Core 操作 PostgreSQL，并在应用启动时自动执行 Migration。

### Authentication

使用 ASP.NET Core Cookie Authentication
保护 Admin 页面。
