using System;
namespace Core
{
    public class BEBike
    {
        public int Id { get; set; }
        public string Brand { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Price { get; set; } = 0;
        public string? ImageUrl { get; set; } = String.Empty;
    }
}

