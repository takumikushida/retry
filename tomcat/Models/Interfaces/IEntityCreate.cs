namespace Iseto.SCIM.Individual.Backend.Cores.Models.Interfaces;

/// <summary>
/// エンティティ登録情報
/// </summary>
public interface IEntityCreate
{
    /// <summary>
    /// 登録日時
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// 登録者
    /// </summary>
    public string CreateBy { get; set; }
}