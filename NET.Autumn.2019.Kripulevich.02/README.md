### Day 2. 17.09.2019	
#### Читать
- Ian Griffiths. Programming C# 5.0.  Chapter 2,  Numeric Types.
- Joseph Albahari, Ben Albahari C# 5.0 (6.0) in a Nutshell. Chapter 6. Framework Fundamentals - Working with Numbers
- The Art of Unit Testing. ROY OSHEROVE. PART 1 GETTING STARTED.
- [Что нужно знать про арифметику с плавающей запятой](https://habrahabr.ru/post/112953/)
- [Get started with unit testing](https://docs.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing) или [Приступая к работе с модульным тестированием](https://docs.microsoft.com/ru-ru/visualstudio/test/getting-started-with-unit-testing)
- [Архитектура компьютера. Э. Таненбаум. Приложение А, Приложение B](https://drive.google.com/file/d/1fCJqlORKzXciCTzi5LG0daANM6Syrta7/view?usp=sharing)

#### Полезные ссылки

- [IEEE-754 Floating Point Converter](https://www.h-schmidt.net/FloatConverter/IEEE754.html)
- [Наглядное объяснение чисел с плавающей запятой](https://habr.com/ru/post/337260/)
- [Взгляд со стороны: Стандарт IEEE754](https://habr.com/ru/post/262245/)
- [Представление вещественных чисел](https://neerc.ifmo.ru/wiki/index.php?title=%D0%9F%D1%80%D0%B5%D0%B4%D1%81%D1%82%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5_%D0%B2%D0%B5%D1%89%D0%B5%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%BD%D1%8B%D1%85_%D1%87%D0%B8%D1%81%D0%B5%D0%BB#.D0.94.D0.B5.D0.BD.D0.BE.D1.80.D0.BC.D0.B0.D0.BB.D0.B8.D0.B7.D0.BE.D0.B2.D0.B0.D0.BD.D0.BD.D1.8B.D0.B5_.D1.87.D0.B8.D1.81.D0.BB.D0.B0)
- [Что внутри числа с плавающей точкой и как оно работает](https://javarush.ru/groups/posts/2255-chto-vnutri-chisla-s-plavajujshey-tochkoy-i-kak-ono-rabotaet)
- [IEEE 754 - стандарт двоичной арифметики с плавающей точкой](http://www.softelectro.ru/ieee754.html)

 *Дополнительно:*
- [Basic Coding in C#](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M2.%20Basic%20Coding%20in%20C%23)
- [C# Unit Testing](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M5.%20C%23%20Unit%20Testing)

#### Задачи
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 20.09.2019, 24.00)** Даны два целых знаковых четырехбайтовых числа и две позиции битов i и j (i<=j). Реализовать алгоритм вставки первых (j - i + 1) битов второго числа в первое так, чтобы биты второго числа занимали позиции с бита i по бит j (биты нумеруются справа налево). Решение оформить  в виде статического метода **InsertNumberIntoAnother** статического класса **NumbersExtension**. Разработать модульные тесты (NUnit и MS Unit Test - ([DDT](https://msdn.microsoft.com/en-us/library/ms182527.aspx)))) для тестирования метода. (Ниже схема-пояснение к алгоритму). Примерные тест-кейсы

        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3) => ArgumentException
        NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3) => ArgumentOutOfRangeException
        NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32) => ArgumentOutOfRangeException
        NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32) => ArgumentOutOfRangeException
        ...
        
![Схема к алгоритму](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/blob/master/Pictures/Scheme.png)    
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 19.09.2019, 24.00)** Реализовать *рекурсивный* алгоритм поиска максимального элемента в неотсортированном целочисленом массиве. Решение оформить  в виде статического метода **FindMximumItem** статического класса **ArrayExtension**. Разработать модульные тесты NUnit для тестирования метода. Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом.  
3. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 21.09.2019, 24.00))** Реализовать алгоритм поиска в целочисленном массиве индекса элемента, для которого сумма элементов слева и сумма элементов справа равны. Решение оформить  в виде статического метода **FindBalanceIndex** статического класса **ArrayExtension** (п. 2). Если такого элемента не существует вернуть null.    
4. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 22.09.2019, 24.00))** Реализовать метод, который принимает массив целых чисел и фильтрует его таким образом, чтобы на выходе был получен новый массив, состоящий только из элементов, которые содержат заданную цифру. (*LINQ-запросы не использовать!*) В случае, если таких элементов нет, вернуть пустой массив. Решение оформить  в виде статического метода **FilterArrayByKey** статического класса **ArrayExtension** (п. 2). Например, для цифры 7, метод **FilterArrayByKey** для набора {7,1,2,3,4,5,6,7,68,69,70,15,17} возвращает набор {7,7,70,17}. Разработать модульные тесты NUnit и MS Unit Test для тестирования метода. Примерные тест-кейсы 
        
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        ArrayExtension.FilterArrayByKey(new int[0], 0)) => ArgumentException
        ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1) => ArgumentOutOfRangeException
        ArrayExtension.FilterArrayByKey(null, 0) => ArgumentNullException
        ...
