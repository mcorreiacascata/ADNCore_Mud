﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ADNCORE_MUD.Shared.Models;

public partial class chat
{
    public int chatId { get; set; }

    public DateTime chatData { get; set; }

    public int? tarefa_Id { get; set; }

    public int projeto_Id { get; set; }

    public string chatMessage { get; set; }

    public int utilizador_Id { get; set; }

    public virtual projeto projeto { get; set; }

    public virtual tarefa tarefa { get; set; }
}