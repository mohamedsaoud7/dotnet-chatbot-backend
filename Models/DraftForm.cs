using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Models;

[Index("DrfUserName", "DrfDraftName", "DrfDraftNumber", Name = "IX_DraftForms_UserName_DraftName_DraftNumber", IsUnique = true)]
public partial class DraftForm
{
    [Key]
    [Column("DRF_Id")]
    public Guid DrfId { get; set; }

    [Column("DRF_TimeStamp")]
    public byte[] DrfTimeStamp { get; set; } = null!;

    [Column("DRF_UserName")]
    [StringLength(250)]
    public string DrfUserName { get; set; } = null!;

    [Column("DRF_DraftName")]
    [StringLength(50)]
    public string DrfDraftName { get; set; } = null!;

    [Column("DRF_DraftNumber")]
    [StringLength(20)]
    public string? DrfDraftNumber { get; set; }

    [Column("DRF_Json")]
    public string? DrfJson { get; set; }

    [Column("DRF_CreatedDate")]
    public DateTime DrfCreatedDate { get; set; }

    [Column("DRF_CreatedBy")]
    [StringLength(250)]
    public string? DrfCreatedBy { get; set; }

    [Column("DRF_LastModifiedDate")]
    public DateTime DrfLastModifiedDate { get; set; }

    [Column("DRF_LastModifiedBy")]
    [StringLength(250)]
    public string? DrfLastModifiedBy { get; set; }
}
