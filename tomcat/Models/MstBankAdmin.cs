using Iseto.SCIM.Individual.Backend.Cores.Constants.Enums;
using Iseto.SCIM.Individual.Backend.Cores.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Iseto.SCIM.Individual.Backend.Cores.Constants.Models;

namespace Iseto.SCIM.Individual.Backend.Cores.Models;

/// <summary>
/// 銀行管理者マスタ
/// </summary>
[Comment("銀行管理者マスタ")]
public class MstBankAdmin : IdentityUser, IEntityBase
{
    /// <summary>
    /// 銀行管理者ID
    /// </summary>
    [Key, Comment("銀行管理者ID")]
    public override string Id { get => base.Id; set => base.Id = value; }

    /// <summary>
    /// 名前
    /// </summary>
    [Comment("名前"), StringLength(Valids.BankAdminNameMaxLength)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="Constants.Enums.BankAdminType" />
    /// </summary>
    [Comment("銀行管理者区分"), EnumDataType(typeof(BankAdminType))]
    public BankAdminType BankAdminType { get; set; }

    /// <summary>
    /// <inheritdoc cref="Constants.Enums.InitialPasswordChangeStatus" />
    /// </summary>
    [Comment("初期パスワード変更状態"), EnumDataType(typeof(InitialPasswordChangeStatus))]
    public InitialPasswordChangeStatus InitialPasswordChangeStatus { get; set; }

    /// <summary>
    /// <inheritdoc cref="MstAuthority.Id" />
    /// </summary>
    [Comment("権限ID")]
    public long AuthorityId { get; set; }

    /// <summary>
    /// パスワード変更日時
    /// </summary>
    [Comment("パスワード変更日時")]
    public DateTime? PasswordChangeAt { get; set; }

    /// <summary>
    /// 最終ログイン日時
    /// </summary>
    [Comment("最終ログイン日時")]
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// ログインID
    /// </summary>
    [Comment("ログインID")]
    public override string? UserName { get => base.UserName; set => base.UserName = value; }

    /// <summary>
    /// 正規化されたログインID
    /// </summary>
    [Comment("正規化されたログインID")]
    public override string? NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    [Comment("メールアドレス")]
    public override string? Email { get => base.Email; set => base.Email = value; }

    /// <summary>
    /// 正規化されたメールアドレス
    /// </summary>
    [Comment("正規化されたメールアドレス")]
    public override string? NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }

    /// <summary>
    /// メールアドレス認証フラグ
    /// </summary>
    [Comment("メールアドレス認証フラグ")]
    public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

    /// <summary>
    /// パスワードハッシュ
    /// </summary>
    [Comment("パスワードハッシュ")]
    public override string? PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

    /// <summary>
    /// セキュリティスタンプ
    /// <para>ユーザーの資格情報が変更されるたびに変更する必要があるランダムな値 (パスワードの変更、ログインの削除)</para>
    /// </summary>
    [Comment("セキュリティスタンプ")]
    public override string? SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }

    /// <summary>
    /// コンカレンシースタンプ
    /// </summary>
    [Comment("コンカレンシースタンプ")]
    public override string? ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }

    /// <summary>
    /// 電話番号
    /// </summary>
    [Comment("電話番号")]
    public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

    /// <summary>
    /// 電話番号認証フラグ
    /// </summary>
    [Comment("電話番号認証フラグ")]
    public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }

    /// <summary>
    /// 2要素認証有効フラグ
    /// </summary>
    [Comment("2要素認証有効フラグ")]
    public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }

    /// <summary>
    /// ロックアウト終了日時(UTC)
    /// </summary>
    [Comment("ロックアウト終了日時(UTC)")]
    public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }

    /// <summary>
    /// ロックアウト有効フラグ
    /// </summary>
    [Comment("ロックアウト有効フラグ")]
    public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }

    /// <summary>
    /// ログイン失敗回数
    /// </summary>
    [Comment("ログイン失敗回数")]
    public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }

    /// <inheritdoc />
    public string CreateBy { get; set; } = null!;

    /// <inheritdoc />
    public DateTime CreateAt { get; set; }

    /// <inheritdoc />
    public string? UpdateBy { get; set; }

    /// <inheritdoc />
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// <inheritdoc cref="MstAuthority" />
    /// </summary>
    [ForeignKey(nameof(AuthorityId))]
    public virtual MstAuthority Authority { get; set; } = null!;

    /// <summary>
    /// <inheritdoc cref="TrnChangePasswordLog" />
    /// </summary>
    public virtual ICollection<TrnChangePasswordLog> ChangePasswordLogs { get; set; } = new List<TrnChangePasswordLog>();
}