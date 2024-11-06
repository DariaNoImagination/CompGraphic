using Laboratory1;
using System;
using System.Diagnostics;
using static Laboratory1.Appliance;
namespace Laboratory1
{
    [TestClass]
    public class Lab1Test
    {
        [TestMethod]
        public void ApplianceConstructorDefaultTest() //Конструктор по умолчанию
        {
            var appliance = new Appliance();
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(10000, appliance.Price);
            Assert.AreEqual(2, appliance.Guarantee);
        }
        [TestMethod]
        public void ApplianceConstructorTest() //Конструктор с верными значениями 
        {
            var appliance = new Appliance("HP", 12000, 3);
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(12000, appliance.Price);
            Assert.AreEqual(3, appliance.Guarantee);
        }
        [TestMethod]
        public void ApplianceConstructorTestWrong() //Конструктор с некорректными значениями 
        {
            var appliance = new Appliance(null, -10, -10);
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(10000, appliance.Price);
            Assert.AreEqual(2, appliance.Guarantee); //Устанавливаются значения по умолчанию
        }
        [TestMethod]
        public void AppliancePrintTest() //Печать значений объекта
        {
            var appliance = new Appliance("HP", 7000, 3);
            var expectedOutput = $"Модель: HP{Environment.NewLine}Цена: 7000{Environment.NewLine}Гарантийный срок: 3{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                appliance.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void AppliancePrintNullTest() //Печать объекта со значением равным null
        {
            var appliance = new Appliance(null, 7000, 3);
            var expectedOutput = $"Модель: HP{Environment.NewLine}Цена: 7000{Environment.NewLine}Гарантийный срок: 3{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                appliance.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void Model_SetNewValue() //Присваивание нового значения
        {
            var appliance = new Appliance("HP", 15550, 1);
            appliance.Model = "Canon";
            Assert.AreEqual("Canon", appliance.Model);
        }
        [TestMethod]
        public void Model_SetNullValue() //Присваивание значеия равного null
        {
            var appliance = new Appliance("Canon", 13000, 1);
            appliance.Model = null;
            Assert.AreEqual("Canon", appliance.Model); //Значение объекта остается прежним
        }

        [TestMethod]
        public void Model_GetValue() //Получение значения
        {
            var appliance = new Appliance("Canon", 13000, 1);
            string model = appliance.Model;
            Assert.AreEqual("Canon", model);
        }

        [TestMethod]
        public void Price_SetValidValue() //Присваивание корректного значения
        {
            var appliance = new Appliance("Canon", 11400, 1);
            appliance.Price = 12600;
            Assert.AreEqual(12600, appliance.Price);
        }

        [TestMethod]
        public void Price_SetInvalidValue() //Присваивание некорректного значения
        {
            var appliance = new Appliance("Canon", 11400, 1);
            appliance.Price = -100; // Invalid value
            Assert.AreEqual(11400, appliance.Price); //Значение объекта остается прежним
        }
        [TestMethod]
        public void Price_GetValue() //Получение некорректного незначения
        {
            var appliance = new Appliance("Canon", -1, 1);
            int price = appliance.Price;
            Assert.AreEqual(10000, price); //Получаемое значение - значение по умолчанию
        }
        [TestMethod]
        public void Guarantee_SetValidValue()  //Присваивание корректного значения
        {
            var appliance = new Appliance("Canon", 17000, 1);
            appliance.Guarantee = 5;
            Assert.AreEqual(5, appliance.Guarantee);
        }

        [TestMethod]
        public void Guarantee_SetInvalidValue()  //Присваивание некорректного значения
        {
            var appliance = new Appliance("Canon", 18000, 1);
            appliance.Guarantee = 15;
            Assert.AreEqual(1, appliance.Guarantee); //Значение объекта остается прежним
        }
        [TestMethod]
        public void Guarantee_GetValue() //Получение корректного значения
        {
            var appliance = new Appliance("Canon", 13000, 1);
            int guarantee = appliance.Guarantee;
            Assert.AreEqual(1, guarantee);
        }
        [TestMethod]
        public void PrinterConstructorDefaultTest() //Коснтруктор по умолчанию
        {
            var printer = new Printer_c();
            Assert.AreEqual(5, printer.Volume);
            Assert.AreEqual(20, printer.Speed);
            Assert.AreEqual("Лазерная", printer.Tech);
        }
        [TestMethod]
        public void PrinterConstructorTest() // Конструктор с параметрами 
        {
            var printer = new Printer_c("Canon",-1,2,8,15, null); 
            Assert.AreEqual("Canon", printer.Model);
            Assert.AreEqual(10000, printer.Price); //Если значение некорректно - устанавливается значение по умолчанию
            Assert.AreEqual(2, printer.Guarantee);
            Assert.AreEqual(8, printer.Volume);
            Assert.AreEqual(15, printer.Speed);
            Assert.AreEqual("Лазерная", printer.Tech);
        }
        [TestMethod]
        public void PrinterPrintTest() //Печать значений
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            var expectedOutput = $"Модель: Canon{Environment.NewLine}Цена: 8000{Environment.NewLine}Гарантийный срок: 2{Environment.NewLine}Объем краски: 8{Environment.NewLine}Скорость печати: 15{Environment.NewLine}Технология печати: Струйная{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                printer.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void PrinterPrintTestNull() //Печать объекта с некорректными параметрами
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, null);
            var expectedOutput = $"Модель: Canon{Environment.NewLine}Цена: 8000{Environment.NewLine}Гарантийный срок: 2{Environment.NewLine}Объем краски: 8{Environment.NewLine}Скорость печати: 15{Environment.NewLine}Технология печати: Лазерная{Environment.NewLine}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                printer.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void Tech_SetNewValue()  //Присваивание корректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Tech = "Лазерная";
            Assert.AreEqual("Лазерная",printer.Tech);
        }
        [TestMethod]
        public void Tech_SetNullValue() //Присваивание некорректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Tech = null;
            Assert.AreEqual("Струйная", printer.Tech); //Значение остается прежним
        }

        public void Tech_InvalidGetValue()  //Получение некорректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, null);
            string tech = printer.Tech;
            Assert.AreEqual("Лазерная", tech); //Полученное значение - значение по умолчанию
        }
        [TestMethod]
        public void Volume_SetValidValue()  //Присваивание корректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Volume = 10;
            Assert.AreEqual(10, printer.Volume);
        }
        [TestMethod]
        public void Volume_SetInvalidValue()  //Присваивание некорректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Volume = -8;
            Assert.AreEqual(8, printer.Volume);
        }
        [TestMethod]
        public void Volume_GetValue() // Получение значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            int volume = printer.Volume;
            Assert.AreEqual(8, volume);
        }
        [TestMethod]
        public void Speed_SetValidValue()  //Присваивание корректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Speed = 10;
            Assert.AreEqual(10, printer.Speed);
        }

        [TestMethod]
        public void Speed_SetInvalidValue()  //Присваивание некорректного значения
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            printer.Speed = -10;
            Assert.AreEqual(15, printer.Speed); 
        }
        [TestMethod]
        public void Speed_GetValue() //Получение корректного значения
        { 
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "Струйная");
            int speed = printer.Speed;
            Assert.AreEqual(15, speed);
        }
        [TestMethod]
        public void FaxConstructorDefault() //Конструктор по умолчанию
        {
            var fax = new Fax();
            Assert.AreEqual(15, fax.Memory);
            Assert.AreEqual(40, fax.Speed);   
            Assert.AreEqual("123456789", fax.Number); 
        }
        [TestMethod]
        public void FaxConstructor() //Конструктор с параметрами
        {
            var fax = new Fax("ModelA", 5000, 2, 50, 20, "23456789");
            Assert.AreEqual("ModelA", fax.Model);
            Assert.AreEqual(5000, fax.Price);
            Assert.AreEqual(2, fax.Guarantee);
            Assert.AreEqual(50, fax.Memory);
            Assert.AreEqual(20, fax.Speed);
            Assert.AreEqual("23456789", fax.Number);
        }
        public void FaxPrint() //Печать значени объекта
        {
            var fax = new Fax("ModelB", 10000, 3, 75, 50, "987654321");
            var expectedOutput = $"Модель: ModelB{Environment.NewLine}Цена: 10000{Environment.NewLine}Гарантийный срок: 3{Environment.NewLine}Объем памяти: 75{Environment.NewLine}Скорость передачи: 50{Environment.NewLine}Номер:987654321{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fax.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void FaxPrintNull() //Печать объекта с некорректными параметрами
        { 
            var fax = new Fax("ModelC", 1200, 2, 30, 10, null); 
            var expectedOutput = $"Модель: ModelC{Environment.NewLine}Цена: 1200{Environment.NewLine}Гарантийный срок: 2{Environment.NewLine}Объем памяти: 30{Environment.NewLine}Скорость передачи: 10{Environment.NewLine}Номер: 123456789{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fax.Print();

                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void Memory_SetValidValue()  //Присваивание корректного значения
        {
            var fax = new Fax("ModelD", 300, 1, 40, 10, "123");
            fax.Memory = 50;
            Assert.AreEqual(50, fax.Memory);
        }

        [TestMethod]
        public void Memory_SetInvalidValue()  //Присваивание некорректного значения
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            fax.Memory = -1; 
            Assert.AreEqual(40, fax.Memory);  //Значение остается прежним
        }
        [TestMethod]
        public void Memory_GetValue() //Получение корректного значения
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            int memory = fax.Memory;
            Assert.AreEqual(40, memory);
        }

        [TestMethod]
        public void TransmissionSpeed_SetValidValue()  //Присваивание корректного значения
        {
            var fax = new Fax("ModelF", 500, 1, 40, 10, "789");
            fax.Speed = 90;
            Assert.AreEqual(90, fax.Speed);
        }

        [TestMethod]
        public void TransmissionSpeed_SetInvalidValue()  //Присваивание некорректного значения
        {
            var fax = new Fax("ModelG", 600, 1, 40, 10, "012");
            fax.Speed = 110; 
            Assert.AreEqual(10, fax.Speed);
        }
        public void TransmissionSpeed_GetValue()  //Получение некорректного значения
        {
            var fax = new Fax("ModelE", 400, 1, 40, 120, "456");
            int speed = fax.Speed;
            Assert.AreEqual(20, speed);
        }
        [TestMethod]
        public void Number_SetNewValue()  //Присваивание корректного значения
        {
             var fax = new Fax("ModelH", 700, 1, 40, 10, "123456");
             fax.Number = "654321";
             Assert.AreEqual("654321", fax.Number);
        }
        [TestMethod]
        public void Number_SetNullValue()  //Присваивание некорректного значения
        {
            var fax = new Fax("ModelI", 800, 1, 40, 10, "555666");
            fax.Number = null;
            Assert.AreEqual("555666", fax.Number); 
        }
        [TestMethod]
        public void Number_GetValue() //Получение значения
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            string number = fax.Number;
            Assert.AreEqual("456", fax.Number);
        }
        [TestMethod]
        public void AddInList() //Проверка добавления элемента в список
        {
            var aplliance = new Appliance("HP", 7000, 3);
            var fax = new Fax("ModelI", 800, 1, 40, 10, "555666");
            List<Appliance> appliances = new List<Appliance>(); 
            appliances.Add(aplliance);
            int count = appliances.Count;
            appliances.Add(fax);
            int newcount = appliances.Count;
            Assert.AreEqual(count + 1, newcount); 
        }

    }
}
