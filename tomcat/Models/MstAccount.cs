using Iseto.SCIM.Individual.Backend.Cores.Constants.Enums;
using Iseto.SCIM.Individual.Backend.Cores.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Iseto.SCIM.Individual.Backend.Cores.Constants.Models;

namespace Iseto.SCIM.Individual.Backend.Cores.Models;

/// <summary>
/// 口座マスタ
/// </summary>
[Comment("口座マスタ")]
public class MstAccount : IEntityBase
{
    /// <summary>
    /// 口座ID
    /// </summary>
    [Key, Comment("口座ID")]
    public long Id { get; set; }

    /// <summary>
    /// 口座店番
    /// </summary>
    [Comment("口座店番"), StringLength(Valids.AccountBranchNumberFixedLength, MinimumLength = Valids.AccountBranchNumberFixedLength)]
    public string AccountBranchNumber { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="MstAccountSubject.Code" />
    /// </summary>
    [Comment("口座科目コード")]
    public string AccountSubjectCode { get; set; } = null!;

    /// <summary>
    /// 口座番号
    /// </summary>
    [Comment("口座番号"), StringLength(Valids.AccountNumberFixedLength, MinimumLength = Valids.AccountNumberFixedLength)]
    public string AccountNumber { get; set; } = null!;

    /// <summary>
    /// 口座名義情報
    /// </summary>
    [Comment("口座名義情報"), StringLength(Valids.AccountHolderInfoMaxLength)]
    public string? AccountHolderInfo { get; set; }

    /// <summary>
    /// 口座名義情報カナ
    /// </summary>
    [Comment("口座名義情報カナ"), StringLength(Valids.AccountHolderInfoKanaMaxLength)]
    public string? AccountHolderInfoKana { get; set; }

    /// <summary>
    /// <inheritdoc cref="Constants.Enums.AccountType" />
    /// </summary>
    [Comment("口座区分"), EnumDataType(typeof(AccountType))]
    public AccountType? AccountType { get; set; }

    /// <summary>
    /// <inheritdoc cref="MstCustomer.Id" />
    /// </summary>
    [Comment("顧客ID")]
    public long CustomerId { get; set; }

    /// <summary>
    /// <inheritdoc cref="MstIbUser.Id" />
    /// </summary>
    [Comment("IB利用者ID")]
    public string? IbUserId { get; set; }

    /// <inheritdoc />
    public string CreateBy { get; set; } = null!;

    /// <inheritdoc />
    public DateTime CreateAt { get; set; }

    /// <inheritdoc />
    public string? UpdateBy { get; set; }

    /// <inheritdoc />
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// <inheritdoc cref="MstAccountSubject" />
    /// </summary>
    [ForeignKey(nameof(AccountSubjectCode))]
    public virtual MstAccountSubject AccountSubject { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="MstCustomer" />
    /// </summary>
    [ForeignKey(nameof(CustomerId))]
    public virtual MstCustomer Customer { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="MstIbUser" />
    /// </summary>
    [ForeignKey(nameof(IbUserId))]
    public virtual MstIbUser? IbUser { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="TrnReportDelivery" />
    /// </summary>
    public virtual ICollection<TrnReportDelivery> ReportDeliveries { get; set; } = new List<TrnReportDelivery>();
}