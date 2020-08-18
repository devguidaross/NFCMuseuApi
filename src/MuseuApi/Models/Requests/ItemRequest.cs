using MuseuApi.Entities;

namespace MuseuApi.Models.Requests
{
    public class ItemRequest : RequestPadrao
    {
        public Item Item { get; set; }
    }
}