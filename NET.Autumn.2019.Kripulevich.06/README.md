### Day 6. 26.09.2019
#### Читать
- [Programming C# 5.0. Ian Griffiths. O'Reilly Media. 2012.](http://shop.oreilly.com/product/0636920024064.do)
  - *Chapter 6.* Inheritance [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch06.zip)
  - *Chapter 14.* Dynamic Typing [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch14.zip)
- [C# 4.0 Unleashed. Bart De Smet. Sams Publishing. 2011](https://www.goodreads.com/book/show/16284093-c-5-0-unleashed)
   - *Chapter 11.* Fields, Properties, and Indexers
   - *Chapter 14.* Object-Oriented Programming
   - *Chapter 22.* Dynamic Programming .
- [CLR via C#. Jeffrey Richter. Microsoft Press. 2010](https://www.goodreads.com/book/show/7121415-clr-via-c)
   - *Chapter 10.* Properties
   - *Chapter 13.* Interfaces

#### Материалы
- [Encapsulation. Inheritance. Polymorphism (ENG)](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/blob/master/M6.%20Encapsulation.%20Inheritance.%20Polymorphism/Encapsulation.%20Inheritance.%20Polymorphism.pptx)
- [Encapsulation. Inheritance. Polymorphism (RU)](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/blob/master/M6.%20Encapsulation.%20Inheritance.%20Polymorphism/Encapsulation.%20Inheritance.%20Polymorphism%20(ru).pptx)

#### Полезные ссылки

- [IEEE-754 Floating Point Converter](https://www.h-schmidt.net/FloatConverter/IEEE754.html)
- [Наглядное объяснение чисел с плавающей запятой](https://habr.com/ru/post/337260/)
- [Взгляд со стороны: Стандарт IEEE754](https://habr.com/ru/post/262245/)
- [Представление вещественных чисел](https://neerc.ifmo.ru/wiki/index.php?title=%D0%9F%D1%80%D0%B5%D0%B4%D1%81%D1%82%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5_%D0%B2%D0%B5%D1%89%D0%B5%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%BD%D1%8B%D1%85_%D1%87%D0%B8%D1%81%D0%B5%D0%BB#.D0.94.D0.B5.D0.BD.D0.BE.D1.80.D0.BC.D0.B0.D0.BB.D0.B8.D0.B7.D0.BE.D0.B2.D0.B0.D0.BD.D0.BD.D1.8B.D0.B5_.D1.87.D0.B8.D1.81.D0.BB.D0.B0)
- [Что внутри числа с плавающей точкой и как оно работает](https://javarush.ru/groups/posts/2255-chto-vnutri-chisla-s-plavajujshey-tochkoy-i-kak-ono-rabotaet)
- [IEEE 754 - стандарт двоичной арифметики с плавающей точкой](http://www.softelectro.ru/ieee754.html)
- [Pro .NET Performance. Sasha Goldshtein. Chapter 3: Type Internals(Value Type Internals)](https://drive.google.com/drive/folders/0B7WmjuqYed3AVTBoU1dmTEdOTnM)

#### Задачи
  
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 25.09.2019, 24.00)**  Реализовать *экземплярный* класс Transformer, *экземплярный* метод TransformToWords которого выполняет преобразование любого вешественного (System.Double) числа в его "словестный формат". Разработать модульные тесты. Примерные тест-кейсы
	- [TestCase(double.NaN, ExpectedResult = "Not a number")]
	- [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity")]
	- [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity")]
	- [TestCase(-0.0d, ExpectedResult = "zero")]
	- [TestCase(0.0d, ExpectedResult = "zero")]
	- [TestCase(0.1d, ExpectedResult = "zero point one")]
	- [TestCase(-23.809d, ExpectedResult = "minus two three point eight zero nine")]
	- [TestCase(-0.123456789d, ExpectedResult = "minus zero point one two three four five six seven eight nine")]
	- [TestCase(1.23333e308d, ExpectedResult = "one point two three three three three E plus three zero eight")]
	- [TestCase(double.Epsilon, ExpectedResult = "four point nine four zero six five six four five eight four one two four seven E minus three two four")]   
	и т.д. для double.MaxValue, double.MaxValue. 
	
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 28.09.2019, 24.00)**  Расширить функциональную возможность типа System.Double, реализовав возможность получения строкового представления вещественного числа в формате IEEE 754. **Готовые классы-конверторы не использовать.** Разработать модульные тесты. Примерные тест-кейсы (для тестирования специальных значений вещественных чисел возможны варианты).
    - [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
    - [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
    - [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
    - [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
    - [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
    - [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
    - [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
    - [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
    - [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
    - [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
    - [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]     
     и т.д.   
     
3. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 30.09.2019, 24.00)**  Разработать **неизменяемый** класс Polynomial (полином) для работы с многочленами *n*-ой степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса реализовать протокол эквивалентности по значению, перегрузить операции (включая "==" и "!="), допустимые для работы с многочленами (исключая деление многочлена на многочлен). Разработать модульные тесты для тестирования методов класса.
