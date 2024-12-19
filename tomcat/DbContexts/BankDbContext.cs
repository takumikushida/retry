using Iseto.SCIM.Individual.Backend.Cores.Constants;
using Iseto.SCIM.Individual.Backend.Cores.Data;
using Iseto.SCIM.Individual.Backend.Cores.Extensions;
using Iseto.SCIM.Individual.Backend.Cores.Models;
using Iseto.SCIM.Individual.Backend.Cores.Settings.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iseto.SCIM.Individual.Backend.Cores.DbContexts;

/// <summary>
/// DBコンテキスト
/// </summary>
public class BankDbContext : IdentityUserContext<MstBankAdmin>
{
    private readonly IDbSetting _dbSetting;
    private readonly RequestData _requestData;
    private readonly ILoggerFactory _loggerFactory;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BankDbContext(DbContextOptions<BankDbContext> options, IDbSetting dbSetting, RequestData requestData, ILoggerFactory loggerFactory) : base(options)
    {
        this._dbSetting = dbSetting;
        this._requestData = requestData;
        this._loggerFactory = loggerFactory;
    }

    #region Entity

    /// <inheritdoc cref="MstAccount" />
    public virtual DbSet<MstAccount> MstAccounts { get; set; }

    /// <inheritdoc cref="MstAccountSubject" />
    public virtual DbSet<MstAccountSubject> MstAccountSubjects { get; set; }

    /// <inheritdoc cref="MstAuthority" />
    public virtual DbSet<MstAuthority> MstAuthorities { get; set; }

    /// <inheritdoc cref="MstBankAdminOperation" />
    public virtual DbSet<MstBankAdminOperation> MstBankAdminOperations { get; set; }

    /// <inhetitdoc cref="MstBankAdmin" />
    public virtual DbSet<MstBankAdmin> MstBankAdmins { get; set; }

    /// <inheritdoc cref="MstBank" />
    public virtual DbSet<MstBank> MstBanks { get; set; }

    /// <inheritdoc cref="MstBatch" />
    public virtual DbSet<MstBatch> MstBatches { get; set; }

    /// <inheritdoc cref="MstCustomer" />
    public virtual DbSet<MstCustomer> MstCustomers { get; set; }

    /// <inheritdoc cref="MstHoliday" />
    public virtual DbSet<MstHoliday> MstHolidays { get; set; }

    /// <inheritdoc cref="MstIbUserOperation" />
    public virtual DbSet<MstIbUserOperation> MstIbUserOperations { get; set; }

    /// <inheritdoc cref="MstIbUser" />
    public virtual DbSet<MstIbUser> MstIbUsers { get; set; }

    /// <inheritdoc cref="MstMailTemplate" />
    public virtual DbSet<MstMailTemplate> MstMailTemplates { get; set; }

    /// <inheritdoc cref="MstProductCategory" />
    public virtual DbSet<MstProductCategory> MstProductCategories { get; set; }

    /// <inheritdoc cref="MstReport" />
    public virtual DbSet<MstReport> MstReports { get; set; }

    /// <inheritdoc cref="TrnBankAdminOperationLog" />
    public virtual DbSet<TrnBankAdminOperationLog> TrnBankAdminOperationLogs { get; set; }

    /// <inheritdoc cref="TrnChangePasswordLog" />
    public virtual DbSet<TrnChangePasswordLog> TrnChangePasswordLogs { get; set; }

    /// <inheritdoc cref="TrnIbUserOperationLog" />
    public virtual DbSet<TrnIbUserOperationLog> TrnIbUserOperationLogs { get; set; }

    /// <inheritdoc cref="TrnIbUserReportDownload" />
    public virtual DbSet<TrnIbUserReportDownload> TrnIbUserReportDownloads { get; set; }

    /// <inheritdoc cref="TrnReportDelivery" />
    public virtual DbSet<TrnReportDelivery> TrnReportDeliveries { get; set; }

    /// <inheritdoc cref="TrnReportDeliverySwitchApplicationLogDetail" />
    public virtual DbSet<TrnReportDeliverySwitchApplicationLogDetail> TrnReportDeliverySwitchApplicationLogDetails { get; set; }

    /// <inheritdoc cref="TrnReportDeliverySwitchApplicationLog" />
    public virtual DbSet<TrnReportDeliverySwitchApplicationLog> TrnReportDeliverySwitchApplicationLogs { get; set; }

    /// <inheritdoc cref="TrnReportPublishmentApplicationLog" />
    public virtual DbSet<TrnReportPublishmentApplicationLog> TrnReportPublishmentApplicationLogs { get; set; }

    /// <inheritdoc cref="TrnReportPublishment" />
    public virtual DbSet<TrnReportPublishment> TrnReportPublishments { get; set; }

    /// <inheritdoc cref="TrnSendMailLog" />
    public virtual DbSet<TrnSendMailLog> TrnSendMailLogs { get; set; }

    #endregion Entity

    /// <summary>
    /// 下記事前処理後変更内容保存
    /// <para />
    /// - <inheritdoc cref="DbContextExtension.SetBaseColumn" />
    /// </summary>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.ChangeTracker.SetBaseColumn(by: this._requestData.CurrentUserId ?? Core.SystemUserName, at: DateTime.Now);

        return base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureDbContext(this._dbSetting.BankDbConnectionString(this._requestData.BankCode), this._loggerFactory);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureModel();
    }
}