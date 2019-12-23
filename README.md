# ChatJobsity
For interview Jobsity

Hi everybody,

Chat realtime Web Application with SignalR

Description 
 
This project is designed to test your knowledge of back-end web technologies, specifically in           
.NET and assess your ability to create back-​end products with attention to details, standards,and reusability. 

Assignment 
 
The goal of this exercise is to create a simple browser-based chat application using .NET.   
This application should allow several users to talk in a chatroom and also to get stock quotes from an API using a 
specific command. 

Mandatory Features Done

● Allow registered users to log in and talk with other users in a chatroom. 
● Allow users to post messages as commands into the chatroom with the following format  /stock=stock_code 
● Create a ​decoupled bot that will call an API using the stock_code as a parameter (​https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv​, here ​aapl.us is the     stock_code ​ )
● The bot should parse the received CSV file and then it should send a message back into the chatroom using a message broker like RabbitMQ. 
   The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot. 
● Have the chat messages ordered by their timestamps and show only the last 50 messages. 
	Because is a real time chat this functionality cant be done, but i did other functionality with disconnected users to test database connection.
● Unit test the functionality you prefer.

Bonus (Optional) Done
 
● Use .NET identity for users authentication 
● Handle messages that are not understood or any exceptions raised within the bot.
● Build an installer.--> I create a publish Folder with the release versión of the web application.

For installation on visual studio

	Must have localdb installed.

If u want to install the publish release

Need to create the two databases from the Database folder and change the connection string on web.config.

For review of code
	ChatHub.cs
	App_code/StockProvider.cs

If u open two browser one of then must be from another explorer or modo incognito this is because identity asp net use a cookie on brrowser.


The other solution for nUnit test is in another repository , u must download too.

Demo Live on www.sitecweb.com

Have a nice day!
Daniel Gonzalez Cornejo
daniel_gonzalezc@yahoo.com

 







