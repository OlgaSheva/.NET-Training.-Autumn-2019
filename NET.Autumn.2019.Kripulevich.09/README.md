### Day 9. 03.10.2019

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

1. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 05.10.2019, 24.00**) Переобразовать методы расширения класса ArrayExtension [Day 8](#8-Tasks) в обобщенно-типизированные. Убедиться, что все написанные ранее тесты проходят. 
2. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 05.10.2019, 24.00**) Добавить в класс с методами рассширения новый обобщенный метод расширения, который получает из массива объектов новый массив, все элементы которого имеют один тип.
3. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 06.10.2019, 24.00**) Реализовать метод-генератор последовательности чисел Фибоначчи. Разработать unit-тесты.
4. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 05.10.2019, 24.00**) Разработать обобщенный типизированный класс-коллекцию `Queue<T>`, реализующий основные операции для работы с очередью, и предоставляющий возможность итерирования по ней. Протестировать методы разработанного класса.
5. (**![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 10.10.2019, 24.00**) Заполните таблицу

| Collection | Indexed lookup | Keyed lookup | Value lookup | Addition |  Removal |  Memory |      
| -------- | -------- | --------| --------|  -------- |  -------- |  -------- |    
| **Списки** | | | | | | |   
| `T[]` | O(1) | -  | O(n) | O(n) | O(n) | Elements + additional info (like array's length) |   
| `List<T>` | | | | | | |   
|`LinkedList<T>`  |  |  |  |  |  |  |  
|`Collection<T>`  |  |  |  |  |  |  |  
|`BindingList<T>`  |  |  |  |  |  |  |  
|`ObservableCollection<T>`  |  |  |  |  |  |  |
|`KeyCollection<TKey, TItem>`  |  |  |  |  |  |  |
|`ReadOnlyCollection<T>`  |  |  |  |  |  |  |
|`ReadOnlyObservableCollection<T>` |  |  |  |  |  |  |
**Словари** | | | | | | |  
|`Dictionary<TKey, TValue>`   |  |  |  |  |  |  |
|`SortedList<TKey, TValue>`   |  |  |  |  |  |  |
|`SortedDictionary<TKey, TValue>`  |  |  |  |  |  |  |
|`SortedDictionary<TKey,TValue>`.   |  |  |  |  |  |  |  
`ReadOnlyDictionary<TKey, TValue> `   |  |  |  |  |  |  |
**Множества** | | | | | | | 
|`HashSet<T>`  |  |  |  |  |  |  |
|`SortedSet<T>`   |  |  |  |  |  |  |
| **Очередь, стек** | | | | | | | 
|`Queue<T>`  |  |  |  |  |  |  |
|`Stack<T>`  |  |  |  |  |  |  |
* `*` If ... .
* `**`If ... .


|Collection | Underlying structure | Lookup strategy | Ordering | Contiguous storage | Data access | Exposes Key & Value collection | 
| -------- | -------- | --------| --------|  -------- |  -------- |  -------- | 
**Списки** | | | | | | |  
|`T[]` | `System.Array` | - | No | Yes | Index | No |   
|`List<T>` | |  | | | | |   
|`LinkedList<T>` | |  | | | | |   
|`Collection<T>` | |  | | | | |   
|`BindingList<T>` | |  | | | | |   
|`ObservableCollection<T>`  | |  | | | | |   
|`KeyCollection<TKey, TItem>`  | |  | | | | |   
|`ReadOnlyCollection<T>` | |  | | | | |   
|`ReadOnlyObservableCollection<T>`  | |  | | | | | 
|**Словари** | | | | | | | 
|`Dictionary<TKey, TValue>` | |  | | | | |    
|`SortedList<TKey, TValue>`  | |  | | | | |   
|`SortedDictionary<TKey, TValue>`  | |  | | | | |   
|`ReadOnlyDictionary<TKey, TValue>`  | |  | | | | |   
|**Множества** | | | | | | | 
|`HashSet<T>` | |  | | | | |   
|`SortedSet<T>`  | |  | | | | |   
|**Очередь, стек** | | | | | | | 
|`Queue<T>` | |  | | | | |   
|`Stack<T>` | |  | | | | |   

* `*` ... .
* `**` ... .
