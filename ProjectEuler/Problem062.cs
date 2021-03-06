﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    partial class ProjectEuler
    {
        /// <summary>
        /// Gets a specific key in a dictionary
        /// </summary>
        /// <param name="permutationsDict">IDictionary</param>
        /// <param name="n">Int</param>
        /// <returns>The first key in permutationsDict with value n</returns>
        static string getSpecificDictionaryKey(IDictionary<string, int> permutationsDict, int n)
        {
            var values = permutationsDict.Values.ToArray();
            var keys = permutationsDict.Keys.ToArray();
            return keys[values.ToList().IndexOf(n)];
        }

        /// <summary>
        ///  Calculates the smallest cube for which exactly five permutations of its digits are cube
        /// </summary>
        static void P062()
        {
            var cubes = from i in Enumerable.Range(1, 8400) select Math.Pow(i, 3);
            IDictionary<string, int> cubePermutationsDict = new Dictionary<string, int>();
            foreach (string s in (from cube in cubes select String.Concat((from c in cube.ToString() select c.ToString()).OrderBy(c => c))))
            {
                int count = cubePermutationsDict.ContainsKey(s) ? cubePermutationsDict[s] : 0;
                cubePermutationsDict[s] = count + 1;
            }
            foreach (double ans in cubes)
                if (String.Concat((from c in ans.ToString() select c.ToString()).OrderBy(c => c)) == getSpecificDictionaryKey(cubePermutationsDict, 5))
                {
                    Console.WriteLine(ans);
                    break;
                }
        }
    }
}