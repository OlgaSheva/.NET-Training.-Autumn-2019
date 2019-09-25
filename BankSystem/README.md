### Day 3. 19.09.2019
#### Читать
- [C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013](https://drive.google.com/drive/u/0/folders/0B7WmjuqYed3Aeko0MzNYZWtVOUk) Chapter 10: Methods

#### Материалы
- [Basic Coding in C#](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M2.%20Basic%20Coding%20in%20C%23)
- [Methods in details](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M4.%20Methods%20in%20details)

#### Задачи
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 24.09.2019, 24.00)** Реализовать алгоритм, позволяющий вычислять корень **n**-ой степени ( n ∈ N ) из вещественного числа **а** методом Ньютона с заданной точностью. Решение оформить  в виде статического метода **FindNthRoot** статического класса **MathExtension**.
    - Разработать модульные тесты. Примерные тест кейсы:
      - [TestCase(1, 5, 0.0001,ExpectedResult = 1)]
      - [TestCase(8, 3, 0.0001,ExpectedResult = 2)]
      - [TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]
      - [TestCase(0.04100625,4 , 0.0001, ExpectedResult = 0.45)]
      - [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
      - [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
      - [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
      - [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
      - [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
      - [a = -0.01, n = 2, accurancy = 0.0001] <- ArgumentException
      - [a = 0.001, n = -2, accurancy = 0.0001] <- ArgumentException
      - [a = 0.01, n = 2, accurancy = -1] <- ArgumentException	
      - ...
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 25.09.2019, 24.00)** Реализовать метод, который для данного положительное целого число находит ближайшее меньшее целое, состоящее из цифр исходного числа, если такое число существует. Решение оформить  в виде статического метода **FindPreviousLessThan** статического класса **NumbersExtension** (Day 1. п. 2). Разработать модульные тесты для тестирования метода.  
