namespace smartHome
{
    internal class Program
    {
        using System;
using System.Collections.Generic;

namespace HomeIT
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create rooms
            Kitchen kitchen = new Kitchen("Kitchen", 20.0f);
            Bathroom bathroom = new Bathroom("Bathroom", 22.0f);
            LivingRoom livingRoom = new LivingRoom("Living Room", 22.0f);
            Bedroom bedroom = new Bedroom("Bedroom", 18.0f);
            WinterGarden winterGarden = new WinterGarden("Winter Garden", 22.0f);

            // Add actors to rooms
            kitchen.AddActor(new HeatingValve());
            kitchen.AddActor(new JalousieControl());

            bathroom.AddActor(new HeatingValve());

            livingRoom.AddActor(new HeatingValve());
            livingRoom.AddActor(new JalousieControl());

            bedroom.AddActor(new HeatingValve());
            bedroom.AddActor(new JalousieControl());

            winterGarden.AddActor(new MarkiseControl());

            // Add occupants to rooms
            livingRoom.AddOccupant(new Person("Alice"));
            livingRoom.AddOccupant(new Person("Bob"));

            // Create weather sensor and set up simulation
            WeatherSensor weatherSensor = new WeatherSensor();
            int simulationDurationSeconds = 3600; // 1 hour
            for (int i = 0; i < simulationDurationSeconds; i++)
            {
                // Generate weather data and update actors
                WeatherData weatherData = weatherSensor.GenerateData();
                kitchen.UpdateActors(weatherData);
                bathroom.UpdateActors(weatherData);
                livingRoom.UpdateActors(weatherData);
                bedroom.UpdateActors(weatherData);
                winterGarden.UpdateActors(weatherData);

                // Wait for 1 second
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    public abstract class Room
    {
        private string name;
        private float targetTemperature;
        private float currentTemperature;
        private List<Actor> actors;
        private List<Person> occupants;
        private WeatherSensor weatherSensor;

        public Room(string name, float targetTemperature)
        {
            this.name = name;
            this.targetTemperature = targetTemperature;
            this.currentTemperature = targetTemperature;
            this.actors = new List<Actor>();
            this.occupants = new List<Person>();
            this.weatherSensor = new WeatherSensor();
        }

        public void AddActor(Actor actor)
        {
            actors.Add(actor);
        }

        public void AddOccupant(Person person)
        {
            occupants.Add(person);
        }

        public void UpdateActors(WeatherData weatherData)
        {
            currentTemperature = weatherData.Temperature;
            if (currentTemperature < targetTemperature)
            {
                foreach (Actor actor in actors)
                {
                    if (actor is HeatingValve)
                    {
                        actor.Activate();
                    }
                }
            }
            foreach (Person person in occupants)
            {
                if (currentTemperature > targetTemperature && !(this is Bathroom) && !(this is WinterGarden))
                {
                    foreach (Actor actor in actors)
                    {
                        if (actor is JalousieControl)
                        {
                            actor.Activate();
                        }
                    }
                }
            }
        }
    }

    public class Kitchen : Room
    {
        public Kitchen(string name, float targetTemperature) : base(name, targetTemperature) {}
    }

    public class Bathroom : Room
    {
        public Bathroom(string name, float targetTemperature) : base(name, targetTemperature) {}
    }

    public class LivingRoom : Room
    {
           public LivingRoom(string name, float targetTemperature) : base(name, targetTemperature) {}
    }

    public class Bedroom : Room
{
    public Bedroom(string name, float targetTemperature) : base(name, targetTemperature) {}
}

public class WinterGarden : Room
{
    public WinterGarden(string name, float targetTemperature) : base(name, targetTemperature) {}
}

public abstract class Actor
{
    public virtual void Activate()
    {
        Console.WriteLine("Actor activated");
    }
}

public class HeatingValve : Actor
{
    public override void Activate()
    {
        Console.WriteLine("Heating valve activated");
    }
}

public class JalousieControl : Actor
{
    public override void Activate()
    {
        Console.WriteLine("Jalousie control activated");
    }
}

public class MarkiseControl : Actor
{
    public override void Activate()
    {
        Console.WriteLine("Markise control activated");
    }
}

public class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}

public class WeatherSensor
{
    private Random random = new Random();

    public WeatherData GenerateData()
    {
        float temperature = random.Next(-5, 30) + (float)random.NextDouble();
        float humidity = random.Next(0, 100) + (float)random.NextDouble();
        return new WeatherData(temperature, humidity);
    }
}

public class WeatherData
{
    private float temperature;
    private float humidity;

    public WeatherData(float temperature, float humidity)
    {
        this.temperature = temperature;
        this.humidity = humidity;
    }

    public float Temperature
    {
        get { return temperature; }
    }

    public float Humidity
    {
        get { return humidity; }
    }
}
}

}