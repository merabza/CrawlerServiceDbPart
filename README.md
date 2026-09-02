# CrawlerServiceDbPart

EF Core persistence of [CrawlerService](https://github.com/merabza/CrawlerService): `CrawlerDbContext` (implements `ICrawlerServiceApplicationDbContext` from [CrawlerServiceRoot](https://github.com/merabza/CrawlerServiceRoot)) and the per-entity configurations.

| Project | Purpose |
|---|---|
| `CrawlerServiceDbPart.Db` | `CrawlerDbContext` and `IEntityTypeConfiguration<T>` classes (`Configurations\`) |

EF Core migrations live in a separate repository: [CrawlerServiceDbTools](https://github.com/merabza/CrawlerServiceDbTools).

## Repository layout — sibling repos are required

Projects reference sibling clones by relative path (`..\..\CrawlerServiceRoot\...`, `..\..\SystemTools\...`), so the repositories must be cloned next to each other:

```
<root>\
├── CrawlerServiceDbPart\    this repository (CrawlerServiceDbPart.slnx lives here)
├── CrawlerServiceRoot\      domain entities and abstractions (merabza/CrawlerServiceRoot)
└── SystemTools\             shared libraries (merabza/SystemTools)
```

## Build

```powershell
dotnet build CrawlerServiceDbPart.slnx
```

## License

[MIT](LICENSE)
