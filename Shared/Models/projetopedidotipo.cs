﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ADNCORE_MUD.Shared.Models;

public partial class projetopedidotipo
{
    public int projetopedidotipoId { get; set; }

    public string projetopedidotipoNome { get; set; }

    public string projetopedidotipoSigla { get; set; }

    public virtual ICollection<projetopedido> projetopedido { get; } = new List<projetopedido>();
}