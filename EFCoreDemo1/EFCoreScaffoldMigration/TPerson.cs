using System;
using System.Collections.Generic;

namespace EFCoreScaffoldMigration;

/// <summary>
/// 角色表
/// </summary>
public partial class TPerson
{
    /// <summary>
    /// 主键
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 年龄
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// 出生地
    /// </summary>
    public string BirthPlace { get; set; } = null!;
}
