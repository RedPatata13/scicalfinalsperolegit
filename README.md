# scicalfinalsperolegit

MVC stands for Model, View, Controller. The MVC is a design pattern that is actually the most employed design pattern among software applications (a design pattern is literally juts a pattern for a design, that's literally it. It's like a template for how things flow between objects or classes so devs can have a definite solution to an existing/repeating problem). This is such that, a class only has one sole role instead of having one large function/class where everything is handled within this class alone, this makes it harder to debug as well as to add updates unlike in using a design pattern where one can instanly know which class to edit in order to update it. In a software that employs the MVC design, the 3 classes have roles and are strictly limited to these roles:

View - this is the user interface Controller - this acts strictly as a connector or a flow handler between the View and the Model class. Model - this is where all the data is processed including the database

You can imagine it like a scenario of a customer ordering a dish from a menu, calling a waiter to order, the waiter bringing the order to the chef, the chef looking at the order and cooking the equivalent dish and returning the finished dish to the waiter, and finally the waiter bringing the finished dish to the customer. In this analogy, you can already see which roles are being fulfilled. The user is the customer, the menu/table is the view(user interface), the controller are the waiters and finally the model is the chef.

One thing to note, is that although I mentioned in the example where the customer in the table (user interacting with view) is 'calling' the waiter(controller), it's lot more accurate to say that the View class does not directly connect to the Controller class in an actual MVC development. It's more accurate to say that the developer need to create a 'getter' method in the view class to retrieve the desired data upon the trigger of an event such as a Click. It's inaccurate to say that the View has a direct access to the controller class and it's more important to see it as the controller directly accessing the view class. The same applies to the model class however in this class's case, what the controller interacts with are methods that directly return the processed values to be returned to the View class such a number, a string, an array or even a matrix and it doesn't even have getter functions in most cases because it quite literally always return the processed version of what the view object requests. Larger applications can even return an HTML file directly. To put it simply, Controller --> View/Model BUT View/Model -X-> Controller.

So how exactly does the user input go through the view class to the controller? In my calculator, if you were to look at Program.cs and the Controller class structure, the controller class takes in an instance of each of the two classes(view and model) in it's constructor but the view and model does not have this so this already implies what I said earlier. What's commonly done is to declare a new Eventhandler in the view class but leave it as undefined and then defining it within the controller class. In my calculator, I had an undefined eventHandler as parameter in the View class and then linked the '=' button's Click to it. But then as we know this eventHandler is undefined and as such can't really do anything until we go to the controller class that actually has access to the same isntance of the view class and define what it does there. That means that if we have a method that can return an important string within the view class, we can call that view method within the controller class upon triggering the event.

IMPORTANT:
-Controllers do not have their own databases, they are just like a connector or a data flow manager
-the View and the Model class should not directly access each other

For example in my calculator, I had a method to return the string in the inputField and called this in the defined eventHandler within the controller class, upon clicking the '=' button, this triggers the event within the controller class, retrieving the text inside the inputField and saving it in another string variable and using the variable to call a method in the Model class that directly returns the evaluated expression. I can then again use this returned value to update the text inside the outputField through the controller class calling a function within the view class to update the value of the ouputField.

actualy di pa ko kumakain nung sinusulat ko to pero simple lng nmn sya so kaya mo na yan. tinatamad na kong gumawa ng conclusion kase gutom n ko :\
