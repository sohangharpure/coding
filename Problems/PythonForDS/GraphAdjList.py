class Vertex:
    def __init__(self, key):
        self.id = key
        # Dictionary of vertices this vertex is connected to
        # key = vertex, value = weight
        self.connectedTo = {}
        
    def addNeighbor(self, nbr, weight = 0):
        self.connectedTo[nbr] = weight
        
    def __str__(self):
        return str(self.id) + ' connected to ' + str([x.id for x in self.connectedTo])
    
    def getConnections(self):
        return self.connectedTo.keys()
    
    def getId(self):
        return self.id
    
    def getWeight(self, nbr):
        return self.connectedTo[nbr]
    
class Graph:
    def __init__(self,):
        self.vertList = {}
        self.numVertices = 0
        
    def addVertex(self, key):
        if key not in self.vertList:
            newVertex = Vertex(key)
            self.vertList[key] = newVertex
            self.numVertices += 1
            return newVertex
        
    def getVertex(self, n):
        if n in self.vertList:
            return self.vertList[n]
        else:
            return None
        
    def __contains__(self, n):
        return n in self.vertList
    
    def addEdge(self, f, t, cost = 0):
        if f not in self.vertList:
            nv = self.addVertex(f)
        if t not in self.vertList:
            nv = self.addVertex(t)
        self.vertList[f].addNeighbor(self.vertList[t], cost)
        
    def getVertices(self):
        return self.vertList.keys
    
    def __iter__(self):
        return iter(self.vertList.values())
    
g = Graph()
for i in range(1, 6):
    g.addVertex(i)
    
g.addEdge(1,2,3)
g.addEdge(1,1,1)

for vertex in g:
    print(vertex)
    print(vertex.getConnections())
    print('\n')
        
    