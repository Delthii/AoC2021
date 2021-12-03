using AoC2021;

var day01 = new Day01();
day01.PartA(GetInput(1));

var day02 = new Day02();
day02.PartA(GetInput(2));
day02.PartB(GetInput(2));

var day03 = new Day03();
day03.PartA(GetInput(3));
day03.PartB(GetInput(3));

string[] GetInput(int day)
{
    string daystr = day < 10 ? "0" + day : day.ToString();
    return File.ReadAllLines($"..\\..\\..\\input\\in{daystr}.txt");
}