""" Given an array of elements, return the length of the longest subarray where all its elements are distinct.
For example, given the array [5, 1, 3, 5, 2, 3, 4, 1], return 5 as the longest subarray of distinct elements is [5, 2, 3, 4, 1]. """

def length_of_longest_subarray(arr):
    if arr is None:
        return 0
    current_longest = set()
    current_length = 0
    for i in range(0,len(arr)):        
        if arr[i] not in current_longest:
            current_longest.add(arr[i])
            current_length += 1
        else:
            #item already exists in the set
            set_length = len(current_longest)
            if set_length > current_length:
                current_length = set_length
                current_longest.clear()
    return current_length
        
print(length_of_longest_subarray([5,1,3,5,2,3,4,1])) #5
print(length_of_longest_subarray([])) #0
print(length_of_longest_subarray([1,2,3,4,5])) #5
print(length_of_longest_subarray([1,2,3,3,2,1])) #3