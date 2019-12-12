using System;
namespace PlantGrower.Models
{
    public class Plant
    {
        public string PlantName {get; set; }
        public int PlantHealth {get; set; }
        public Plant(string name, int health)
        {
            PlantName = name;
            PlantHealth = health;
        }
        public void Water()
        {
            PlantHealth += 2;
        }
        public void Feed()
        {
            PlantHealth += 1;
        }
        public void Sunshine()
        {
            PlantHealth += 3;
        }
        public void Windstorm()
        {
            PlantHealth -= 1;
        }
        public void AphidAttack()
        {
            PlantHealth -= 3;
        }
        public void SlugBite()
        {
            PlantHealth -=2;
        }
    }
}