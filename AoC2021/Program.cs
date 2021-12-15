using AoC2021;

int day = 16;
var day16 = new Day16();
day16.PartA(GetTestInput(day));
day16.PartA(GetInput(day));
day16.PartB(GetTestInput(day));
day16.PartB(GetInput(day));

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