using AoC2021;

var day07 = new Day07();
day07.PartA(GetTestInput(7));
day07.PartA(GetInput(7));
day07.PartB(GetTestInput(7));
day07.PartB(GetInput(7));

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