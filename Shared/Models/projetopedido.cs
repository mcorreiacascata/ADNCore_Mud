// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ADNCORE_MUD.Shared.Models;

public partial class projetopedido
{
    public int projetopedidoId { get; set; }

    public string projetopedidoNumero { get; set; }

    public decimal? projetopedidoValorprevisto { get; set; }

    public decimal? projetopedidoIncentivoprevisto { get; set; }

    public decimal? projetopedidoValoraceite { get; set; }

    public decimal? projetopedidoIncentivoaceite { get; set; }

    public DateTime? projetopedidoDatasubmissao { get; set; }

    public DateTime? projetopedidoDatadecisao { get; set; }

    public DateTime? projetopedidoDatapagamento { get; set; }

    public int projeto_Id { get; set; }

    public int projetopedidotipo_Id { get; set; }

    public virtual projeto projeto { get; set; }

    public virtual projetopedidotipo projetopedidotipo { get; set; }
}