using AoC2021;
using NUnit.Framework;
using System.IO;

namespace Tests
{
    public class Tests
    {
        string[] GetInput(int day)
        {
            string daystr = day < 10 ? "0" + day : day.ToString();
            return File.ReadAllLines($"..\\..\\..\\..\\AoC2021\\input\\in{daystr}.txt");
        }

        string[] GetTestInput(int day)
        {
            string daystr = day < 10 ? "0" + day : day.ToString();
            return File.ReadAllLines($"..\\..\\..\\..\\AoC2021\\testinput\\in{daystr}test.txt");
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day01()
        {
            var day01 = new Day01();
            Assert.AreEqual(1482, day01.PartA(GetInput(1)));
            Assert.AreEqual(1518, day01.PartB(GetInput(1)));
        }

        [Test]
        public void Day02()
        {
            var day02 = new Day02();
            Assert.AreEqual(1868935, day02.PartA(GetInput(2)));
            Assert.AreEqual(1965970888, day02.PartB(GetInput(2)));
        }

        [Test]
        public void Day03()
        {
            var day03 = new Day03();
            Assert.AreEqual(4006064, day03.PartA(GetInput(3)));
            Assert.AreEqual(5941884, day03.PartB(GetInput(3)));
        }

        [Test]
        public void Day04()
        {
            var day04 = new Day04();
            Assert.AreEqual(60368, day04.PartA(GetInput(4)));
            Assert.AreEqual(17435, day04.PartB(GetInput(4)));
        }

        [Test]
        public void Day05()
        {
            var day05 = new Day05();
            Assert.AreEqual(5084, day05.PartA(GetInput(5)));
            Assert.AreEqual(17882, day05.PartB(GetInput(5)));
        }

        [Test]
        public void Day06()
        {
            var day06 = new Day06();
            Assert.AreEqual(362639, day06.PartA(GetInput(6)));
            Assert.AreEqual(1639854996917, day06.PartB(GetInput(6)));
        }

        [Test]
        public void Day07()
        {
            var day07 = new Day07();
            Assert.AreEqual(355592, day07.PartA(GetInput(7)));
            Assert.AreEqual(101618069, day07.PartB(GetInput(7)));
        }

        [Test]
        public void Day08()
        {
            var day08 = new Day08Take2();
            Assert.AreEqual(989396, day08.PartB(GetInput(8)));
        }

        [Test]
        public void Day09()
        {
            var day09 = new Day09();
            Assert.AreEqual(496, day09.PartA(GetInput(9)));
            Assert.AreEqual(902880, day09.PartB(GetInput(9)));
            var day09_2 = new Day09Take2();
            Assert.AreEqual(496, day09_2.PartA(GetInput(9)));
            Assert.AreEqual(902880, day09_2.PartB(GetInput(9)));
        }

        [Test]
        public void Day10()
        {
            var day10 = new Day10();
            Assert.AreEqual(388713, day10.PartA(GetInput(10)));
            Assert.AreEqual(3539961434, day10.PartB(GetInput(10)));
        }

        [Test]
        public void Day11()
        {
            var day11 = new Day11();
            Assert.AreEqual(1721, day11.PartA(GetInput(11)));
            Assert.AreEqual(298, day11.PartB(GetInput(11)));
            var day11_2 = new Day11Take2();
            Assert.AreEqual(1721, day11_2.PartA(GetInput(11)));
            Assert.AreEqual(298, day11_2.PartB(GetInput(11)));
        }

        [Test]
        public void Day12()
        {
            var day12 = new Day12();
            Assert.AreEqual(3576, day12.PartA(GetInput(12)));
            Assert.AreEqual(84271, day12.PartB(GetInput(12)));
        }

        [Test]
        public void Day14()
        {
            var day14 = new Day14();
            Assert.AreEqual(2768, day14.PartA(GetInput(14)));
            Assert.AreEqual(2914365137499, day14.PartB(GetInput(14)));
        }

        [Test]
        public void Day15()
        {
            var day15 = new Day15();
            Assert.AreEqual(673, day15.PartA(GetInput(15)));
            Assert.AreEqual(2893, day15.PartB(GetInput(15)));
        }

        [Test]
        public void Day16()
        {
            var day16 = new Day16();
            Assert.AreEqual(974, day16.PartA(GetInput(16)));
            Assert.AreEqual(180616437720, day16.PartB(GetInput(16)));
        }
    }
}