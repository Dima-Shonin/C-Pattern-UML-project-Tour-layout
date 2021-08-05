using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Travel_Agency
{
    class Program
    {
        static string name = String.Empty;
        static string sname = String.Empty;
        static string phone = String.Empty;
        static string email = String.Empty;
        static string PatternEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        static string PaternPhone = @"\d{10}";

        static void Main(string[] args)
        {  
            Tour tour = new Tour();
            Country countryUkraine = new Country();
            countryUkraine.NameCountry = "Ukraine";
            countryUkraine.PriceCountry = 5000;

            City cityofUkrain1 = new City();
            cityofUkrain1.NameCity = "Kyiv";
            cityofUkrain1.PriceCity = 1200;

            City cityofUkrain2 = new City();
            cityofUkrain2.NameCity = "Zaporizhzhya";
            cityofUkrain2.PriceCity = 9889547;

            Hotel hotelofUkrain1 = new Hotel();
            hotelofUkrain1.NameHotel = "Hilton Hotels";
            hotelofUkrain1.PriceHotel = 6000;

            Hotel hotelofUkrain2 = new Hotel();
            hotelofUkrain2.NameHotel = "IHG";
            hotelofUkrain2.PriceHotel = 10000;

            Country countryFrance = new Country();
            countryFrance.NameCountry = "France";
            countryFrance.PriceCountry = 10000;

            City cityofFrance1 = new City();
            cityofFrance1.NameCity = "Paris";
            cityofFrance1.PriceCity = 2800;

            City cityofFrance2 = new City();
            cityofFrance2.NameCity = "Bordo";
            cityofFrance2.PriceCity = 1500;

            bool Yes = true;
            while (Yes)
            {
                Console.Clear();
                add_client();
                Client Dima = new Client(name, sname, phone, email);
                Console.Clear();
                Console.Write("1 - "); countryUkraine.Print();
                Console.Write("2 - "); countryFrance.Print();
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            Console.Clear();
                            tour.Country = countryUkraine;
                            Console.Write("1 - "); cityofUkrain1.Print();
                            Console.Write("2 - "); cityofUkrain2.Print();
                            string number2 = Console.ReadLine();
                            switch (number2)
                            {
                                case "1":

                                    Console.Clear();
                                    tour.City = cityofUkrain1;
                                    goto case "10";
                                case "2":
                                    Console.Clear();
                                    tour.City = cityofUkrain2;
                                    goto case "10";
                                case "10":
                                    Console.Write("1 - "); hotelofUkrain1.Print();
                                    Console.Write("2 - "); hotelofUkrain2.Print();
                                    string number3 = Console.ReadLine();
                                    switch (number3)
                                    {
                                        case "1":
                                            tour.Hotel = hotelofUkrain1;
                                            break;
                                        case "2":
                                            tour.Hotel = hotelofUkrain2;
                                            break;
                                        default:
                                            Console.WriteLine("Неверный ввод");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод");
                                    break;
                            }
                        }                        
                        break;
                    case "2":
                        {
                            Console.Clear();
                            tour.Country = countryFrance;
                            Console.Write("1 - "); cityofFrance1.Print();
                            Console.Write("2 - "); cityofFrance2.Print();
                            string number4 = Console.ReadLine();
                            switch (number4)
                            {
                                case "1":
                                    Console.Clear();
                                    tour.City = cityofFrance1;
                                    goto case "10";
                                case "2":
                                    Console.Clear();
                                    tour.City = cityofFrance2;
                                    goto case "10";
                                case "10":
                                    Console.Write("1 - "); hotelofUkrain1.Print();
                                    Console.Write("2 - "); hotelofUkrain2.Print();
                                    string number5 = Console.ReadLine();
                                    switch (number5)
                                    {
                                        case "1":
                                            tour.Hotel = hotelofUkrain1;
                                            break;
                                        case "2":
                                            tour.Hotel = hotelofUkrain2;
                                            break;
                                        default:
                                            Console.WriteLine("Неверный ввод");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод");
                                    break;
                            }
                        }                        

                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
                Console.Clear();
                CompositePoint points = new CompositePoint();
                points.AddPoint(CreatePoint(tour));
                string str = points.GetInfo();


                Console.WriteLine("Ваши персональные данные :");
                Dima.PrintInfo();
                Console.WriteLine("Данные по выбраному туру :");
                Console.WriteLine(str);


                Console.WriteLine("Всё ли верно ? \n 1 - Да 2 - Нет");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Спасибо дополнительную информацию пришлём на почту");
                        Yes = false;
                        break;
                    case "2":
                        Console.WriteLine("Ещё раз");
                        break;
                    default:
                        Console.WriteLine("Такого выбора нет");
                        break;
                }
            }

        }

        static CompositePoint CreatePoint(Tour tour)
        {
            CompositePoint point = new CompositePoint();

            point.AddPoint(tour);

            return point;
        }


        static void add_client()
        {
            Console.Write("Введите ваше имя :  ");
            name = Console.ReadLine();
            Console.Write("Введите вашу фамилию :  ");
            sname = Console.ReadLine();
            Console.Write("Введите ваш номер телефона :  ");
            while (true)
            {
                phone = Console.ReadLine();
                if (Regex.IsMatch(phone, PaternPhone, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Номер подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный номер");
                }
            }

            Console.Write("Введите вашу почту :  ");
            while (true)
            {
                email = Console.ReadLine();
                if (Regex.IsMatch(email, PatternEmail, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Email подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный email");
                }
            }
        }
    }
}
