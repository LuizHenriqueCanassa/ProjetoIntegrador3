using System.ComponentModel;

namespace ProjetoIntegrador3.Domain.Models.Enums;

public enum LoanStatus
{
    [Description("AGUARDANDO_RETIRADA")]
    WAITING_WITHDRAWN = 1,
    [Description("ALUGUEL_VIGENTE")]
    CURRENT_RENT = 2,
    [Description("DEVOLUCAO_EM_ATRASO")]
    RETURN_LATE = 3,
    [Description("DEVOLVIDO")]
    RETURNED = 4,
    [Description("CANCELADO")]
    CANCELLED = 5
}