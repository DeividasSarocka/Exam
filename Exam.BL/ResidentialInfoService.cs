using Exam.DAL;

namespace Exam.BL
{
    public class ResidentialInfoService : IResidentialInfoService
    {
        private readonly IDbRepository _dbRepository;
        public ResidentialInfoService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task UpdateCityAsync(string city, int id)
        {
            await _dbRepository.UpdateCityAsync(city, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateStreetNameAsync(string streetName, int id)
        {
            await _dbRepository.UpdateStreetNameAsync(streetName, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateHouseNumberAsync(string houseNumber, int id)
        {
            await _dbRepository.UpdateHouseNumberAsync(houseNumber, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateApartmentNumberAsync(string apartmentNumber, int id)
        {
            await _dbRepository.UpdateApartmentNumberAsync(apartmentNumber, id);
            await _dbRepository.SaveChangesAsync();
        }

    }
}



    
