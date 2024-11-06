using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

namespace Laboratory1
{

    public class Appliance //Класс офисная техника
    {
        string? model; // Модель
        int price; //Цена
        int guarantee; //Гарантия
        public Appliance() //Конструктор по умолчанию
        {
            model = "HP";
            price = 10000;
            guarantee = 2;
        }
        public Appliance(string newmodel, int newprice, int newguarantee) //Конструктор с параметрами
        {
            if (newmodel != null) model = newmodel;
            else model = "HP";
            if (0 < newprice && newprice < 999999) price = newprice; //Если значение корректно,присваиваем его объекту класса
            else price = 10000; //Иначе устанавливаем значение по умолчанию
            if (0 <= newguarantee && newguarantee <= 10) guarantee = newguarantee;
            else guarantee = 2;
        }
        public virtual void Print() //Виртуальный метод для вывода значений
        {
           
            Console.WriteLine($"Модель: {model}"); // Печатаем значения объектов класса
            Console.WriteLine($"Цена: {price}");
            Console.WriteLine($"Гарантийный срок: {guarantee}");
        }
        public string Model // Свойство
        {
            get
            {
                return model; //Возвращаем значение 
            }
            set
            {
                if (value != null) model = value;  //Устанавливаем новое значение,если он не равно NULL 
            }

        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (0 < value && value < 999999) price = value; //Если новое значение корректно, присваваем его
            }

        }

        public int Guarantee
        {
            get
            {
                return guarantee;
            }
            set
            {
                if (0 <= value && value <= 10)
                    guarantee = value;
            }
        }
        public class Printer_c : Appliance //Производный класс Принтер
        {
            int volume_of_paint; //Объем краски
            int print_speed; //Скорость печати
            string print_technology; //Технология печати 
            public Printer_c() : base() //Конструктор по умолчанию
            {

                volume_of_paint = 5;
                print_speed = 20;
                print_technology = "Лазерная";
            }

            public Printer_c(string model, int price, int guarantee, int volume, int speed, string tech) : base(model, price, guarantee) //Конструктор с параметрами
            {
                if (volume > 0 && volume < 100) //Проверка новых параметров на корректность 
                    volume_of_paint = volume;
                else volume_of_paint = 5; //Если новые значения некорректны, устанавливаем значение по умолчанию
                if (speed > 0 && speed < 100)
                    print_speed = speed;
                else print_speed = 20;
                if (tech != null) print_technology = tech;
                else print_technology = "Лазерная";
            }

            public override void Print() //Печать значений
            {
                base.Print();
                Console.WriteLine($"Объем краски: {volume_of_paint}");
                Console.WriteLine($"Скорость печати: {print_speed}");
                Console.WriteLine($"Технология печати: {print_technology}");
            }

            public int Volume
            {
                get
                {
                    return volume_of_paint;
                }
                set
                {
                    if (value > 0 && value < 100) //Если значение корректно
                        volume_of_paint = value; //Присваиваем его объекту
                }
            }

            public int Speed
            {
                get { return print_speed; }
                set
                {
                    if (value > 0 && value < 100) //Если значение корректно 
                        print_speed = value; //Присваиваем его объекту
                }
            }

            public string Tech
            {
                get
                {
                    return print_technology;
                }
                set
                {
                    if (value!= null) print_technology = value;
  
                }
            }
        }

        public class Fax : Appliance //Производный класс - факс
        {
            string? phone_number; //Номер
            int transmission_speed; //Скорость передачи
            int memory_capacity; //Объем памяти
            public Fax() : base() //Конструктор по умолчанию
            {
                transmission_speed = 40;
                memory_capacity = 15;
                phone_number = "123456789";
            }

            public Fax(string model, int price, int guarantee, int memory, int speed, string number) : base(model, price, guarantee) //Конструктор с параметрами
            {
                if (memory > 0 && memory < 100)memory_capacity = memory; //Если значения корректны,присваиваем их объекту
                else memory_capacity = 15; //Иначе присваиваем значения по умолчанию
                if (speed > 0 && speed < 100) transmission_speed = speed;
                else transmission_speed = 40;
                if (number!= null) phone_number = number;
                else phone_number = phone_number = "123456789";
            }
            public override void Print() //Печать значений объекта
            {
                base.Print();
                Console.WriteLine($"Объем памяти: {memory_capacity}");
                Console.WriteLine($"Скорость передачи: {transmission_speed}");
                Console.WriteLine($"Номер: {phone_number}");
            }

            public int Memory
            {
                get
                {
                    return memory_capacity;
                }
                set
                {
                    if (value > 0 && value < 100)
                        memory_capacity = value;
                }
            }

            public int Speed
            {
                get
                {
                    return transmission_speed;
                }
                set
                {
                    if (value > 0 && value < 100)
                        transmission_speed = value;
                }
            }
            public string Number
            {
                get
                {
                    return phone_number;
                   
                }
                set
                {
                    if (value != null) phone_number = value;
                }

            }
        }
        static void Main()
        {
            List<Appliance> appliances = new List<Appliance>(); //Создание списка указателей на базовый класс
            int choice;
            do
            {
                Console.WriteLine("Выберите действие:\n");
                Console.WriteLine("1 - Добавить объект\n");
                Console.WriteLine("2 - Вывести содержимое списка\n");
                Console.WriteLine("3 - Завершить программу\n");
                Console.WriteLine("Ваш выбор: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Выберите тип объекта:\n");
                            Console.WriteLine("1 - Базовый класс Appliance\n");
                            Console.WriteLine("2 - Производный класс Printer_c\n");
                            Console.WriteLine("3 - Производный класс Fax\n");
                            Console.WriteLine("Ваш выбор: ");
                            int ChooseObject;
                            while (!int.TryParse(Console.ReadLine(), out ChooseObject) || ChooseObject < 1 || ChooseObject > 3)
                            {
                                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            }
                                switch (ChooseObject)
                            {
                                case 1:
                                    {
                                        string? model;
                                        int price, guarantee;
                                        Console.WriteLine("Введите модель: ");
                                        do
                                        {
                                            model = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(model))
                                            {
                                                Console.WriteLine("Некорректный ввод. Введите значение модели.");
                                            }
                                        } while (string.IsNullOrWhiteSpace(model));

                                        Console.WriteLine("Введите цену: ");
                                        while (!int.TryParse(Console.ReadLine(), out price))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение цены.");
                                        }
                                        Console.WriteLine("Введите гарантийный срок: ");
                                        while (!int.TryParse(Console.ReadLine(), out guarantee))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение гарантийного срока.");
                                        }
                                        appliances.Add(new Appliance(model, price, guarantee));
                                        break;
                                    }

                                case 2:
                                    {
                                        string? model, tech;
                                        int price, guarantee, volume, speed;
                                        Console.WriteLine("Введите модель: ");
                                        do
                                        {
                                            model = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(model))
                                            {
                                                Console.WriteLine("Некорректный ввод. Введите значение модели.");
                                            }
                                        } while (string.IsNullOrWhiteSpace(model));
                                        Console.WriteLine("Введите цену: ");
                                        while (!int.TryParse(Console.ReadLine(), out price))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение цены.");
                                        }
                                        Console.WriteLine("Введите гарантийный срок: ");
                                        while (!int.TryParse(Console.ReadLine(), out guarantee))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение гарантийного срока.");
                                        }
                                        Console.WriteLine("Введите объем краски: ");
                                        while (!int.TryParse(Console.ReadLine(), out volume))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение объема краски.");
                                        }
                                        Console.WriteLine("Введите скорость печати: ");
                                        while (!int.TryParse(Console.ReadLine(), out speed))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение скорости печати.");
                                        }
                                        Console.WriteLine("Введите технологию печати: ");
                                        
                                        do
                                        {
                                            tech = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(tech))
                                            {
                                                Console.WriteLine("Некорректный ввод. Введите значение технологии печати.");
                                            }
                                        } while (string.IsNullOrWhiteSpace(tech));
                                        Appliance appliance = new Printer_c(model, price, guarantee, volume, speed, tech);
                                        appliances.Add(appliance);
                                        break;
                                    }
                                case 3:
                                    {
                                        string? model, number;
                                        int price, guarantee, memory, speed;
                                        Console.WriteLine("Введите модель: ");
                                        do
                                        {
                                            model = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(model))
                                            {
                                                Console.WriteLine("Некорректный ввод. Введите значение модели.");
                                            }
                                        } while (string.IsNullOrWhiteSpace(model));
                                        Console.WriteLine("Введите цену: ");
                                        while (!int.TryParse(Console.ReadLine(), out price))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение цены.");
                                        }
                                        Console.WriteLine("Введите гарантийный срок: ");
                                        while (!int.TryParse(Console.ReadLine(), out guarantee))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение гарантийного срока.");
                                        }
                                        Console.WriteLine("Введите объем памяти: ");
                                        while (!int.TryParse(Console.ReadLine(), out memory))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение объема памяти.");
                                        }
                                        Console.WriteLine("Введите скорость передачи: ");
                                        while (!int.TryParse(Console.ReadLine(), out speed))
                                        {
                                            Console.WriteLine("Некорректный ввод. Введите значение скорости передачи.");
                                        }
                                        Console.WriteLine("Введите номер телефона: ");
                                        do
                                        {
                                            number = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(number))
                                            {
                                                Console.WriteLine("Некорректный ввод. Введите значение номера.");
                                            }
                                        } while (string.IsNullOrWhiteSpace(number));
                                        appliances.Add(new Fax(model, price, guarantee, memory, speed, number));
                                        break;
                                    }
                            }
                            break;
                        }

                    case 2:
                        {
                            if (appliances.Count != 0)
                            {
                                foreach (var appliance in appliances)
                                {
                                    Console.WriteLine();
                                    appliance.Print();  // Вызываем метод Print() для каждого устройства
                                    Console.WriteLine();
                                }
                            }
                            else Console.WriteLine("Список пуст ");
                            break;
                        }
                    case 3:
                        {
                            appliances.Clear(); //Очищаем список
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                            break;
                        };
                }
            } while (choice != 3);
        }
    }
}
             