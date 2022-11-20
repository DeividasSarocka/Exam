namespace Exam.BL
{
    public interface IResidentialInfoService
    {
        Task UpdateCityAsync(string city, int id);
        Task UpdateStreetNameAsync(string streetName, int id);
        Task UpdateHouseNumberAsync(string houseNumber, int id);
        Task UpdateApartmentNumberAsync(string apartmentNumber, int id);
    }
}
