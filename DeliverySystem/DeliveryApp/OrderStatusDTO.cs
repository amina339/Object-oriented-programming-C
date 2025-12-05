using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract public class DTO { }
public class OrderStatusChangedDto : DTO
{
    public int OrderId { get; set; }
    public string Status { get; set; }
    public OrderStatusChangedDto(int orderId, string status)
    {
        OrderId = orderId;
        Status = status;
    }
}
