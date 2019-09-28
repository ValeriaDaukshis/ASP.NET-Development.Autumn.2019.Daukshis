https://core2.me/me/?cv=28d.2u
# .NET-Training.-Autumn-2019

## Self-study stage (05.08.2019 - 15.09.2019)
 
| Task | Task Status | Additional/Comments |
| -------- | -------- | --------|  
| [Lections Day 1](https://drive.google.com/drive/folders/0B7WmjuqYed3AWXFzc1Mtcnk3d1k) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)| 
| [Lections Day 2](https://drive.google.com/drive/folders/1_B9ncAWoJtoDvG6vQkxyAvMuXDdqXRAw) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|Array.CopyTo, Clone (12 пример LinqPad )
| [Lections Day 3](https://drive.google.com/drive/folders/1j17L1jUOa9wB1OibGtCuYdsV28kvstr-) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Lections Day 4](https://drive.google.com/drive/folders/1G_Nlntl2BTH0ugKjMVdflPtyQUcUL4Gx) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 5](https://drive.google.com/drive/folders/1Eq-C6_EtSlrAgadR-HOyrxUAvqDiw_gM) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 6](https://drive.google.com/drive/folders/1prlfmRLsVIDR8IERCOyENtsyLt4rO8hW) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 7](https://drive.google.com/drive/folders/17ZHkDv5HTidn4uEmh_kTCCuuB5pf6cI7) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 8](https://drive.google.com/drive/folders/1jpw3yZPMepPCP1LYpsi_2FXcQ7m8whpT) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 9](https://drive.google.com/drive/folders/1z9dWTY0spT6MI4SAnlUxPIEqraqMlJRG) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Lections Day 10](https://drive.google.com/drive/folders/1cwOLIdvQKFoEC0MMZrcye7gOXvYPY_w1) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Проектирование СУБД. Технострим. Модуль 1](https://www.youtube.com/watch?v=R21v8SoIsiY&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=2&t=929s) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png)|
| [Проектирование СУБД. Технострим. Модуль 2](https://www.youtube.com/watch?v=7t9hLFtN77U&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=2) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
| [Проектирование СУБД. Технострим. Модуль 3](https://www.youtube.com/watch?v=fcNhZDWUGDM&list=PLrCZzMib1e9pq_sbw7ZEcEU3Yyz1AvE--&index=3) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png)|
 
---

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
| 1 | ![In process](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-inprogress.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.01/Task1/ArrayExtension.cs) | ![In process](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-inprogress.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.01/ArrayExtensions.Tests/ArrayExtensionTests.cs) | [*Link to Tests Generator code - cs-file - Optional*](#)

---

### Day 2. 17.09.2019	

#### Задачи
1. **(deadline - 20.09.2019, 24.00)** Даны два целых знаковых четырехбайтовых числа и две позиции битов i и j (i<=j). Реализовать алгоритм вставки первых (j - i + 1) битов второго числа в первое так, чтобы биты второго числа занимали позиции с бита i по бит j (биты нумеруются справа налево). Решение оформить  в виде статического метода **InsertNumberIntoAnother** статического класса **NumbersExtension**. Разработать модульные тесты (NUnit и MS Unit Test - ([DDT](https://msdn.microsoft.com/en-us/library/ms182527.aspx)))) для тестирования метода. (Ниже схема-пояснение к алгоритму). Примерные тест-кейсы

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
2. **(deadline - 19.09.2019, 24.00)** Реализовать *рекурсивный* алгоритм поиска максимального элемента в неотсортированном целочисленом массиве. Решение оформить  в виде статического метода **FindMximumItem** статического класса **ArrayExtension**. Разработать модульные тесты NUnit для тестирования метода. Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом.  
3. **(deadline - 21.09.2019, 24.00))** Реализовать алгоритм поиска в целочисленном массиве индекса элемента, для которого сумма элементов слева и сумма элементов справа равны. Решение оформить  в виде статического метода **FindBalanceIndex** статического класса **ArrayExtension** (п. 2). Если такого элемента не существует вернуть null. Разработать модульные тесты NUnit. Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом.    
4. **(deadline - 22.09.2019, 24.00))** Реализовать метод, который принимает массив целых чисел и фильтрует его таким образом, чтобы на выходе был получен новый массив, состоящий только из элементов, которые содержат заданную цифру. (*LINQ-запросы не использовать!*) В случае, если таких элементов нет, вернуть пустой массив. Решение оформить  в виде статического метода **FilterArrayByKey** статического класса **ArrayExtension** (п. 2). Например, для цифры 7, метод **FilterArrayByKey** для набора {7,1,2,3,4,5,6,7,68,69,70,15,17} возвращает набор {7,7,70,17}. Разработать модульные тесты NUnit и MS Unit Test для тестирования метода. Примерные тест-кейсы 
        
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        ArrayExtension.FilterArrayByKey(new int[0], 0)) => ArgumentException
        ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1) => ArgumentOutOfRangeException
        ArrayExtension.FilterArrayByKey(null, 0) => ArgumentNullException
        ...
        
#### Task Status

| Task | Solution Status | Solution Link | MS Test Status | MS Test Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- | -------- | -------- |    
| 1 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/InsertNumber/NumbersExtension.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to MS Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/InsertNumberIntoAnother.MsTests/InsertNumberIntoAnotherMsTests.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/InsertNumberIntoAnother.Tests/InsertNumberIntoAnotherTests.cs) |
| 2 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FindMaxRecursive/ArrayExtension.cs) |  |  | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FindMaximumItem.Tests/FindMaximumItemTests.cs) |
| 3 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FindBalanceIndexTask/ArrayExtension.cs) |  |  | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FindBalanceIndex.Tests/FindBalanceIndexTests.cs) |
| 4 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/Filter/ArrayExtension.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to MS Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FilterArrayByKey.MsTests/FilterArrayByKeyMsTests.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/Net.Autumn.2019.Daukshis.02/FilterArrayByKey.Tests/FilterArrayByKeyTests.cs) |

---

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
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 25.09.2019, 24.00)** Реализовать метод, который для данного положительное целого число находит ближайшее наименьшее целое, состоящее из цифр исходного числа, если такое число существует. Решение оформить  в виде статического метода **FindPreviousLessThan** статического класса **NumbersExtension** (Day 1. п. 2). Разработать модульные тесты для тестирования метода.  

#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |  
| 1 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.03/FindNthRootClass/MathExtension.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.03/Root.Tests/MathExtensionTests.cs)
| 2 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.03/NextBiggerThanClass/NumbersExtension.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.03/Number.Tests/NumbersExtensionTests.cs)

---
### Day 4. 23.09.2019

#### Задачи
  
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - in class)**   
 	- Проанализировать код, полученный при решении задачи #4 (Day 2. 17.09.2019), на предмет возможности его использования для получения (из исходного) массива, состоящего только из тех элементов исходного, запись которых является полиндромом (симметричным)(например 121, 1345431, 122221 и т.д.). *Функцию, определяющую является ли число полиндромом, реализовать как рекурсивную.*   	
 	- Добавить, если требуется, недостающую функциональность.
	- Проанализировать полученный код на возможность его использования для получения (из исходного) массива, состоящего только из четных элементов исходного. Добавить, если требуется, недостающую функциональность.
	- Предложить вариант общей формулировки решенных задач.  
	- Полученный методы (методы) оформить как метод (методы) расширения для целочисленных массивов. 
 	
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 27.09.2019, 15.00)** 
	- В статический класс **MathExtension** (п. 1) добавть **FindGcdByEuclidean**-методы которого позволяют выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/). Добавить методы, которые помимо вычисления НОД, предоставляют дополнительную возможность определения значение времени, необходимое для выполнения расчета. К разработанному классу добавить **FindGcdByStein**-методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), а также методы,  предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.

#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |  
| 1 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.04/Filters/ArrayExtension.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.04/FilterArray.Test/FilterArrayTests.cs)
| 2 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.04/FindGcd/Gcd.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.04/Gcd.Tests/GcdTests.cs)

--- 

### Day 5. 24.09.2019

#### Задачи
  
1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png))**
 Разработать систему типов для описания работы с банковским счетом. Состояние счета определяется его номером, данными о владельце счета (имя, фамилия, e-mail), суммой на счете, его текущим состоянием (активен, закрыт, заморожен ...) и некоторыми бонусными баллами, которые увеличиваются каждый раз при пополнении счета/списании со счета на величины различные для пополнения и списания и рассчитываемые в зависимости от некоторых значений величин «стоимости» баланса и «стоимости» пополнения. Величины «стоимости» баланса и «стоимости» пополнения являются целочисленными значениями и зависят от типа счета, который может быть, Base, Silver, Gold. Для работы со счетом реализовать следующие возможности:
	- пополнение на счет;
	- списание со счета (для счетов выше Base, возможен списание в кредит, размер кредита зависит от статуса счета);
	- перевод суммы с одного счета на другой счет;
	- создание нового счета;
	- закрытие счета.
Работу типов продемонстрировать на примере консольного приложения.
#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |  
| 1 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Link to .cs-file here*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Link to NUnit Tests - cs-file here*](#)

---

### Day 6. 26.09.2019

#### Задачи

1. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 25.09.2019, 24.00 )**
Реализовать экземплярный класс Transformer, экземплярный метод TransformToWords которого выполняет преобразование любого вешественного (System.Double) числа в его "словестный формат". Разработать модульные тесты. Примерные тест-кейсы
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
		
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 28.09.2019, 24.00 )**
Расширить функциональную возможность типа System.Double, реализовав возможность получения строкового представления вещественного числа в формате IEEE 754. Готовые классы-конверторы не использовать. Разработать модульные тесты. Примерные тест-кейсы (для тестирования специальных значений вещественных чисел возможны варианты).
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

3. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 30.09.2019, 24.00 )**
Разработать неизменяемый класс Polynomial (полином) для работы с многочленами n-ой степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса реализовать протокол эквивалентности по значению, перегрузить операции (включая "==" и "!="), допустимые для работы с многочленами (исключая деление многочлена на многочлен). Разработать модульные тесты для тестирования методов класса.

#### Task Status

| Task | Solution Status | Solution Link | NUnit Tests Status | NUnit Tests Link | Additional/Comments |
| -------- | -------- | --------| --------|  -------- |  -------- |  
| 1 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.06/TransformProject/Transformer.cs) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.06/Transformer.Tests/TransformerTests.cs)
| 2 | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to .cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/tree/master/NET.Autumn.2019.Daukshis.06/TransformerWithAbstractFactory) | ![Done](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-ok.png) | [*Link to NUnit Tests - cs-file here*](https://github.com/ValeriaDaukshis/ASP.NET-Development.Autumn.2019.Daukshis/blob/master/NET.Autumn.2019.Daukshis.06/Transformer.Tests/TransformerTests.cs)
| 3 | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Link to .cs-file here*](#) | ![Scheduled](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons-target.png) | [*Link to NUnit Tests - cs-file here*](#)

---










