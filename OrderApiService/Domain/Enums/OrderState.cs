using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum OrderState
    {
        RECEIVED,
        PAID,
        UNPAID,
        CUSTOMER_NOTIFIED,
        FINISHED
    }
}
