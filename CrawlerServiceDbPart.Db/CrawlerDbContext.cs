using CrawlerServiceRoot.Application.Abstractions;
using CrawlerServiceRoot.Domain.Batches;
using CrawlerServiceRoot.Domain.BatchParts;
using CrawlerServiceRoot.Domain.ContentsAnalysis;
using CrawlerServiceRoot.Domain.ExtensionModels;
using CrawlerServiceRoot.Domain.HostModels;
using CrawlerServiceRoot.Domain.HostsByBatches;
using CrawlerServiceRoot.Domain.Robots;
using CrawlerServiceRoot.Domain.SchemeModels;
using CrawlerServiceRoot.Domain.TaskModels;
using CrawlerServiceRoot.Domain.TaskStartPoints;
using CrawlerServiceRoot.Domain.Terms;
using CrawlerServiceRoot.Domain.TermsByUrls;
using CrawlerServiceRoot.Domain.TermTypes;
using CrawlerServiceRoot.Domain.UrlGraphNodes;
using CrawlerServiceRoot.Domain.UrlModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SystemTools.DatabaseToolsShared;

namespace CrawlerServiceDbPart.Db;

public sealed class CrawlerDbContext : DbContext, ICrawlerServiceApplicationDbContext
{
    public CrawlerDbContext(DbContextOptions<CrawlerDbContext> options) : base(options)
    {
    }

    //public CrawlerDbContext(DbContextOptions<CrawlerDbContext> options, bool isDesignTime): base(options)
    //{

    //}

    public DbSet<Batch> Batches => Set<Batch>();
    public DbSet<BatchPart> BatchParts => Set<BatchPart>();
    public DbSet<ContentAnalysis> ContentsAnalysis => Set<ContentAnalysis>();
    public DbSet<ExtensionModel> Extensions => Set<ExtensionModel>();
    public DbSet<HostByBatch> HostsByBatches => Set<HostByBatch>();
    public DbSet<HostModel> Hosts => Set<HostModel>();
    public DbSet<Robot> Robots => Set<Robot>();
    public DbSet<SchemeModel> Schemes => Set<SchemeModel>();
    public DbSet<Term> Terms => Set<Term>();
    public DbSet<TermByUrl> TermsByUrls => Set<TermByUrl>();
    public DbSet<TermType> TermTypes => Set<TermType>();
    public DbSet<UrlGraphNode> UrlGraphNodes => Set<UrlGraphNode>();

    public DbSet<UrlModel> Urls => Set<UrlModel>();
    //public DbSet<UrlAllowModel> UrlAllows => Set<UrlAllowModel>();

    public DbSet<TaskModel> Tasks => Set<TaskModel>();
    public DbSet<TaskStartPoint> TaskStartPoints => Set<TaskStartPoint>();

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new DatabaseEntitiesDefaultConvention());
    }
}
