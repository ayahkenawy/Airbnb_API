using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using AutoMapper;

namespace API_Airbnb.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ArPromoCodes, PromoCodeDTO>();
            CreateMap<PromoCodeDTO, ArPromoCodes>();
            CreateMap<ArCities, CityReadDTO>();
            CreateMap<ArCountries, CountryReadDTO>();
            CreateMap<ArTransactions, ArTransactionsChildReadDTO>();
            CreateMap<ArPropertyImages, PropertyImageChildDTO>();
            CreateMap<ArPropertyReviews, PropertyReviewsChildDTO>();
            CreateMap<ArProperties, PropertyChildDTO>();
            CreateMap<ArCurrencies, ArCurrenciesChildReadDTO>();
            CreateMap<ArPromoCodes, PromoCodeTransDTO>();
            CreateMap<ArProperties, PropertyDTO>();
            CreateMap<PropertyDTO, ArProperties>();
            CreateMap<ArDisputes, DisputeDTO>();
            CreateMap<DisputeDTO, ArDisputes>();
            CreateMap<ArDisputes, DisputeReadDTO>();
            CreateMap<ArRoomType, RoomTypeReadDTO>();
            CreateMap<RoomTypeWriteDTO, ArRoomType>();
            CreateMap<CategoryWriteDTO, ArCategories>();
            CreateMap<SubCategoryWriteDTO, ArSubcategories>();
            CreateMap<ArPromoCodes, PromoCodeReadDTO>();
            CreateMap<ArProperties, PropertyReadDTO>();
            CreateMap<ArPropertyReviews, PropertyReviewsReadDTO>();
            CreateMap<ArPropertyReviews, PropertyReviewsDTO>();
            CreateMap<PropertyReviewsDTO, ArPropertyReviews>();
            CreateMap<ArCategories, CategoriesReadDTO>();
            CreateMap<ArSubcategories, SubcategoriesReadDTO>();
            CreateMap<ArPropertyType, PropertyTypeReadDTO>();
            CreateMap<PropertyTypeWriteDTO, ArPropertyType>();
            CreateMap<ArBookings, BookingsReadDTO>();
            CreateMap<BookingsDTO, ArBookings>();
            CreateMap<ArCurrencies, ArCurrenciesReadDTO>();
            CreateMap<ArCurrenciesWriteDTO, ArCurrencies>();
            CreateMap<ArTransactions, TransactionsReadDTO>();
            CreateMap<ArPropertyImages, PropertyImagesReadDTO>();
            CreateMap<TransactionsWriteDTO, ArTransactions>();
            CreateMap<PropertyImagesWriteDTO, ArPropertyImages>();
            CreateMap<ArUsers, ArUserDTO>();
            CreateMap<ArCities, CityReadDTO>();
            CreateMap<ArCountries, CountryReadDTO>();
            CreateMap<ArCurrencies, ArCurrenciesChildReadDTO>();


    }
    }
}
