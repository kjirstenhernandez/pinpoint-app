# Overview

This app is the UI for PinPoint, an event service that allows users to find events local to them, as well as create their own.  It utilizes the backend API I developed previously; that repository can be found at https://github.com/kjirstenhernandez/pinpoint-api.  To use this app, upon loading on an Android phone, a user can click the app and tap the "Get Events" button at the bottom.  A list of all the events will load, and a detailed view can be seen by tapping on the desired event. 

Creating this app has helped me to extend my .NET knowledge and incorporate a major part of technology in our societies -- mobile apps!  By developing it I'm learning important components such as creating commands and incorporating GIS mapping.  

[Software Demo Video](https://teams.microsoft.com/l/message/48:notes/1743617812979?context=%7B%22contextType%22%3A%22chat%22%7D)

# Development Environment

Visual Studio Community 2022 was used to develop this app.  The programming language used was C# and the Xamarin framework.  The app was tested on an Android phone emulator, available through Visual Studio Code.

Libraries used: 
- CommunityToolkit.Mvvm
- Microsoft.Extensions.Logging.Debug
- Microsoft.Maui.Controls
- Microsoft.Maui.Essentials
- Microsoft.NET.ILLink.Tasks

# Useful Websites

{Make a list of websites that you found helpful in this project}
* [Developer Thoughts - Alternatives to AppShell](https://egvijayanand.in/2024/10/30/transitioning-from-application-mainpage-to-window-page-in-dotnet-maui-9/#:~:text=NET%20MAUI%209%2C%20specifically%20the,set%20during%20the%20Window's%20instantiation.&text=After:,derived%20from%20the%20Window%20type.&text=//%20The%20window%20type%20can%20also%20be%20used%20directly.&text=Further%20Reading:,MainPage%20deprecation)
* [Dotnet Youtube - Adding Interactive Gestures to Controls in .NET MAUI](https://www.youtube.com/watch?v=kVvIxdyBzH8)
* [Dotnet Youtube - .NET MAUI for Beginners (Series)](https://youtu.be/Hh279ES_FNQ?si=HeQFViS3zBlxHVwo)
* [Microsoft .NET Maui Documentation on Relative bindings](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/relative-bindings?view=net-maui-9.0&utm_source=chatgpt.com)]
* [Frame to Border Migration help for .NET 9](https://egvijayanand.in/2024/11/02/transitioning-from-frame-to-border-in-dotnet-maui/)
* [https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings] Using the user's culture settings to establish the preferred date format 

# Future Work
* Add GIS Mapping
* Fix the API call (adding other capabilities such as add, edit, and delete events)
* Integrate OAuth for user authentication
* Add a feature to allow users to create their own events
* Add a feature to allow users to RSVP to events
* Add a profile feature so that users can see their events and RSVPs