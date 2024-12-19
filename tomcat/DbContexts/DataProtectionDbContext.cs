using Iseto.SCIM.Individual.Backend.Cores.Extensions;
using Iseto.SCIM.Individual.Backend.Cores.Settings.Interfaces;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iseto.SCIM.Individual.Backend.Cores.DbContexts;

/// <inheritdoc cref="IDataProtectionKeyContext" />
public class DataProtectionDbContext : DbContext, IDataProtectionKeyContext
{
    private readonly IDbSetting _dbSetting;
    private readonly ILoggerFactory _loggerFactory;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public DataProtectionDbContext(DbContextOptions<DataProtectionDbContext> options, IDbSetting setting, ILoggerFactory loggerFactory) : base(options)
    {
        this._dbSetting = setting;
        this._loggerFactory = loggerFactory;
    }

    /// <inheritdoc />
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureDbContext(this._dbSetting.DataProtectionDbConnectionString, this._loggerFactory);
    }
}