using System;
using System.Collections.Generic;

namespace TowerDefender.Commons
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Select n elements at random from the indicated array
        /// </summary>
        /// <typeparam name="T">array data type</typeparam>
        /// <param name="choses">Array with values to select</param>
        /// <param name="numberToChoose">Number of expected results</param>
        /// <returns></returns>
        public static T[] Choose<T>(this T[] choses, int numberToChoose)
        {
            System.Random rnd = new System.Random();
            var items = new List<T>();
            items.AddRange(choses);

            List<T> chosenItems = new List<T>();
            for (int i = 1; i <= numberToChoose; i++)
            {
                int index = rnd.Next(items.Count);
                chosenItems.Add(items[index]);
                items.RemoveAt(index);
            }

            return chosenItems.ToArray();
        }
    }
}