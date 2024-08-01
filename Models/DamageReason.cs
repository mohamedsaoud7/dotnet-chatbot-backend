using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Models;

[Table("DamageReasons", Schema = "pdc")]
public partial class DamageReason
{
    [Key]
    [Column("DR_Id")]
    public Guid DrId { get; set; }

    [Column("DR_TimeStamp")]
    public byte[] DrTimeStamp { get; set; } = null!;

    [Column("DR_Code")]
    [StringLength(10)]
    public string DrCode { get; set; } = null!;

    [Column("DR_ShortName")]
    [StringLength(20)]
    public string? DrShortName { get; set; }

    [Column("DR_LongName")]
    [StringLength(250)]
    public string DrLongName { get; set; } = null!;

    [Column("DR_Inactive")]
    public bool DrInactive { get; set; }

    [Column("DR_LocalizableEntry_Id")]
    public Guid? DrLocalizableEntryId { get; set; }

    [Column("DR_IsMain")]
    public bool DrIsMain { get; set; }

    [Column("DR_CreatedDate")]
    public DateTime DrCreatedDate { get; set; }

    [Column("DR_CreatedBy")]
    [StringLength(250)]
    public string? DrCreatedBy { get; set; }

    [Column("DR_LastModifiedDate")]
    public DateTime DrLastModifiedDate { get; set; }

    [Column("DR_LastModifiedBy")]
    [StringLength(250)]
    public string? DrLastModifiedBy { get; set; }

    [ForeignKey("DrLocalizableEntryId")]
    [InverseProperty("DamageReasons")]
    public virtual LocalizableEntry? DrLocalizableEntry { get; set; }
}
