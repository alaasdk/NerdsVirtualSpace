# Nerds Virtual Spaces
a sample app that demonstrate pub/sub pattern.

##### Requirments in hand:
* we need to implmement a sample application that make use of the pub/sub pattern.

##### Idea:
* Nerds virtual spaces is created to make spaces for nerds to communicate in.
* there will be several spaces and all the nerds can add messages to any space.
* any nerd can subscribe to any space he wants and get notified when something is published.

##### approch:
* we will make a small hub for these messages "broadcaster", each message is tagged with specific tag.
* anyone can publish a message to the hub with a text and a tag.
* anyone can subscribe to any tag and get notified when anyone publish a messages in it.
* a tag representes "space" in our app.

##### first version:
* allows only string messages.
* 

##### future plan:
* create a queue of messages to handle failed messages
* allows any type of messages