class BinaryTree(object):
     
    def __init__(self, rootObj):
        self.key = rootObj
        self.leftChild = None
        self.rightChild = None
    
    def insertLeft(self, newNode):
        if self.leftChild == None:
            self.leftChild = BinaryTree(newNode)
        else:
            newtree = BinaryTree(newNode)
            newtree.leftChild = self.leftChild
            self.leftChild = newtree
        pass
    
    def insertRight(self, newNode):
        if self.rightChild == None:
            self.rightChild = BinaryTree(newNode)
        else:
            newtree = BinaryTree(newNode)
            newtree.rightChild = self.rightChild
            self.rightChild = newtree            
    
    def getRightChild(self):
        return self.rightChild
    
    def getLeftChild(self):
        return self.leftChild
    
    def setRootVal(self, obj):
        self.key = obj
        
    def getRootVal(self):
        return self.key
    
def preorder(root):
    print(root.getRootVal())
    if root.leftChild:
        preorder(root.getLeftChild())
    if root.rightChild:
        preorder(root.getRightChild())
        
def inorder(root):   
    if root.leftChild:
        inorder(root.getLeftChild())
    print(root.getRootVal())
    if root.rightChild:
        inorder(root.getRightChild())
        
def postorder(root):    
    if root.leftChild:
        postorder(root.getLeftChild())
    if root.rightChild:
        postorder(root.getRightChild())
    print(root.getRootVal())

r = BinaryTree(3)
r.insertLeft(1)
r.insertRight(5)
r.insertLeft(2)
r.insertRight(4)
print('Preorder: {}'.format(preorder(r)))
print('Inorder: {}'.format(inorder(r)))
print('Postorder: {}'.format(postorder(r)))
