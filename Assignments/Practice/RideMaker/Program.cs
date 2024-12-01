Vehicle sportsCar = new("Ferrari", "red");
Vehicle pony = new("Spirit", "brown");
Vehicle tricycle = new("Speedster", "black");
Vehicle sailboat = new("Voyager", "white");

List<Vehicle> transportList = new() { sportsCar, pony, tricycle, sailboat };

foreach (Vehicle transport in transportList)
{
    transport.ShowInfo();
}

tricycle.Travel(100);
tricycle.ShowInfo();
