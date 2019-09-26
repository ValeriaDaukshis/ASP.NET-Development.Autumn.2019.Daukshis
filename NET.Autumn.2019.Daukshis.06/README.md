## Задачи
![Done](http://s1.iconbird.com/ico/0512/C9d/w24h241337874507check.png) 1. Реализовать экземплярный класс Transformer, экземплярный метод TransformToWords которого выполняет преобразование любого вешественного (System.Double) числа в его "словестный формат". Разработать модульные тесты. Примерные тест-кейсы
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
		
2. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 28.09.2019, 24.00 ) **
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

3. **(![deadline](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/blob/master/Pictures/icons8-stopwatch-64.png) - 30.09.2019, 24.00 ) **
Разработать неизменяемый класс Polynomial (полином) для работы с многочленами n-ой степени от одной переменной вещественного типа (в качестве внутренней структуры для хранения коэффициентов использовать sz-массив). Для разработанного класса реализовать протокол эквивалентности по значению, перегрузить операции (включая "==" и "!="), допустимые для работы с многочленами (исключая деление многочлена на многочлен). Разработать модульные тесты для тестирования методов класса.
