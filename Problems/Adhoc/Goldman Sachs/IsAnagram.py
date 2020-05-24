from collections import defaultdict

def isAnagram(s1, s2):
    if s1 is None or s2 is None:
        return
    if len(s1) != len(s2):
        return False
    
    s1 = s1.lower()
    s2 = s2.lower()
    
    charCount = {}
    
    for _ in range(0, len(s1)):
        if s1[_] not in charCount:
            charCount[s1[_]] = 1
    
    for _ in range(0, len(s2)):
        if s2[_] in charCount:
            charCount[s2[_]] -= 1
    
    for value in charCount.values():
        if value != 0:
            return False
    
    return True

print(isAnagram('sohan', 'ansOh'))
        
    