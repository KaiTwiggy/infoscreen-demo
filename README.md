# Infoscreen / Management panel app
This app consists of 3 parts :
    1. Backend
    2. Info"screen"
    3. Management panel for the infoscreen

More on these below.

## Backend
Basically Backend handles all required interactions with both the management frontend and the "screen" part
As this is .Net core project, can be run on osx / linux. Just install .net Core runtime and run following commands in the 
/Infoscreen.Web/Infoscreen.Web/ folder.
dotnet restore
dotnet run

The backend will start @ port 50478, and the front dev configs should point to this location.

### Endpoints
Backend is Asp.Net Core app that is in docker container. It has the following endpoints:
* [GET] api/Websocket => Screens use this to connect via websocket
* [GET] api/Slide => Gets all the active, not deleted slides (used in management "list view")
* [GET] api/Slide/{Id} => Gets data of 1 slide that is not deleted (not in use atm)
* [GET] api/Slide/toggleActivation/{Id} => Toggles slides active state (state = !currentState)
* [POST] api/Slide => Add new slide to "slidedeck"
* [DELETE] api/Slide/{Id} => Mark slide deleted (soft delete)

### TODO
* Some better persistence storage than file
* Logging
* Endpoints and stuff for the devices tab
* Some sort of user management (or handling) for screens & admin users

## Info"screen"
Displays the slides (autoscroll slides) that are gotten via websockets from the backend.

### TODO
* "Registration screen" : On first start, ask atleast screen "name", send it to backend and probably reserve some uuid or something. Store the uuid to localstorage for future screen identification.
* More slide types
* Logging
* Better error handling
* websocket reconnect logic / retry connection

### Build
Dev : npm run dev => starts it @ localhost:8080
  => ensure that the backend port/address is correct @ /config/dev.env.js
"Prod" : npm run build => builds the frontend under the wwwroot/screen/ of the "backend" project

## Management panel
Management panel manages the slides, so you can add and delete and disable slides. There is no autopush, so user needs to "send" the slides to all the screen via "Update devices" button.

### TODO
* "Devices" list / view. This view should present list of the screens and which one is connected and which one is not
* More slidetypes
* Prolly ws connection to backend (so that the "devices" list is synced)
* Better listing for slides (better "data", icons and stuff)
* Logging

### Build
Dev : npm run dev => starts it @ localhost:8888
  => ensure that the backend port/address is correct @ /config/dev.env.js
"Prod" : npm run build => builds the frontend under the wwwroot/admin/ of the "backend" project