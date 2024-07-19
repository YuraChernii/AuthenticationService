# AuthenticationService

How to launch:
1. Download and run Microsoft SQL Server (MsSQL) using Docker Desktop, or run it locally if you have already set it up.
2. Configure the connection string in the appsettings file.
3. Open the "Package Manager Console," select the "Infrastructure" project, and run the update-database command. This will create the Users table and populate it with 20 test users (usernames: user1, user2, user3, etc.; password: "password" for each user).
4. Run the project.
5. Swagger will open, allowing you to log in or run https://github.com/YuraChernii/AuthenticationUI
