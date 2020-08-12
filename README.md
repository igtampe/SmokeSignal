# SmokeSignal
SmokeSignal is a rework of ViBE's Server Framework, to be more flexible and re-usable in other applications. You're more than welcome to use it in your projects.

![SmokeSignal Default Server Images](https://raw.githubusercontent.com/igtampe/SmokeSignal/master/Images/SmokeSignal.png)

SmokeSignal started at V6 because it was based on ViBE Server V5. We're currently at V7, which added the SmokeSignal Authenticator program

## How to use it
First, make sure to configure your SmokeSignal Server, with the name of your server application and the colors to use on the header. Also, consider changing the default port the server listens on. Even if this is configurable using the generated config file, it's nice to set this so that other users in the future don't need to.

Then, create the SmokeSignal Extensions you'll need.

SmokeSignal operates with what I call "SmokeSignal Extensions". There's a dummy extension that's included in this project, as well as an interface that should help guide users in the process of creating their own. SmokeSignal receives strings from a client, and passes it on to the registered extensions in an attempt to Parse it (Using the Parse() function). If your extension can't parse it, return an empty string, and SmokeSignal will attempt to parse it with the next one

In addition, every 100ms, SmokeSignal will ask each registered extension to Tick by calling their Tick() method, allowing you to do things while the server is still waiting for a connection.

Once you're done creating your SmokeSignal Extension, remember to register it in the main vb class!

And after that, you're done! You've made your own SmokeSignal based Server Application.

Now to start with a client, check my other repos.<br>
I have a template for a VB.NET Windows Form application here: https://github.com/igtampe/SmokeSignalClient <br>
A C# Command line application here: https://github.com/igtampe/SmokeSignal-CommandLine/ <br>
And I have a small template for a Java app (though without a gui) here: https://github.com/igtampe/Hermes<br>
