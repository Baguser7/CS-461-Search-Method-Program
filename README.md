# CS-461-Search-Method-Program
Search Method Program for CS 461 Assignment
Bagus Hendrawan
------------------------------------------------------

> Summary
----------
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/77dfda0b-c952-4832-8a07-b7c0fb2a0d5f)
This program simulates a route-finding with multiple algorithm provided, 
given a file of adjacency matrix and csv contain cityName,Latitude and Longitude.
1. Brute-Force (Recursive) Method
2. Breadth-First Search
3. Depth-First Search
4. Iterative Deepening Search (ID-DFS)
5. Best-First Search
6. A* Search

The result of this program :
1. The best route provided on each algorithm
2. Visited city(node) to find the route
3. Execution time of the program (ms)
4. Total distance (node to node) for the search program
5. The memory that being used on each method (array scale Sum)

This repository contains the source code of this program and also the exe file build on the release folder.

> Technical
-----------
This programs created with C# Language on Visual Studio 2022.
Some of the NuGet package that being used :
1. CsvHelper (to parse the csv file provided)
2. Costura.Fody (to include the dependencies when build the solution)
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/298e8668-fe9b-4e26-85f1-142bb98b9bbe)

> References
-------------
I also use an LLM (Chat-GPT 3.5) to build this program
Some of the prompt that i provided :

1." Hi could you give me a program to create a node dictionary in c# given a list of pair cities adjacencies in txt file and another filein csv (without header) that contain  city name, longitude & latitude in order to find a route from one city to another using (insert the name of algorithm here)? "
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/c0dec98f-b311-4969-b07a-203b0345eaa9)
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/a68cf88e-01ff-4f18-b149-06780a836380)
This will give you the complete logic of the algorithm (class,method even the package that were needed), 
And after that you have to connect and tweak the code first, so it'll run in accord to your purpose and expectation.

2. "could you give me a program in c# visual studio windows forms, that has 3 different parameters in a combobox, a button to run the process, a progress bar and the box to print the output of the process?"
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/1eab4d17-8aec-4220-ab20-a7de2602acc0)
I am using this prompt to help me create a structure for a windows forms application in visual studio.

3. "(Insert the code part that has error here) + the problem that occured in the debugger"
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/00f388e8-bb9b-4017-bc12-5f47463d1e9b)
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/a74f49cf-7018-4f45-afc7-8394d4b385b1)
This will give you some of the suggestion for the error that you provided, but keep that in mind most of the time you have to take it with a grain of salt. because we cannot provied an entire solution of the code so most of the time chat-gpt cannot suggest the exact solution of the problems, but it surely help to get an idea where the problem is.

4. "(insert code here) + could you give an explanation and comment for this code?"
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/fe122293-f573-426d-a857-abab54ba3546)
![image](https://github.com/Baguser7/CS-461-Search-Method-Program/assets/125522708/093afcf1-0f9a-4941-9559-d39d65bb96b7)
And lastly, i using the LLM to help me comment the code. and it really help to get the logic of the program.

> Other references
- learn.microsoft.com
- C# Your First Windows Forms Application (https://www.youtube.com/watch?v=n5WneLo6vOY)
- Coding Gem #1.3: Parsing CSV Data as Lists in C# (https://www.youtube.com/watch?v=Oe8M0t4PJR0)

