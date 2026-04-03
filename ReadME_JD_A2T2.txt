Hello here's is a document of my attempt for the Assessment 2 task 2

I've pretty much put my comments highlighting of each method I used
In this I attempt to recreate the code that Bishup done in the way I understood
I used their code as a template and try to expand it as well by
Also generating pre-existing and future existing users with their details.

instead of going straight to Sign up, I created a Main menu like it would
do a real life ATM asking for a prompt for options to be used this is where I used
the Switch method. In the MainScreen class it would never be closed until KeepRunning is set
to False.

In my attempt I also made a public class for the users where all the Users that have sign up
will be stored. and as you can see at the top I have generated Joe.Doe as an example.
but using the List class method we can store as much as User details as we want
there is also with the Array method if we want to limit our Users but at this case I opted for
List as this can easily be expand to as much as we want.
But there is an underlying problem here the data that are stored are temporary so As soon
as we closed the program it will be erased we can expand our list at the start by adding
more users.


Although currently in V1.0 it is not a very clean code unlike Bishup's I am still trying
to make the code more readable. In the next update


here are the references mostly used from W3Schools
https://www.w3schools.com/cs/cs_switch.php
https://www.w3schools.com/cs/cs_type_casting.php