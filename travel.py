#! /usr/bin/python
# CS 325 Implementation Assignment 2 
# Devlin Junker
# Garrett Fleenor
# 2/20/13

import fileinput
import argparse
import string
import time
import sys

NUM_TEST_CASES = 1

DEBUG = 0

def main():
    input = False

    parser = argparse.ArgumentParser();
    
    parser.add_argument("-file", default="input.txt", dest="filename", help="The name of the file to read test case inputs from, defaults to input.txt (Each test case is a seperate line of numbers where each number is seperated by a comma)")

    args = parser.parse_args()

    try:
        input = open(args.filename, 'rU')
        
        cords = []

        for line in input:
            line = string.replace(line, '\n', '')
            city_info = map(int,  string.split(line, " ") )

            cords.append(city_info[1:3])
        
        print range(0)
        print cords 
        print cords[2]
     
        distance = [[0 for j in range(len(cords))] for i in range(len(cords))]

        for i in range( len(cords) ):
            
            for j in (range( i ) + range( i+1, len(cords) )):
                distance[i][j] = get_distance( cords[i], cords[j] )

        
        tour = travel(distance)

    except IOError:
        print("Error Opening File")
    finally:
        if(input):
            input.close()

    return 0

def travel(distance):

    not_visted = range(len(distance))
    visited = []

    for x in :


    return ""

def get_distance(city1, city2):
    return (city1[0]-city2[0])**2 + (city1[1]-city2[1])**2

def compare():
    return ""

if __name__ == '__main__':
    main()
