public class Day02
{
    public Day02()
    {
    }

    public int PartA(string[] lines)
    {
        int depth = 0;
        int forward = 0;
        foreach (var line in lines)
        {
            (int amount, string dir) = (int.Parse(line.Split()[1]), line.Split()[0]);
            switch (dir)
            {
                case "forward":
                    forward += amount;
                    break;
                case "down":
                    depth += amount;
                    break;
                case "up":
                    depth -= amount;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(depth * forward);
        return depth * forward;
    }

    public int PartB(string[] lines)
    {
        int depth = 0;
        int forward = 0;
        int aim = 0;
        foreach (var line in lines)
        {
            (int amount, string dir) = (int.Parse(line.Split()[1]), line.Split()[0]);
            switch (dir)
            {
                case "forward":
                    forward += amount;
                    depth += aim * amount;
                    break;
                case "down":
                    aim += amount;
                    break;
                case "up":
                    aim -= amount;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(depth * forward);
        return depth * forward;
    }
}