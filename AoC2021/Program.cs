using AoC2021;

var day15 = new Day15();
day15.PartA(GetTestInput(15));
day15.PartA(GetInput(15));
day15.PartB(GetTestInput(15));
day15.PartB(GetInput(15));

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