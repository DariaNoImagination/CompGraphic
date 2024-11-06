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
        public void ApplianceConstructorDefaultTest() //����������� �� ���������
        {
            var appliance = new Appliance();
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(10000, appliance.Price);
            Assert.AreEqual(2, appliance.Guarantee);
        }
        [TestMethod]
        public void ApplianceConstructorTest() //����������� � ������� ���������� 
        {
            var appliance = new Appliance("HP", 12000, 3);
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(12000, appliance.Price);
            Assert.AreEqual(3, appliance.Guarantee);
        }
        [TestMethod]
        public void ApplianceConstructorTestWrong() //����������� � ������������� ���������� 
        {
            var appliance = new Appliance(null, -10, -10);
            Assert.AreEqual("HP", appliance.Model);
            Assert.AreEqual(10000, appliance.Price);
            Assert.AreEqual(2, appliance.Guarantee); //��������������� �������� �� ���������
        }
        [TestMethod]
        public void AppliancePrintTest() //������ �������� �������
        {
            var appliance = new Appliance("HP", 7000, 3);
            var expectedOutput = $"������: HP{Environment.NewLine}����: 7000{Environment.NewLine}����������� ����: 3{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                appliance.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void AppliancePrintNullTest() //������ ������� �� ��������� ������ null
        {
            var appliance = new Appliance(null, 7000, 3);
            var expectedOutput = $"������: HP{Environment.NewLine}����: 7000{Environment.NewLine}����������� ����: 3{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                appliance.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void Model_SetNewValue() //������������ ������ ��������
        {
            var appliance = new Appliance("HP", 15550, 1);
            appliance.Model = "Canon";
            Assert.AreEqual("Canon", appliance.Model);
        }
        [TestMethod]
        public void Model_SetNullValue() //������������ ������� ������� null
        {
            var appliance = new Appliance("Canon", 13000, 1);
            appliance.Model = null;
            Assert.AreEqual("Canon", appliance.Model); //�������� ������� �������� �������
        }

        [TestMethod]
        public void Model_GetValue() //��������� ��������
        {
            var appliance = new Appliance("Canon", 13000, 1);
            string model = appliance.Model;
            Assert.AreEqual("Canon", model);
        }

        [TestMethod]
        public void Price_SetValidValue() //������������ ����������� ��������
        {
            var appliance = new Appliance("Canon", 11400, 1);
            appliance.Price = 12600;
            Assert.AreEqual(12600, appliance.Price);
        }

        [TestMethod]
        public void Price_SetInvalidValue() //������������ ������������� ��������
        {
            var appliance = new Appliance("Canon", 11400, 1);
            appliance.Price = -100; // Invalid value
            Assert.AreEqual(11400, appliance.Price); //�������� ������� �������� �������
        }
        [TestMethod]
        public void Price_GetValue() //��������� ������������� ����������
        {
            var appliance = new Appliance("Canon", -1, 1);
            int price = appliance.Price;
            Assert.AreEqual(10000, price); //���������� �������� - �������� �� ���������
        }
        [TestMethod]
        public void Guarantee_SetValidValue()  //������������ ����������� ��������
        {
            var appliance = new Appliance("Canon", 17000, 1);
            appliance.Guarantee = 5;
            Assert.AreEqual(5, appliance.Guarantee);
        }

        [TestMethod]
        public void Guarantee_SetInvalidValue()  //������������ ������������� ��������
        {
            var appliance = new Appliance("Canon", 18000, 1);
            appliance.Guarantee = 15;
            Assert.AreEqual(1, appliance.Guarantee); //�������� ������� �������� �������
        }
        [TestMethod]
        public void Guarantee_GetValue() //��������� ����������� ��������
        {
            var appliance = new Appliance("Canon", 13000, 1);
            int guarantee = appliance.Guarantee;
            Assert.AreEqual(1, guarantee);
        }
        [TestMethod]
        public void PrinterConstructorDefaultTest() //����������� �� ���������
        {
            var printer = new Printer_c();
            Assert.AreEqual(5, printer.Volume);
            Assert.AreEqual(20, printer.Speed);
            Assert.AreEqual("��������", printer.Tech);
        }
        [TestMethod]
        public void PrinterConstructorTest() // ����������� � ����������� 
        {
            var printer = new Printer_c("Canon",-1,2,8,15, null); 
            Assert.AreEqual("Canon", printer.Model);
            Assert.AreEqual(10000, printer.Price); //���� �������� ����������� - ��������������� �������� �� ���������
            Assert.AreEqual(2, printer.Guarantee);
            Assert.AreEqual(8, printer.Volume);
            Assert.AreEqual(15, printer.Speed);
            Assert.AreEqual("��������", printer.Tech);
        }
        [TestMethod]
        public void PrinterPrintTest() //������ ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            var expectedOutput = $"������: Canon{Environment.NewLine}����: 8000{Environment.NewLine}����������� ����: 2{Environment.NewLine}����� ������: 8{Environment.NewLine}�������� ������: 15{Environment.NewLine}���������� ������: ��������{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                printer.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void PrinterPrintTestNull() //������ ������� � ������������� �����������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, null);
            var expectedOutput = $"������: Canon{Environment.NewLine}����: 8000{Environment.NewLine}����������� ����: 2{Environment.NewLine}����� ������: 8{Environment.NewLine}�������� ������: 15{Environment.NewLine}���������� ������: ��������{Environment.NewLine}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                printer.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }
        [TestMethod]
        public void Tech_SetNewValue()  //������������ ����������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Tech = "��������";
            Assert.AreEqual("��������",printer.Tech);
        }
        [TestMethod]
        public void Tech_SetNullValue() //������������ ������������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Tech = null;
            Assert.AreEqual("��������", printer.Tech); //�������� �������� �������
        }

        public void Tech_InvalidGetValue()  //��������� ������������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, null);
            string tech = printer.Tech;
            Assert.AreEqual("��������", tech); //���������� �������� - �������� �� ���������
        }
        [TestMethod]
        public void Volume_SetValidValue()  //������������ ����������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Volume = 10;
            Assert.AreEqual(10, printer.Volume);
        }
        [TestMethod]
        public void Volume_SetInvalidValue()  //������������ ������������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Volume = -8;
            Assert.AreEqual(8, printer.Volume);
        }
        [TestMethod]
        public void Volume_GetValue() // ��������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            int volume = printer.Volume;
            Assert.AreEqual(8, volume);
        }
        [TestMethod]
        public void Speed_SetValidValue()  //������������ ����������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Speed = 10;
            Assert.AreEqual(10, printer.Speed);
        }

        [TestMethod]
        public void Speed_SetInvalidValue()  //������������ ������������� ��������
        {
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            printer.Speed = -10;
            Assert.AreEqual(15, printer.Speed); 
        }
        [TestMethod]
        public void Speed_GetValue() //��������� ����������� ��������
        { 
            var printer = new Printer_c("Canon", 8000, 2, 8, 15, "��������");
            int speed = printer.Speed;
            Assert.AreEqual(15, speed);
        }
        [TestMethod]
        public void FaxConstructorDefault() //����������� �� ���������
        {
            var fax = new Fax();
            Assert.AreEqual(15, fax.Memory);
            Assert.AreEqual(40, fax.Speed);   
            Assert.AreEqual("123456789", fax.Number); 
        }
        [TestMethod]
        public void FaxConstructor() //����������� � �����������
        {
            var fax = new Fax("ModelA", 5000, 2, 50, 20, "23456789");
            Assert.AreEqual("ModelA", fax.Model);
            Assert.AreEqual(5000, fax.Price);
            Assert.AreEqual(2, fax.Guarantee);
            Assert.AreEqual(50, fax.Memory);
            Assert.AreEqual(20, fax.Speed);
            Assert.AreEqual("23456789", fax.Number);
        }
        public void FaxPrint() //������ ������� �������
        {
            var fax = new Fax("ModelB", 10000, 3, 75, 50, "987654321");
            var expectedOutput = $"������: ModelB{Environment.NewLine}����: 10000{Environment.NewLine}����������� ����: 3{Environment.NewLine}����� ������: 75{Environment.NewLine}�������� ��������: 50{Environment.NewLine}�����:987654321{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fax.Print();
                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void FaxPrintNull() //������ ������� � ������������� �����������
        { 
            var fax = new Fax("ModelC", 1200, 2, 30, 10, null); 
            var expectedOutput = $"������: ModelC{Environment.NewLine}����: 1200{Environment.NewLine}����������� ����: 2{Environment.NewLine}����� ������: 30{Environment.NewLine}�������� ��������: 10{Environment.NewLine}�����: 123456789{Environment.NewLine}";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fax.Print();

                var result = sw.ToString();
                Assert.AreEqual(expectedOutput, result);
            }
        }

        [TestMethod]
        public void Memory_SetValidValue()  //������������ ����������� ��������
        {
            var fax = new Fax("ModelD", 300, 1, 40, 10, "123");
            fax.Memory = 50;
            Assert.AreEqual(50, fax.Memory);
        }

        [TestMethod]
        public void Memory_SetInvalidValue()  //������������ ������������� ��������
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            fax.Memory = -1; 
            Assert.AreEqual(40, fax.Memory);  //�������� �������� �������
        }
        [TestMethod]
        public void Memory_GetValue() //��������� ����������� ��������
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            int memory = fax.Memory;
            Assert.AreEqual(40, memory);
        }

        [TestMethod]
        public void TransmissionSpeed_SetValidValue()  //������������ ����������� ��������
        {
            var fax = new Fax("ModelF", 500, 1, 40, 10, "789");
            fax.Speed = 90;
            Assert.AreEqual(90, fax.Speed);
        }

        [TestMethod]
        public void TransmissionSpeed_SetInvalidValue()  //������������ ������������� ��������
        {
            var fax = new Fax("ModelG", 600, 1, 40, 10, "012");
            fax.Speed = 110; 
            Assert.AreEqual(10, fax.Speed);
        }
        public void TransmissionSpeed_GetValue()  //��������� ������������� ��������
        {
            var fax = new Fax("ModelE", 400, 1, 40, 120, "456");
            int speed = fax.Speed;
            Assert.AreEqual(20, speed);
        }
        [TestMethod]
        public void Number_SetNewValue()  //������������ ����������� ��������
        {
             var fax = new Fax("ModelH", 700, 1, 40, 10, "123456");
             fax.Number = "654321";
             Assert.AreEqual("654321", fax.Number);
        }
        [TestMethod]
        public void Number_SetNullValue()  //������������ ������������� ��������
        {
            var fax = new Fax("ModelI", 800, 1, 40, 10, "555666");
            fax.Number = null;
            Assert.AreEqual("555666", fax.Number); 
        }
        [TestMethod]
        public void Number_GetValue() //��������� ��������
        {
            var fax = new Fax("ModelE", 400, 1, 40, 10, "456");
            string number = fax.Number;
            Assert.AreEqual("456", fax.Number);
        }
        [TestMethod]
        public void AddInList() //�������� ���������� �������� � ������
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
