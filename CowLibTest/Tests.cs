using System;
using CowLib.Factory;
using NUnit.Framework;
using QuickType;


namespace CowLibTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //Creates a new entity factory where you can add components, component groups, events, etc.
            EntityFactory factory = new EntityFactory("dragon_entity");
            // Adds a new component group called "goals"
            Components goalsGroup = factory.createComponentGroup("goals");

            // All the components are already in the schema, so autocompletion works perfectly
            goalsGroup.MinecraftAttack = new MinecraftAttack();
            
            // Sets the attack damage of the entity. The schema automatically defines implicit operators for each union type
            // In other words, you can set the damage to either a number, a number array, or a range schema
            goalsGroup.MinecraftAttack.Damage = 5;
            goalsGroup.MinecraftAttack.Damage = new double[] {5, 4};
            RangeSchema attackRange = new RangeSchema();
            attackRange.RangeMin = 5;
            attackRange.RangeMax = 10;
            goalsGroup.MinecraftAttack.Damage = attackRange;

            // Do this to convert the whole entity to a string
            string asString = factory.ToString();
            Console.WriteLine(asString);
            
            // Or this to save it to a properly named file, in this case it automatically goes in the right folder and becomes "dragon.entity.json"
            factory.saveFile();
        }
    }
}