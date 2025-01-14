## ExtTraining.Autumn.2019.3

### Day 7. 30.09.2019	

1. Некто L начал разработку библиотеки (проект *Algorithms.V1*) для алгебраических вычислений. Согласно требованию библиотека должна быть реализована как статический класс с удобными для использования для различного рода расчетов статическими методами, в частности, методами, реализующими подсчет НОД-а для двух, трех, четырех и т.д. целых чисел алгоритмом Евклида (Стайна), включая возможность подсчета времени вычислений.

	Завершите разработку библиотеки, начатой L, добавив недостающий функционал, *не изменяя сигнутуры существующих в типах методов*.
	
	Какие класс (классы) необходимо будет изменить в случае, если появиться необходимость добавить реализацию еще одного алгоритма Евклида? обоснуйте целесообразность использования подхода, предложенного L, с точки зрения трудозатрат при добавлении такой функциональности. 
	  
	Подумайте, является ли необходимость подсчета времени ответственностью класса алгоритма.
	
2. Некто M начал разработку библиотеки (проект *Algorithms.V2*) для алгебраических вычислений. Согласно требованию библиотека должна предоставлять набор типов с удобными для использования различного рода расчетов методами, в частности, методами, реализующими подсчет НОД-а для двух, трех, четырех и т.д. целых чисел классическим алгоритмом Евклида (Стайна), включая возможность подсчета времени вычислений.   

	Завершите разработку библиотеки, начатой M, добавив недостающий функционал, *не изменяя сигнутуры обозначенных в типах методов и наборы публичных членов предложенных типов*. При реализации для обозначенных алгоритмов возможности подсчета НОД-а для трех, четырех и т.д. целых чисел использовать *методы расширения*. При реализации возможности подсчета времени для обозначенных алгоритмов использовать *методы расширения*.
	
	Какие класс (классы) необходимо будет изменить в случае, если появиться необходимость добавить реализацию еще одного алгоритма? обоснуйте целесообразность использования подхода, предложенного M, с точки зрения трудозатрат при добавлении такой функциональности.   
	
3. Некто N начал разработку библиотеки (проект *Algorithms.V3*) для алгебраических вычислений. Согласно требованию библиотека должна предоставлять набор типов с удобными для использования различного рода расчетов методами, в частности, методами, реализующими подсчет НОД-а двух, трех, четырех и т.д. целых чисел классическим алгоритмом Евклида (Стайна), включая возможность подсчета времени вычислений.  
 
	Завершите разработку библиотеки, начатой N, добавив недостающий функционал, *не изменяя сигнутуры обозначенных в типах методов и наборы публичных членов предложенных типов*. Для реализации для обозначенных алгоритмов возможности подсчета НОД-а для трех, четырех и т.д. целых чисел разработать новый класс, который *расширяет* функциональность исходных, *не используя классического наследования*. Добавить в полученный класс возможность подсчета времени работы алгоритмов.
	
	Какие класс (классы) необходимо будет изменить в случае, если появиться необходимость добавить реализацию еще одного алгоритма? обоснуйте целесообразность использования подхода, предложенного N, с точки зрения трудозатрат при добавлении такой функциональности.  
	
4. Некто K начал разработку библиотеки (проект *Algorithms.V4*) для алгебраических вычислений. Согласно требованию библиотека должна предоставлять набор типов с удобными для использования различного рода расчетов методами, в частности, методами, реализующими подсчет НОД-а двух, трех, четырех и т.д. целых чисел классическим алгоритмом Евклида (Стайна), включая возможность подсчета времени вычислений.
	
	Завершите разработку библиотеки, начатой K, добавив недостающий функционал, *не изменяя сигнутуры обозначенных в типах методов и наборы публичных членов предложенных типов*. Для реализации для обозначенных алгоритмов возможности подсчета НОД-а для трех, четырех и т.д. целых чисел разработать новый класс, который расширяет функциональность исходных, *не используя классического наследования*. При реализации данного класса учесть *возможность замены класса Stopwatch для подсчета времени работы алгоритмов классом обладающим аналогичной функциональностью*. Добавить в полученный класс возможность логирования исключений, которые могут возникнуть при работе методов, предусмотрев возможность использования *различных фреймворков для логирования*.
	Какие класс (классы) необходимо будет изменить в случае, если появиться необходимость добавить реализацию еще одного алгоритма? обоснуйте целесообразность использования подхода, предложенного K, с точки зрения трудозатрат при добавлении такой функциональности.    

#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |   
| 1 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Algorithms.V1*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*NUnit Tests*](#) 
| 2 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Algorithms.V2*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*NUnit Tests*](#) 
| 3 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Algorithms.V3*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*NUnit Tests*](#)
| 4 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Algorithms.V4*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*NUnit Testse*](#)
