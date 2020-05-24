class Node:

    def __init__(self, value):
        self.value = value
        self.nextnode  = None
        
def nth_to_last_node(n, head):
    ntolast = head
    current = head
    counter = 1
    knodecount = 1
    while current.nextnode is not None:
        current = current.nextnode
        counter+= 1
        if counter - knodecount == n:
            knodecount+=1
            ntolast = ntolast.nextnode            
    return ntolast

a = Node(1)
b = Node(2)
c = Node(3)
d = Node(4)
e = Node(5)

a.nextnode = b
b.nextnode = c
c.nextnode = d
d.nextnode = e

target_node = nth_to_last_node(3, a)
print(target_node.value)