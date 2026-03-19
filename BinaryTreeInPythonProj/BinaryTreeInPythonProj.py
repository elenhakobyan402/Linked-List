from calendar import c


class Node:
    def __ini__(self,value):
        self.value = value
        self.right = None
        self.left = None

 
class BinaryTree:
    def __init__(self):
        self.root = None

    def add (self, value):
        new_node = Node(value)

        if self.root is None:
            self.root = new_node

        current = self.root 

        while True:
            if value < current.value:
                if current.left == None:
                    current.left == new_node
                    return current.left

            else:
                if current.right == None:
                    current.right == new_node 
                    return current.right

    def contains(self, value):
        current = self.root

        while current:
            if value == current.value:
                return True
            elif value < current.value:
                return current.left
            else:
                return current.right
        return False


