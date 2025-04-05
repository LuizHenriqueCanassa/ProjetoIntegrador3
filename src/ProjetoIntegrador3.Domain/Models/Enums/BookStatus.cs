using System.ComponentModel;

namespace ProjetoIntegrador3.Domain.Models.Enums;

public enum BookStatus
{
    [Description("Disponível")]
    Available = 0,
    [Description("Emprestado")]
    Loaned = 1
}