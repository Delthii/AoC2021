using AoC2021;
/*
var day01 = new Day01();
day01.PartA(GetInput(1));

var day02 = new Day02();
day02.PartA(GetInput(2));
day02.PartB(GetInput(2));

var day03 = new Day03();
day03.PartA(GetInput(3));
day03.PartB(GetInput(3));

var day04 = new Day04();
day04.PartA(GetInput(4));
day04.PartB(GetInput(4));

var day05 = new Day05();
day05.PartA(GetInput(5));
day05.PartB(GetInput(5));
*/

var day06 = new Day06();
Console.Write("Test ");
day06.PartA(GetTestInput(6));
day06.PartA(GetInput(6));
Console.Write("Test ");
day06.PartB(GetTestInput(6));
day06.PartB(GetInput(6));

string[] GetInput(int day)
{
    string daystr = day < 10 ? "0" + day : day.ToString();
    return File.ReadAllLines($"..\\..\\..\\input\\in{daystr}.txt");
}

string[] GetTestInput(int day)
{
    string daystr = day < 10 ? "0" + day : day.ToString();
    return File.ReadAllLines($"..\\..\\..\\input\\in{daystr}test.txt");
}