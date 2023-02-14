# SmartHome

<br>

## Klassendiagramm

<br>

      +-------------------------------------+
      |                 Room                |
      +-------------------------------------+
      | - name: string                      |
      | - targetTemperature: float          |
      | - currentTemperature: float         |
      | - actors: List<Actor>               |
      | - occupants: List<Person>           |
      | - weatherSensor: WeatherSensor      |
      +-------------------------------------+
      | + setTargetTemperature(temp: float) |
      | + addActor(actor: Actor)            |
      | + addOccupant(occupant: Person)     |
      | + updateTemperature()               |
      | + updateActors()                    |
      +-------------------------------------+

      +-------------------------------------+
      |                Kitchen              |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |             BathroomWC              |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |              LivingRoom             |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |             Bedroom                 |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |            Conservatory             |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |                Actor                |
      +-------------------------------------+
      | - id: string                        |
      | - room: Room                        |
      +-------------------------------------+
      | + getId(): string                   |
      | + getRoom(): Room                   |
      | + update(weather: WeatherData)      |
      +-------------------------------------+

      +-------------------------------------+
      |           HeatingValve              |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |           JalousieControl           |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |          MarkiseControl             |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |               Person                |
      +-------------------------------------+
      |                                     |
      +-------------------------------------+

      +-------------------------------------+
      |            WeatherSensor            |
      +-------------------------------------+
      | - weatherData: WeatherData          |
      +-------------------------------------+
      | + generateData()                    |
      | + getWeatherData(): WeatherData     |
      +-------------------------------------+

      +-------------------------------------+
      |            WeatherData              |
      +-------------------------------------+
      | - temperature: float                |
      | - windSpeed: float                  |
      | - isRaining: boolean                |
      +-------------------------------------+
      | + getTemperature(): float           |
      | + getWindSpeed(): float             |
      | + isRaining(): boolean              |
      +-------------------------------------+
 
 
 
 <br>

## Unit Test

---
Da ich leider nicht mein git auf Visual Studio clonen konnte hier unten noch mein Unit Test code vorhanden.
---


            using NUnit.Framework;

            [TestFixture]
            public class ExampleTest
            {
                [Test]
                public void TestAddition()
                {
                    // Arrange
                    int a = 3;
                    int b = 4;

                    // Act
                    int result = a + b;

                    // Assert
                    Assert.AreEqual(7, result);
                }
            }

