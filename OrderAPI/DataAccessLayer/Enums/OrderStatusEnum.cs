using System;
namespace OrderAPI.DataAccessLayer.Enums
{
    public enum OrderStatusEnum
    {
        InQueue = 1,
        Preparing = 2,
        OrderReady = 3,
        PickedUp = 4,
        Cancelled = 5
    }
}
