class Node:
    def __init__(self,data):
        self.next = None
        self.data = data

#1->2->4->3
root = Node(1)
root.next = Node(2)
root.next.next = Node(4)
root.next.next.next = Node(3)
        
def printList(node):
    while node:
        print(str(node.data))
        node = node.next
        
def printListRecursive(node):
    if node is None:
        return
    print(str(node.data))
    printListRecursive(node.next)
    
def printListReverseRecursive(node):
    if node is None:
        return
    printListReverseRecursive(node.next)
    print(str(node.data))
    
def countNodesRecursive(node):
    return countNodesRecursive(node.next) + 1 if node else 0

def sumNodesRecursive(node):
    return sumNodesRecursive(node.next) + node.data if node else 0

def maxElement(node):
    max = -9999999999
    while node:
        if node.data > max:
            max = node.data
        node = node.next
    return max

def searchRecursive(node, key):
    if node is None:
        return None
    return node if key == node.data else searchRecursive(node.next, key)

def insert(pos, data):
    global root
    t = Node(data)
    if pos == 0:        
        t.next = root
        node = t
    elif pos > 0:
        p = node
        for i in range(0, pos-1):
            p = p.next
        if p:
            t.next = p.next
            p.next = t
    printList(node)
    
def delete(index):
    global root
    if index < 1:
        return -1
    
    if index == 1:
        q = root
        root = root.next
        del q
        return True
    else:
        p = root
        q = None
        for i in range(0, index-1):
            q = p
            p = p.next
        q.next = p.next
        del p
        return True    
    
def reverse_iter():
    global root
    p,q,r = root, None, None
    while p is not None:
        r = q
        q = p
        p = p.next
        q.next = r
    root = q
    
def reverse_recursive(p,q):
    global root
    if p is not None:
        reverse_recursive(q, p.next)    
        p.next = q        
    else:
        root = q

def find_middle():
    global root
    p,q = root, root
    while q is not None:
        q = q.next
        if q:
            q = q.next
        if q:
            p = p.next
    return p.data

# printList(root)
# printListRecursive(root)
# printListReverseRecursive(root)
# print(countNodesRecursive(root))
# print(sumNodesRecursive(root))
# print(maxElement(root))
# print(searchRecursive(root, 3).data)
# insert(0, 7)
# delete(1)
# printList(root)
# reverse_iter()
# printList(root)
# reverse_recursive(root, None)
# printList(root)
print(find_middle())

        