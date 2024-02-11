﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ResuMeta.Models;

[Table("Resume")]
public partial class Resume
{
    [Key]
    public int Id { get; set; }

    public int? UserInfoId { get; set; }

    [Column("Resume")]
    [MaxLength(1)]
    public byte[]? Resume1 { get; set; }

    [ForeignKey("UserInfoId")]
    [InverseProperty("Resumes")]
    public virtual UserInfo? UserInfo { get; set; }
}