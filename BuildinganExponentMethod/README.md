# Building An ExponentMethod

## Pseudocode

```bash
  Algorithm Main
    Print "Base Number in the Power Number"
    Print GetPow(3, 4)
End Algorithm

Algorithm GetPow(baseNum, powNum)
    Precondition:
        baseNum is an integer
        powNum is a non-negative integer
    Postcondition:
        Returns baseNum raised to the power of powNum

    result <- 1
    For i <- 0 to powNum - 1
        result <- result * baseNum
    End For
    Return result
End Algorithm

```

### Precondition
- baseNum is an integer.
- powNum is a non-negative integer.

### Postcondition
- The function returns baseNum raised to the power of powNum.


According to Big O notation

### Best Case Runtime
The best case occurs when powNum is 0. In this case, the loop doesn’t execute at all, and the function immediately returns 1. The runtime for this scenario is O(1), which means it runs in constant time.

### Worst Case Runtime
The worst case occurs when powNum is a large number. In this case, the loop executes powNum times. The runtime for this scenario is O(powNum), which means it runs in linear time relative to the value of powNum. 

#### Summary
Best Case: O(1) when powNum is 0.
Worst Case: O(powerNumber) when powerNumber is a large number.

