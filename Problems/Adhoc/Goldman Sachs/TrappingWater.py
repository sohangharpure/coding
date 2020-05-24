#Trapping Rain Water
#Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

# Input: arr[]   = {2, 0, 2}
# Output: 2
# Structure is like below
# | |
# |_|
# We can trap 2 units of water in the middle gap.

# Input: arr[]   = {3, 0, 0, 2, 0, 4}
# Output: 10
# Structure is like below
#      |
# |    |
# |  | |
# |__|_| 
# We can trap "3*2 units" of water between 3 an 2,
# "1 unit" on top of bar 2 and "3 units" between 2 
# and 4.  See below diagram also.

# Input: arr[] = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]
# Output: 6
#        | 
#    |   || |
# _|_|_||||||
# Trap "1 unit" between first 1 and 2, "4 units" between
# first 2 and 3 and "1 unit" between second last 1 and last 2


#Naive approach using 2 loops
def maxWater_naive(arr):
    result = 0
    arr_len = len(arr)
    
    #For each element in the array
    for i in range(1, arr_len-1):
        
        #First, find maximum element on it's left
        left = arr[i]
        for j in range(i):
            left = max(left, arr[j])
        
        #Then find the maximum element on it's right
        right = arr[i]
        for j in range(i+1, arr_len):
            right = max(right, arr[j])
        
        #Water to be stored at that location = min(left, right) - the element at that index
        result = result + (min(left, right) - arr[i])
        
    return result

arr = [3, 0, 0, 2, 0, 4]
print(maxWater_naive(arr)) #10
arr = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];  
print(maxWater_naive(arr)) #6

#Efficient solution
def maxWater_efficient(arr):
    
    n = len(arr)
    
    #left[i] will contain the height of the tallest bar to the left of the i'th bar,
    #including itself
    left = [0] * n
    
    #right[i] will contain the height of the tallest bar to the right of the i'th bar,
    #including itself
    right = [0] * n
    
    result = 0
    
    #Fill the left array
    left[0] = arr[0]
    for i in range(1, n):
        left[i] = max(left[i-1], arr[i])
    
    #Fill the right array
    right[n-1] = arr[n-1]
    for i in range(n-2, -1, -1):
        right[i] = max(right[i+1], arr[i])
        
    # Calculate the accumulated water element by element 
    # consider the amount of water on i'th bar, the 
    # amount of water accumulated on this particular 
    # bar will be equal to min(left[i], right[i]) - arr[i]
    
    for i in range(0, n):
        result = result + min(left[i], right[i]) - arr[i]
        
    return result

arr = [3, 0, 0, 2, 0, 4]
print(maxWater_efficient(arr)) #10
arr = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];  
print(maxWater_efficient(arr)) #6