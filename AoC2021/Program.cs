using AoC2021;

var day10 = new Day10();
day10.PartA(GetTestInput(10));
day10.PartA(GetInput(10));
day10.PartB(GetTestInput(10));
day10.PartB(GetInput(10));



string[] GetInput(int day)
{
    string daystr = day < 10 ? "0" + day : day.ToString();
    return File.ReadAllLines($"..\\..\\..\\input\\in{daystr}.txt");
}

string[] GetTestInput(int day)
{
    string daystr = day < 10 ? "0" + day : day.ToString();
    return File.ReadAllLines($"..\\..\\..\\testinput\\in{daystr}test.txt");
}