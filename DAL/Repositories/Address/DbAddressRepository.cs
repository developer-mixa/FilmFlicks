using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.Address;

public class DbAddressRepository(ApplicationDbContext db) 
    : CrudRepository<Domain.Entities.AddressEntity, long>(db, (address, id) => address.Id == id), IAddressRepository;