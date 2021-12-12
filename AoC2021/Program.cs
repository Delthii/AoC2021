using AoC2021;

var day13 = new Day13();
day13.PartA(GetTestInput(13));
day13.PartA(GetInput(13));
day13.PartB(GetTestInput(13));
day13.PartB(GetInput(13));



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