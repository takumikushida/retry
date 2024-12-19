namespace Iseto.SCIM.Individual.Backend.Cores.Models.Interfaces;

/// <summary>
/// エンティティ更新情報
/// </summary>
public interface IEntityUpdate
{
    /// <summary>
    /// 更新日時
    /// </summary>
    public DateTime? UpdateAt { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    public string? UpdateBy { get; set; }
}