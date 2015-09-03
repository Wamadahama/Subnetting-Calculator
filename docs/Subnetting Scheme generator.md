<strong>Story: </strong>Subnetting scheme generator

This will be used to determine a collection of information that is used in subnetting. 


This will take the following information: 
- Address class 
- Number of subnets needed 
- Number of hosts needed per subnet

With this information it will determine the following, this is recomended configurations: 
- Subnet mask 
- A list of information
	- FOREACH subnet display  
	- The first usable host address
	- The last usable host address
	- Broadcast address

<h5>Story points</h5>
<ul>
	<li>Build a class that works with computing this information</li>
	<li>Build the interface with the ability to display the address information for each subnet</li>
<ul>

Future features - VLSM