﻿using APBD_03.Model;
using APBD_03.Repositories;

namespace APBD_03.Services;

public class AnimalService
{
    private readonly IAnimalService _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimal()
    {
        //Business logic
        return _animalRepository.GetAnimal();
    }
    
    public int CreateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.CreateAnimal(animal);
    }

    public Animal? GetAnimal(int idAnimal)
    {
        //Business logic
        return _animalRepository.GetAnimal(idAnimal);
    }

    public int UpdateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        //Business logic
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}