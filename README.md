# hello-dotnet

[![CI](https://github.com/anitouchq/hello-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/anitouchq/hello-dotnet/actions)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)

Учебный CI/CD-проект на C#/.NET. GitHub Actions восстанавливает зависимости, собирает приложение и запускает unit-тесты xUnit. При push тега версии приложение публикуется как самостоятельный executable для Linux x64 и Windows x64.

## CI checks

1. `dotnet restore` — восстановление зависимостей.
2. `dotnet build -c Release` — сборка в конфигурации Release.
3. `dotnet test` — запуск тестов xUnit.

## Release artifacts

| Платформа | Артефакт |
|---|---|
| Linux x64 | `hello-dotnet-linux-x64.tar.gz` |
| Windows x64 | `hello-dotnet-windows-x64.zip` |

Используется self-contained single-file deployment: пользователю не нужно отдельно устанавливать .NET Runtime.

## Как создать Release

```bash
git tag v1.0.0
git push origin v1.0.0
```

Workflow сначала выполняет CI. Затем Linux и Windows runner'ы собирают артефакты параллельно, а отдельный job прикладывает архивы к [GitHub Release](https://github.com/anitouchq/hello-dotnet/releases).

## Локальная разработка

Требуется .NET 10 SDK:

```bash
dotnet restore tests/HelloDotnet.Tests.csproj
dotnet build tests/HelloDotnet.Tests.csproj -c Release
dotnet test tests/HelloDotnet.Tests.csproj -c Release
dotnet run --project src/HelloDotnet.csproj
```

## Структура проекта

| Файл или каталог | Назначение |
|---|---|
| `.github/workflows/ci.yml` | CI-проверки и публикация Linux/Windows Release |
| `src/Program.cs` | Точка входа приложения |
| `src/Greeting.cs` | Логика приветствия |
| `src/HelloDotnet.csproj` | Настройки сборки приложения |
| `tests/GreetingTests.cs` | Unit-тесты логики приветствия |
| `tests/HelloDotnet.Tests.csproj` | Настройки тестового проекта и ссылка на приложение |
| `.gitignore` | Локальные файлы .NET и IDE, исключаемые из Git |

## Результаты

- [GitHub Actions](https://github.com/anitouchq/hello-dotnet/actions)
- [Опубликованные релизы](https://github.com/anitouchq/hello-dotnet/releases)

[Главный каталог CI/CD проектов](https://github.com/anitouchq/CI-CD-Pipelines)

## Скриншоты

Добавьте изображения в каталог `screenshots/`:

- `screenshots/application.png` — пример запуска приложения;
- `screenshots/github-actions-release.png` — успешная сборка Linux и Windows;
- `screenshots/github-release.png` — опубликованный Release с архивами.

![Пример работы приложения](screenshots/application.png)
![Сборка GitHub Actions](screenshots/github-actions-release.png)
![Опубликованный GitHub Release](screenshots/github-release.png)

## Как создать Release-сборку

Убедитесь, что изменения находятся в `main`, после чего создайте и отправьте тег:

```bash
git checkout main
git pull origin main
git tag v1.0.0
git push origin v1.0.0
```

Workflow запускается для тегов `v*`: выполняет restore, build и xUnit tests, затем публикует self-contained single-file сборки для Linux x64 и Windows x64. Готовые архивы появятся в GitHub Release.

Для следующей публикации увеличьте версию, например до `v1.0.1`. Каждый тег должен быть уникальным.

- [GitHub Actions](https://github.com/anitouchq/hello-dotnet/actions)
- [GitHub Releases](https://github.com/anitouchq/hello-dotnet/releases)
