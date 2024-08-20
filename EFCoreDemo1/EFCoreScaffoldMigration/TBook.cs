using System;
using System.Collections.Generic;

namespace EFCoreScaffoldMigration;

/// <summary>
/// 书本表
/// </summary>
public partial class TBook
{
    /// <summary>
    /// 主键
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// 发布日期
    /// </summary>
    public DateTime PubTime { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// 作者名
    /// </summary>
    public string AuthName { get; set; } = null!;
}
