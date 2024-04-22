using APBD_05.Models;

namespace APBD_06.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(Animal animal);
    void EditAnimal(Animal animal1);
    void DeleteAnimal(int id);
}