## Задачи

![Done](http://s1.iconbird.com/ico/0512/C9d/w24h241337874507check.png) 1. Реализовать алгоритм FindNthRoot, позволяющий вычислять корень **n**-ой степени ( n ∈ N ) из вещественного числа **а** методом Ньютона с заданной точностью.
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
      
![Done](http://s1.iconbird.com/ico/0512/C9d/w24h241337874507check.png) 2. Реализовать метод, который для данного положительное целого число находит ближайшее меньшее целое, состоящее из цифр исходного числа, если такое число существует. Решение оформить в виде статического метода FindPreviousLessThan статического класса NumbersExtension (Day 1. п. 2). Разработать модульные тесты для тестирования метода.
 