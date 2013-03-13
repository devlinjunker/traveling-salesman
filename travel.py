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
        
        for line in input:
            line = string.replace(line, '\n', '')
            city_info = string.split(line, " ")

            cords = city_info[1:2]            
            


     

    except IOError:
        print("Error Opening File")
    finally:
        if(input):
            input.close()

    return 0

def travel():
    return ""

def distance():
    return ""

def compare():
    return ""

if __name__ == '__main__':
    main()
