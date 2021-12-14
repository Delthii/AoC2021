using AoC2021;

var day14 = new Day14();
day14.PartA(GetTestInput(14));
day14.PartA(GetInput(14));
day14.PartB(GetTestInput(14));
day14.PartB(GetInput(14));



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