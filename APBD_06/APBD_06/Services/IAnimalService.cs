using APBD_05.Models;

namespace APBD_06.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string sortBy);
}