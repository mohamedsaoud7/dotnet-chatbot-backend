using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Models;

[Table("LocalizedEntries", Schema = "mdm")]
[Index("LlcLocalizableEntryId", Name = "IX_LocalizedEntries_LocalizableEntry_Id")]
public partial class LocalizedEntry
{
    [Key]
    [Column("LLC_Id")]
    public Guid LlcId { get; set; }

    [Column("LLC_TimeStamp")]
    public byte[] LlcTimeStamp { get; set; } = null!;

    [Column("LLC_LocalizableEntry_Id")]
    public Guid LlcLocalizableEntryId { get; set; }

    [Column("LLC_CultureCode")]
    [StringLength(10)]
    public string LlcCultureCode { get; set; } = null!;

    [Column("LLC_ShortTranslation")]
    [StringLength(20)]
    public string? LlcShortTranslation { get; set; }

    [Column("LLC_LongTranslation")]
    [StringLength(250)]
    public string LlcLongTranslation { get; set; } = null!;

    [Column("LLC_CreatedDate")]
    public DateTime LlcCreatedDate { get; set; }

    [Column("LLC_CreatedBy")]
    [StringLength(250)]
    public string? LlcCreatedBy { get; set; }

    [Column("LLC_LastModifiedDate")]
    public DateTime LlcLastModifiedDate { get; set; }

    [Column("LLC_LastModifiedBy")]
    [StringLength(250)]
    public string? LlcLastModifiedBy { get; set; }

    [ForeignKey("LlcLocalizableEntryId")]
    [InverseProperty("LocalizedEntries")]
    public virtual LocalizableEntry LlcLocalizableEntry { get; set; } = null!;
}
