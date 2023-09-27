# Algorithms-and-Design-Assignments. 4th year, Computer Science, Ain Shams University.

Document Distance:
Given: two documents D1 & D2
Req.: Calculate distance between them d(D1, D2)? 
		     CASE INSENSITIVE
Apps:
Search for similar documents
Detecting duplicates (e.g. Wikipedia mirrors)
Plagiarism detection
Definitions:
Word = sequence of alpha-numeric characters ONLY
Document = sequence of words (ignore space, punctuation, …etc.) 
Treat all upper-case letters as if they are lower-case, so “Cat" & “cat" are same
Word end at a non-alphanumeric char, so "can't" contains 2 words: "can" & "t"

Text Plagiarism:
Description
Given a paragraph and a complete text, it’s required to calculate the plagiarism similarity of the given paragraph vs the given text. The Plagiarism similarity is defined as the max common subsequence of words between the given paragraph and EACH paragraph in the given text. Comparison is case IN-SENSITIVE (i.e. Cat = CAT = cat = CaT)

Graph Analysis:
Analyze the edges of the given DIRECTED graph by applying DFS starting from the given "startVertex" and count the occurrence of each type of edges (backward, forward & cross)
NOTE: during search, break ties (if any) by selecting the vertices in ASCENDING alpha-numeric order

Integer Multiplication
Given TWO LARGE positive integers of N digits/each. Each integer is stored in 1D array. Implement an efficient algorithm based on Karatsuba’s method to multiply them?
NOTES:
•	N is power of 2 (i.e. 2, 4, 8, 16, 32… 2i)
•	Result MUST be stored in 2×N digits (left padded by 0’s if necessary)
•	Least significant digit is stored at index 0 while most significant is stored at index N-1
Complexity
The complexity of your algorithm should be less than O(N2)

Find Index of Extra Element:
Given two sorted arrays. There is only 1 difference between the arrays. First array has one element extra added in between.
Design an efficient algorithm to find the index of the extra element.


