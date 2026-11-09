# 💠 hello-dotnet — .NET 10 → GitHub Releases

Учебный CI/CD-проект на C#/.NET. GitHub Actions восстанавливает зависимости, собирает приложение и запускает xUnit-тесты. По тегу версии приложение публикуется как самостоятельный executable для Linux x64 и Windows x64.

## CI checks

1. `dotnet restore` — восстановление зависимостей.
2. `dotnet build -c Release` — release-сборка.
3. `dotnet test` — модульные тесты xUnit.

## Release artifacts

| Платформа | Артефакт |
|---|---|
| Linux x64 | `hello-dotnet-linux-x64.tar.gz` |
| Windows x64 | `hello-dotnet-windows-x64.zip` |

Публикация использует self-contained single-file deployment: пользователю не нужно отдельно устанавливать .NET Runtime.

## Как создать Release

Отправьте тег вида `v1.0.0`:

```bash
git tag v1.0.0
git push origin v1.0.0
```

Workflow сначала выполняет CI. Затем Linux и Windows runner'ы собирают артефакты параллельно, а последний job прикладывает архивы к GitHub Release.

## Локальная разработка

Требуется .NET 10 SDK:

```bash
dotnet restore tests/HelloDotnet.Tests.csproj
dotnet build tests/HelloDotnet.Tests.csproj -c Release
dotnet test tests/HelloDotnet.Tests.csproj -c Release
dotnet run --project src/HelloDotnet.csproj
```

## Почему .NET 10

Проект использует .NET 10 LTS, а не .NET 8 из старого примера: это актуальная LTS-линия с более длительным периодом поддержки.

## Permissions

Для CI достаточно `contents: read`. Публикационный job получает `contents: write` для создания GitHub Release через встроенный `GITHUB_TOKEN`.

[Главный каталог CI/CD проектов](https://github.com/anitouchq/CI-CD-Pipelines)
