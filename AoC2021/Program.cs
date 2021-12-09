using AoC2021;

var day09 = new Day09();
day09.PartA(GetTestInput(9));
day09.PartA(GetInput(9));
day09.PartB(GetTestInput(9));
day09.PartB(GetInput(9));


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