﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilistiskModellering;

namespace UnitTests
{
    [TestClass]
    public class GeneticAlgorithmTest
    {
        [TestMethod]
        public void GeneticAlgorithmConstructorTest()
        {
            //arrange
            Program pg = new Program();
            Random random = new Random(1);
            int expected = 2;

            //act
            GeneticAlgorithm<string> ga = new GeneticAlgorithm<string>(2, 10, random, pg.GenerateRandomRedYellowGreenState, 0.05f);

            //assert
            Assert.AreEqual(ga.population.Count, expected);
        }

        private int CompareDNAModified(_DNA a, _DNA b)
        {
            if (a.fitness > b.fitness)
            {
                return -1;
            }
            else if (a.fitness < b.fitness)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        [DataRow(1,2,1)]
        [DataRow(2,1,-1)]
        [DataRow(1,1,0)]
        public void CompareDNATest(int x, int y, int expected)
        {
            //arrange
            _DNA a = new _DNA(x);
            _DNA b = new _DNA(y);
            int c;

            //act
            c = CompareDNAModified(a, b);
            
            //assert
            Assert.AreEqual(c, expected);
        }


    }
    public class _DNA
    {
        public int fitness;
        public _DNA(int fitness)
        {
            this.fitness = fitness;
        }
    }
}