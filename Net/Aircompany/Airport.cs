using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public IEnumerable<Plane> Planes { get; private set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes;
        }

        public IEnumerable<T> GetPlanes<T>() where T : Plane
        {
            return Planes.Where(plane => plane.GetType() == typeof(T)).Cast<T>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPlanes<PassengerPlane>().OrderByDescending(plane => plane.PassengersCapacity).First();
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetPlanes<MilitaryPlane>().Where(plane => plane.MilitaryPlaneType == MilitaryType.Transport);
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return $"Airport planes: {string.Join(",  ", Planes.Select(plane => plane.Model))}";
        }
    }
}
