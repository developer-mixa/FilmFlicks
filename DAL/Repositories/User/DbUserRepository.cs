using FilmFlicks.DAL.Repositories.Core;
using FilmFlicks.Domain.Repositories;

namespace FilmFlicks.DAL.Repositories.User;

public class DbUserRepository(ApplicationDbContext db)
    : CrudRepository<Domain.Entities.User, long>(db, (user, id) => user.Id == id), IUserRepository;