# .NET-Training.-Autumn-2019

## Self-study stage (05.08.2019 - 15.09.2019)
 
| Task | Task Status | Additional/Comments |
| -------- | -------- | --------|  
| [Lections Day 1](https://drive.google.com/drive/folders/0B7WmjuqYed3AWXFzc1Mtcnk3d1k) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Lections Day 2](https://drive.google.com/drive/folders/1_B9ncAWoJtoDvG6vQkxyAvMuXDdqXRAw) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)| 
| [Lections Day 3](https://drive.google.com/drive/folders/1j17L1jUOa9wB1OibGtCuYdsV28kvstr-) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Lections Day 4](https://drive.google.com/drive/folders/1G_Nlntl2BTH0ugKjMVdflPtyQUcUL4Gx) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)| 
| [Lections Day 5](https://drive.google.com/drive/folders/1Eq-C6_EtSlrAgadR-HOyrxUAvqDiw_gM) | ![In progress](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-inprogress.png)| 
| [Lections Day 6](https://drive.google.com/drive/folders/1prlfmRLsVIDR8IERCOyENtsyLt4rO8hW) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 7](https://drive.google.com/drive/folders/17ZHkDv5HTidn4uEmh_kTCCuuB5pf6cI7) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)| 
| [Lections Day 8](https://drive.google.com/drive/folders/1jpw3yZPMepPCP1LYpsi_2FXcQ7m8whpT) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Lections Day 9](https://drive.google.com/drive/folders/1z9dWTY0spT6MI4SAnlUxPIEqraqMlJRG) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Lections Day 10](https://drive.google.com/drive/folders/1cwOLIdvQKFoEC0MMZrcye7gOXvYPY_w1) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Проектирование СУБД. Технострим. Модуль 1](https://www.youtube.com/watch?v=R21v8SoIsiY&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=2&t=929s) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Проектирование СУБД. Технострим. Модуль 2](https://www.youtube.com/watch?v=7t9hLFtN77U&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=2) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Проектирование СУБД. Технострим. Модуль 3](https://www.youtube.com/watch?v=fcNhZDWUGDM&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=3) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
  
---

##  [Stage 2. (16.09.2019 - 30.11.2019)](https://drive.google.com/drive/folders/1zwjMfJoOfPslOcK9_noqN32aL66u7hQ6)

### Day 1. 16.09.2019	
#### Задачи (deadline - 18.09.2019, 24.00)

- Реализовать методы пузырьковой, быстрой и сортировки слиянием для упорядчивания элементов целочисленного массива по нестрогому возрастанию (методы поместить в статический класс ArrayExtension, тип проекта Class Library). 
> Одномерный массив считать упорядоченным, если отношение порядка выполняется для элементов, индексы которых удовлетворяют некоторому заданному условию (например, диапазон и шаг изменения, удоблетворение условия кратности заданной цифре и т.п.), а само отношение порядка определяется некоторой функцией-ключем (например, определяющей количество заданного символа в p-ичном (2<=p<=16) представлении числа, модуль числа и т.п.). *Для получения p-ичного строкового представления числа готовые классы-конверторы не использовать!* 
- Протестировать работу методов с использованием тестового фреймворка NUnit. Для тест-кейсов    
	в качестве функции-ключа использовать:    
		- модуль целочисленного значения элемента массива;     
		- количество вхождений заданного символа c в p-ичном представлении элемента массива;        
	в качестве условия для индексов использовать:   
		- четность;  
		- нечетность;  
		- кратность заданной цифре d.  
- Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом. 

***При выполнение задач данного дня и дней до темы "Делегаты" и "LINQ" запрещено использование типа делагат и LINQ-запросов в библиотеках классов.***

#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |   
| 1 | ![In progress](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-inprogress.png) | [https://github.com/OlgaSheva/.NET-Training.-Autumn-2019/tree/master/NET.Autumn.2019.Kripulevich.01/Algorithms](#) | ![In progress](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-inprogress.png) | [https://github.com/OlgaSheva/.NET-Training.-Autumn-2019/tree/master/NET.Autumn.2019.Kripulevich.01/Algorithms.Tests](#)| Реализован метод пузырьковой сортировки. TODO: быстрая сортировка и сортировка слиянием, вариант тестирования массивов большой размерности.

---

---

## Day ## ##

---

## Day ## ##

---

## Day ## ##

---

...
