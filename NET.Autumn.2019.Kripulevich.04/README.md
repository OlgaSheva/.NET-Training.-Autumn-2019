### Day 4. 23.09.2019
#### Читать
- [C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015.](https://drive.google.com/drive/u/0/folders/0B7WmjuqYed3Aeko0MzNYZWtVOUk)
   - *Chapter 3.* Creating Types in C#
- [C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013.](https://drive.google.com/drive/u/0/folders/0B7WmjuqYed3Aeko0MzNYZWtVOUk)
   - *Chapter 9.* Introducing Types


#### Материалы
- [Basic Coding in C#](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M4.%20Methods%20in%20details)
- [Creating types in C#](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M3.%20Creating%20types%20in%20C%23)


#### Задачи
  
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 28.09.2019, 24.00)**   
 	- Проанализировать код, полученный при решении задачи #4 (Day 2. 17.09.2019), на предмет возможности его использования для получения (из исходного) массива, состоящего только из тех элементов исходного, запись которых является полиндромом (симметричным)(например 121, 1345431, 122221 и т.д.). *Функцию, определяющую является ли число полиндромом, реализовать как рекурсивную.*   	
 	- Добавить, если требуется, недостающую функциональность.
	- Проанализировать полученный код на возможность его использования для получения (из исходного) массива, состоящего только из четных элементов исходного. Добавить, если требуется, недостающую функциональность.
	- Предложить вариант общей формулировки решенных задач.  
	- Полученный методы (методы) оформить как метод (методы) расширения для целочисленных массивов. 
 	
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 27.09.2019, 15.00)** 
	- В статический класс **MathExtension** (п. 1) добавть **FindGcdByEuclidean** - методы которого позволяют выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/). Добавить методы, которые помимо вычисления НОД, предоставляют дополнительную возможность определения значение времени, необходимое для выполнения расчета. К разработанному классу добавить **FindGcdByStein**-методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), а также методы,  предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.
