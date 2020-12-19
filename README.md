# Master Save
A Xamarin project designed to assist anyone to save money on monthly or daily expenses. The app utilizes Azure's Opitcal Character Recgonition (OCR) REST API to scan bills and convert them them to JSON texts which are then stored into a CosmosDB instance of MOngoDB

# How it was used
The app was downloaded to a phone, it displayed 3 icons : a camera, the settings button and the calendar button.

## Camera
When the camera button was selected, it allowed the user to capture cpictures. However, it was coded so that only bills would be recognized by the backend of the app with all other non-relevant information being discarded. The bill along with the day and time it was captured are then transferred to the MongoDatabase.

## Settings
The settings buttons allows the user to select the specific time he/she wishes to see certain bills taken during that period of time. Once a certain time period is set, all other days and months are exlcuded from the calendar's display but can be reset by heading back to the settings.

## Calendar
The calendar displays each and every bill taken throughout the course of either a single day or an entire month. It added up the values of the bills and calculated the total amount of savings that could be achieved during a given month. 

# Dependencies
The telerik UI was only usable for a trial period of 30 days, that time period was just enough for the project to be demonstrated to the professor. Additionally certain keys and endpoints were used from CosmosDB's databases to Computer Vision's API. Any user who wishes to test these functionalities will require an azure account with the above two components as well as an access to telerik's xamarin.native calendar. These three are the primary elements required to make the app functional 
