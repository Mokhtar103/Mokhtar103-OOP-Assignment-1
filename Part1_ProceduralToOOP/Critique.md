## The application relies on global data

- Global variables can be accessed, modified, and overwritten by any function anywhere in the entire program

- If a bug occurs, it is hard to trace tracing which function modified the variable 

- There is no data protection, and tracing the code becomes more difficult as the code grows

## The code is hard to maintain

- Everything is written in a single procedural style with functions

- If you want to change a business rule, you may have to modify multiple unrelated functions,
  increasing the risk of making new bugs

## The procedural structure is hard to read

- Logic is mixed with array operations, manual checking, mixed input/output operations

- Developers spend alot of time trying to comprehend what simple operations are doing

- Logical errors are hard to find

## There is no exception management

- The program relies on returning -1, print errors directly instead of making a structured
  error handling

- Calling functions can ignore or misinterpert errors

- We can't catch the error or prevent unsafe program execution

## Tight coupling

- Business logic, arrays, and console user interfaces (cin/cout) are completely mixed together into the same functions

- It goes against reusability and unit testing (hard to write automated unit tests)

