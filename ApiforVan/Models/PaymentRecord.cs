using System;
using System.Collections.Generic;

namespace ApiforVan.Models;

public partial class PaymentRecord
{
    public int Id { get; set; }

    public int SubscriberId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal DebtOrOverpayment { get; set; }

    public virtual Subscriber Subscriber { get; set; } = null!;
}
