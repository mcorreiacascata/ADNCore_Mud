// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ADNCORE_MUD.Shared.Models;

public partial class contactotipo
{
    public int contactotipoId { get; set; }

    public string contactotipoNome { get; set; }

    public virtual ICollection<contactocliente> contactocliente { get; } = new List<contactocliente>();
}