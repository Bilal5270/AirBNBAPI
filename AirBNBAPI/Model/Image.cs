using AirBnb.Model;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AirBNBAPI.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Landlord? Landlord { get; set; }
        public bool IsCover { get; set; }
        public int? LocationId { get; set; }
    }
}
