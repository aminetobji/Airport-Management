// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using static AM.ApplicationCore.Services.PassengerExtension;
//Console.WriteLine("Hello, World!");

//TP1-Q7: Créer un objet de type Plane en utilisant le constructeur non paramétré
Plane plane1 = new Plane();
plane1.PlaneType = PlaneType.Airbus;
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2018, 11, 10);

////TP1-Q8: Créer un objet de type Plane en utilisant le constructeur paramétré
//Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);

////TP1-Q9: Créer un objet de type Plane en utilisant l'initialiseur d'objet
//Plane plane3 = new Plane
//{
//    PlaneType = PlaneType.Airbus,
//    Capacity = 150,
//    ManufactureDate = new DateTime(2015, 02, 03)
//};

Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");
Passenger p1 = new Passenger { FullName=new FullName { FirstName="steave", LastName="jobs" }, EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
Console.WriteLine("La méthode CheckProfile:");
Console.WriteLine(p1.CheckProfile("steave", "jobs"));
Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail.com"));

Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");
Staff s1 = new Staff { FullName = new FullName { FirstName = "Bill", LastName = "Gates" }, EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };
Traveller t1 = new Traveller { FullName = new FullName { FirstName = "Mark", LastName = "Zuckerburg" }, EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };
Console.WriteLine("La méthode PassengerType p1:");
p1.PassengerType();
Console.WriteLine("La méthode PassengerType s1:");
s1.PassengerType();
Console.WriteLine("La méthode PassengerType t1:");
t1.PassengerType();

//TP 2
FlightMethods _flightMethods = new FlightMethods();
_flightMethods.Flights = TestData.listFlights;
//test methode de GetFlightDates
_flightMethods.GetFlightDates("Paris");
//test de GetFlight
_flightMethods.GetFlights("Destination", "Madrid");
//test de ShowFlightDetails
_flightMethods.ShowFlightDetails(plane1);
//test ogrammedFlightNumber
_flightMethods.ProgrammedFlightNumber(new DateTime(1945, 01, 01));

Console.WriteLine("------------------------");
//test DurationAverage
_flightMethods.DurationAverage("Madrid");
//test OrderedDurationFlights
_flightMethods.OrderedDurationFlights();

//test de DestinationGroupedFlights
_flightMethods.DestinationGroupedFlights();

Console.WriteLine("Avec delege _flightDetailsDel");
FlightMethods_2.FlightDetailsDel _flightDetailsDel= _flightMethods.ShowFlightDetails;

_flightDetailsDel(plane1);

Console.WriteLine("Avec delege _flightDetailsDel");
FlightMethods_2.DurationAverageDel _durationAverageDel = _flightMethods.DurationAverage;

Console.WriteLine("Avec delege _durationAverageDel");
Console.WriteLine(_durationAverageDel("Paris"));

p1.UpperFullName();

Console.WriteLine(p1.FullName.LastName+" "+p1.FullName.FirstName);

AMContext context = new AMContext();
//context.Planes.Add(TestData.BoingPlane);
context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First().Plane.Capacity);
