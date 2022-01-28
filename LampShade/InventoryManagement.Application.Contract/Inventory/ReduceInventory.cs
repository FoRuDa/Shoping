
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class ReduceInventory
    {
        public long InventoryId { get; set; }
        public long ProductId { get; set; }

        [Range(1, 10000000, ErrorMessage = ValidationMessages.IsRequired)]
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }

    }
}