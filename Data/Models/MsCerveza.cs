using System;
using System.Collections.Generic;

namespace MS_API.Data.Models;

public partial class MsCerveza
{
    public int MsCervezaId { get; set; }

    public string MsCervezaName { get; set; } = null!;

    public string? MsCervezaDescription { get; set; }

    public bool MsEscarchada { get; set; }

    public decimal MsPrice { get; set; }

    public DateTime? MsDate { get; set; }
}
