Here's a simple (and yet to be completed) proof of concept I used at my job refactoring some ETL software to use multithread. The problem emerged when I noticed that diferent orign systems had different table dependencies to manage (implicitly!) and became waaaaay to verbous and high-maintaining to write the full extraction method. So I implemented a generic method that mounted the dependencys for me. It iterates starting on the leafs (the least-dependent methods) and goes up to the more dependent methods, after the dependencies become resolved.

First it creates a dependency tree based on a dictionary of dependencies*¹
Then, iterates from the leafs to the root, starting the multithread and waiting 'till the whole layer is resolved.

```ISystem``` contains the abstract methods to extract for the aimed system
And System1 contains the implementation of those methods

in the real world project I used a factory and a manager to instanciate the called systems.

*¹ Could be directly the branches. I'll improve this later.
