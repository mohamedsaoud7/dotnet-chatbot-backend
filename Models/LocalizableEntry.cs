using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Models;

[Table("LocalizableEntries", Schema = "mdm")]
public partial class LocalizableEntry
{
    [Key]
    [Column("LLE_Id")]
    public Guid LleId { get; set; }

    [Column("LLE_TimeStamp")]
    public byte[] LleTimeStamp { get; set; } = null!;

    [Column("LLE_LocalizableType_Id")]
    public Guid LleLocalizableTypeId { get; set; }

    [Column("LLE_CreatedDate")]
    public DateTime LleCreatedDate { get; set; }

    [Column("LLE_CreatedBy")]
    [StringLength(250)]
    public string? LleCreatedBy { get; set; }

    [Column("LLE_LastModifiedDate")]
    public DateTime LleLastModifiedDate { get; set; }

    [Column("LLE_LastModifiedBy")]
    [StringLength(250)]
    public string? LleLastModifiedBy { get; set; }

    [InverseProperty("DrLocalizableEntry")]
    public virtual ICollection<DamageReason> DamageReasons { get; set; } = new List<DamageReason>();

    [InverseProperty("LlcLocalizableEntry")]
    public virtual ICollection<LocalizedEntry> LocalizedEntries { get; set; } = new List<LocalizedEntry>();
}
