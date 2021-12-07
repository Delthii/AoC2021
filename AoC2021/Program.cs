using AoC2021;

var day08 = new Day08();
day08.PartA(GetTestInput(8));
day08.PartA(GetInput(8));
day08.PartB(GetTestInput(8));
day08.PartB(GetInput(8));


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