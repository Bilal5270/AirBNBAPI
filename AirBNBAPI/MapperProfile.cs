using AutoMapper;
using AirBNBAPI.Model;
using AirBNBAPI.Model.DTO;
using AirBnb.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Location, LocationDto>()
                .ForMember(d => d.LandlordAvatarURL, opt => opt.MapFrom(s => s.Landlord.Avatar.Url))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Images.FirstOrDefault(img => img.IsCover).Url))
                .ForMember(d => d.SubTitle, opt => opt.MapFrom(s => s.SubTitle))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
