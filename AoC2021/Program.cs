using AoC2021;

var day12 = new Day12();
day12.PartA(GetTestInput(11));
day12.PartA(GetInput(11));
day12.PartB(GetTestInput(11));
day12.PartB(GetInput(11));



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