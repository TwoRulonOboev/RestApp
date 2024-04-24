using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiforVan.Models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? EMail { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Password { get; set; }
}
