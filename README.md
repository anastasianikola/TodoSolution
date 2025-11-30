# Todo.Core Library

Простая библиотека для управления списком задач с поддержкой JSON-персистенции.

## Установка

### Добавление источника пакетов

1. В Visual Studio: **Tools ? NuGet Package Manager ? Package Manager Settings**
2. Добавьте новый источник:
   - Name: `GitHub Packages`
   - Source: `https://nuget.pkg.github.com/ВАШ_USERNAME/index.json`
3. Для аутентификации используйте:
   - Username: ваш GitHub username
   - Password: Personal Access Token (с scope `read:packages`)

### Установка пакета

```bash
dotnet add package Todo.Core --version 0.1.0