### Day 8. 01.10.2019

#### Материалы
- [Programming C# 5.0. Ian Griffiths. O'Reilly Media. 2012.](http://shop.oreilly.com/product/0636920024064.do) 
   - *Chapter 4.* Generics. [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch04.zip) 
   - *Chapter 5.* Collections. [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch05.zip)
- [C# in Depth. Jon Skeet. Manning Publications Co. 2013](https://www.manning.com/books/c-sharp-in-depth-third-edition)
   - *Chapter 3.* [Parameterized typing with generics.](https://livebook.manning.com/#!/book/c-sharp-in-depth-third-edition/chapter-3/)
   - *Appendix B.* [Generic collections in .NET.](https://livebook.manning.com/#!/book/c-sharp-in-depth-third-edition/appendix-b/)
- [C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015.](http://shop.oreilly.com/product/0636920040323.do)
   - *Chapter 7.* Collections. [Code Listings](http://www.albahari.com/nutshell/ch07.aspx)
- [C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013](https://www.goodreads.com/book/show/16284093-c-5-0-unleashed)
   - *Chapter 15.* Generic Types and Methods.
   - *Chapter 16.* Collection Types.
- [CLR via C#. Jeffrey Richter. Microsoft Press. 2010](https://www.goodreads.com/book/show/7121415-clr-via-c)
   - *Chapter 12.* Generics.
- [Pro .NET Performance: Optimize Your C# Applications. Sasha Goldshtein.](http://www.apress.com/us/book/9781430244585)
   - *Chapter 5.* Collections and Generics   

#### Задачи

1. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 03.10.2019, 24.00**) Создать новый статический класс ArrayExtension, в который поместить код метода FilterArrayByKey [Task 4](#2-Tasks), переименовав метод в Filter и сделав его методом расширения соответствующего массива. Метод должен уметь возвращать только те элемнты исходного массива, которые удовлетворяют определенному условию (предикату). И добавить метод FindMaximumItem [Task 2](#2-Tasks), как метод расширения, переименовать в Max .
2. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 03.10.2019, 24.00**) Добавить в статический класс ArrayExtension (п.1) метод расширения Transform который трансформирует элементы массива вещественных чисел в строку согласно переданному правилу. Проверить работу разработанного метода. В качестве тест-кейсов использовать следующие правила
  - получение для вещественного числа его строкового "словесно-цифрового" описания на английском языке;
  - получение для вещественного числа его строкового "словесно-цифрового" описания на русском языке;
  - получение для вещественного числа его битового строкового предстваления в формате IEEE 754.    
*Как, не изменяя код класса Transformer [Task 1](#6-Tasks), его можно использовать в качестве правила для трансформации элементов массива в этом методе.*
*Как, не изменяя код класса с методом расширения [Task 2](#6-Tasks), его можно использовать в качестве правила для трансформации элементов массива в этом методе.*
3. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 04.10.2019, 24.00**) Добавить в статический класс ArrayExtension метод расширения для массива строк OrderAccordingTo, который возвращает элементы исходного массива в порядке, определенном переданным правилом сравнения. (*С индексированием не мудрить! Это будет обычная сортировка с той лишь разницей, что упорядоченный массив будет в качестве возвращаемого значения, а исходный не изменится*.)
