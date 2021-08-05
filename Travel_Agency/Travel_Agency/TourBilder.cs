using System;
using System.Collections.Generic;
using System.Text;

namespace Travel_Agency
{

    class Country
    {
        public string NameCountry { get; set; }
        public double PriceCountry { get; set; }
        public void Print()
        {
            Console.WriteLine($" Стран : {NameCountry} Цена : {PriceCountry}");
        }
    }

    class City
    {
        public string NameCity { get; set; }
        public double PriceCity { get; set; }
        public void Print()
        {
            Console.WriteLine($" Город : {NameCity} Цена : {PriceCity}");
        }
    }

    class Hotel
    {
        public string NameHotel { get; set; }
        public double PriceHotel { get; set; }

        public void Print()
        {
            Console.WriteLine($" Отель : {NameHotel} Цена : {PriceHotel}");
        }
    }

     

    class Tour : Point
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Hotel Hotel { get; set; }
     

        public override string GetInfo()
        {
            string str;

            str = $"\nСтрана: {Country.NameCountry}, цена: {Country.PriceCountry} \n";
            str += $"Город: {City.NameCity}, цена: {City.PriceCity} \n";
            str += $"Отель: {Hotel.NameHotel}, цена: {Hotel.PriceHotel} \n";

            return str;
        }
    }

    abstract class TourBilder
    {
        public Tour Tour { get; private set; }
        public void CreateTour()
        {
            Tour = new Tour();
        }

        public abstract void SetCountry();
        public abstract void SetCity();
        public abstract void SetHotel();
    }

    //Компоновка
    class TourLayout
    {
        public Tour Layout(TourBilder tourBuilder)
        {
            tourBuilder.CreateTour();
            tourBuilder.SetCountry();
            tourBuilder.SetCity();
            tourBuilder.SetHotel();
            return tourBuilder.Tour;
        }
    }

    class YourTourBilder : TourBilder
    {

        private string NameCountry;
        private double PriceCountry;
        private string NameCity;
        private double PriceCity;
        private string NameHotel;
        private double PriceHotel;

        public YourTourBilder(string NameCountry, double PriceCountry, string NameCity, double PriceCity, string NameHotel, double PriceHotel)
        {
            this.NameCountry = NameCountry;
            this.PriceCountry = PriceCountry;
            this.NameCity = NameCity;
            this.PriceCity = PriceCity;
            this.NameHotel = NameHotel;
            this.PriceHotel = PriceHotel;
        }

        public override void SetCountry()
        {
            this.Tour.Country = new Country { NameCountry = NameCountry, PriceCountry = PriceCountry };
        }
        public override void SetCity()
        {
            this.Tour.City = new City { NameCity = NameCity, PriceCity = PriceCity };
        }

        public override void SetHotel()
        {
            this.Tour.Hotel = new Hotel { NameHotel = NameHotel, PriceHotel = PriceHotel };
        }
    }
}