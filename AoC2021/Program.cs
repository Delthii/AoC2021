using AoC2021;

int day = 17;
var day17 = new Day17();
var ans = day17.PartA(GetTestInput(day));
day17.PartA(GetInput(day));
day17.PartB(GetTestInput(day));
day17.PartB(GetInput(day));

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