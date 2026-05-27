using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecture.Persistance.Repositories;

public class CarRepository : Repository<Car, AppDbContext>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context) {}
}
