﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace TSPLul
{

    static class Program
    {

        static Dictionary<int, Point> cities = new Dictionary<int, Point>();
        static List<int> path = new List<int>();
       

        static void ParseFile()
        {
            string filename = "example-input-3.txt"; //Change this for test inputs

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] s = line.Trim().Split(' ');
                    int name = int.Parse(s[0]);
                    int x = int.Parse(s[1]);
                    int y = int.Parse(s[2]);

                    cities[name] = new Point(x, y);
                }
            }
        }

       
       
        static void WritePath(double totalDist)
        {
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine(totalDist);
                for (int i = 0; i < path.Count; i++)
                {
                    writer.WriteLine(path[i]);

                }
                writer.Flush();
 
            }
        }


        static void Main(string[] args)
        {

            ParseFile();

			Dictionary<int, Point> city_info = new Dictionary<int, Point> (cities);
         
            double totalDistance = 0;

            //Start at city 0
            int currentCity = 0;
            Point currentPoint = cities[currentCity];
            
			//Add City 0 to the path and remove it from the possible cities to determine the path to
            path.Add(currentCity);
            cities.Remove(currentCity);

            //Start the algorithm timer
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (cities.Count != 0)
            {
                //Find the city that is closest to us and add distance to our total distance
				int nextFrontCity = cities.MinBy(other => city_info[path[0]].Distance(other.Value)).Key;
				int nextBackCity = cities.MinBy(other => city_info[path[path.Count-1]].Distance(other.Value)).Key;

				double frontCityDistance, backCityDistance;
				int city;

				double distance;

				if( (frontCityDistance = city_info[path[0]].Distance(city_info[nextFrontCity])) < (backCityDistance = city_info[path[path.Count-1]].Distance(city_info[nextBackCity])) )
				{
					distance = frontCityDistance;
					city = nextFrontCity;

					path.Insert(0, city);
				}
				else
				{
					distance = backCityDistance;

					city = nextBackCity;

					path.Add(city);
				}

                totalDistance += Math.Round(distance);
                //Progress to the next city and remove it from the list of distances to search

                cities.Remove(city);
         
                             
				//Console.WriteLine("Distance :"+totalDistance+" City Chosen: "+city+" Path Length: "+path.Count);
            }

			totalDistance += Math.Round (city_info[path[path.Count-1]].Distance(city_info[path[0]]));

            //Stop the timer and write stuff out to a file
            watch.Stop();

            Console.WriteLine("Total Distance: " + totalDistance + " Time: " + watch.ElapsedMilliseconds + "ms");
            WritePath(totalDistance);
            //Console.ReadKey(); //Comment/Uncomment this line if you want to pause execution and wait for keyboard

        }



        #region Extension Methods
        static double Distance(this Point p, Point o)
        {

            return Math.Sqrt((p.X - o.X) * (p.X - o.X) + (p.Y - o.Y) * (p.Y - o.Y));
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MinBy(selector, Comparer<TKey>.Default);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {

            using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence was empty");
                }
                TSource min = sourceIterator.Current;
                TKey minKey = selector(min);
                while (sourceIterator.MoveNext())
                {
                    TSource candidate = sourceIterator.Current;
                    TKey candidateProjected = selector(candidate);
                    if (comparer.Compare(candidateProjected, minKey) < 0)
                    {
                        min = candidate;
                        minKey = candidateProjected;
                    }
                }
                return min;
            }
        }
        #endregion
    }
}
