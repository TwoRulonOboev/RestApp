using System;
using System.Collections.Generic;

namespace ApiforVan.Models;

public partial class Subscriber
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal MonthlyFee { get; set; }

    public virtual ICollection<PaymentRecord> PaymentRecords { get; set; } = new List<PaymentRecord>();
}
