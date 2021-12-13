using AoC2021;

var day9 = new Day09Take2();
//day9.PartA(GetTestInput(9));
//day9.PartA(GetInput(9));
day9.PartB(GetTestInput(9));



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