﻿// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("");
//Constructeur par default
/*Plane plane1= new Plane();
plane1.Capacity= 1;
plane1.PlaneId= 1;
plane1.PlaneType = planeType.Boing;*/

//Constructeur parametré
//Plane plane2= new Plane(1,new DateTime(2023-09-01),2);

//Intitialiseur d'object sur le constructeur vide par defaut 
Plane plane3 = new Plane
{
    Capacity = 1,
    PlaneType = planeType.Boing,
    PlaneId = 1,
};

Plane plane4 = new Plane
{
    Capacity = 2
};

Passanger p1 = new Passanger
{
    BirthDate = new DateTime(1900 - 04 - 05),
    EmailAdress = "Eren.jaeger@esprit.tn",
    fullName = new FullName
    {
        LastName = "Mario",
        FirstName = " Marshello "
    }
};

Traveller t1 = new Traveller
{
    fullName = new FullName
    {
        FirstName = " Marshello "
    }
};

Staff s1 = new Staff
{
    fullName = new FullName
    {
        LastName = "Mario"
    }
};

Console.WriteLine(p1.checkProfile("mario", "Marshello"));
p1.PassangerType();
t1.PassangerType();
s1.PassangerType();

//test TESTDATA

ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights;
Console.WriteLine("Test GetFlightDates");
foreach (var item in sf.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}

Console.WriteLine("Test ShowFlightDetails");
//sf.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("Grouped");
sf.DestinationGroupedFlights();
