Useig .net project MVC C# & SQL server to do the followings:
 
1. Create a web service for all the DB callings (reading & writing)
1.1. For all DB queries use (stored procedures) to call them

2. In your VS project call this service to pass or get any details from DB

3. Create the below pages:
3.1. First Page (login page): 
3.1.1. Show two textboxes for username and password
3.1.2. Add button to validate the username and password, the validation will be as per the following:
3.1.2.1. From front end validate that both username and password are written
3.1.2.2. if they are both in filled, then check if they are matching an entry in DB
Please notice the followings:
* usernames + passwords should be pre-added in the database and your application will only verify them
* the passwords should be saved encrypted
3.2. Second page
3.2.1. After login page, the application should direct you to this page
3.2.2. Call this API (weather API) : https://www.openweathermap.org/
3.2.3. give an option to select a city, and once we select the city the below details should show on screen:
* Humidity
* temperature (min)
* temperature (max)
3.2.4. add a button to save the result and it will be saved with today’s date and the logged in user in DB
3.3. Third page
3.3.2. This page will show all saved results of weather search in a table with filter option
3.3.3. The source of that table should (cashing)
3.3.4. Add an option to update the details of the table and once all the update is done add a button to update the changes in DB,
Note: the updates in the table will not impact the DB till we click on Save button
3.3.5. Save each change for each record in DB with the user who did it, the date & time and name of the change happened
 
4. For styling use CSS + Bootstrap
5. For the DB please consider the followings:
5.1. Use stored Procedures for all needed quires
5.2. Add table constraints and forging keys if needed

