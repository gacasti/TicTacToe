# TicTacToe

NET 5.0 Web API that provides endpoints for managing games of Tic-Tac-Toe. 

These endpoints are to take the described inputs as JSON strings and return the described output. The API application needs to be runnable using Docker and Docker Compose. Use the most appropriate verbs for the endpoints. Game data should be managed using Entity Framework and a database of your choice (an in-memory database is fine).

Endpoint 1
Add an endpoint for starting a game. This endpoint should return a game Id and Ids for the two players.

Endpoint 2
Add an endpoint for registering a player move. This endpoint should take the player Id and return a success response or appropriate errors. It should also notify the caller if the current move wins the game.

Endpoint 3
Add an endpoint for retrieving a list of currently running games including the number of moves registered for each and the names of the players.

Final Question

Question: What is the appropriate OAuth 2/OIDC grant to use for a web application using a SPA (Single Page Application) and why.

Answer: Client Credentials Grant - This grant is more for machine-to-machine authentication or for clients who exchange requests to an API which do not require user's permission.

Ref.: https://oauth2.thephpleague.com/authorization-server/client-credentials-grant/

************************* To Launch API *******************************
The enviroment uses MongoDB as database (port: 27017) and to test the api it requires Postman, and Docker.

1. Load complete project to VS Code

2. Press F5 to run

3. Open Postman to test the different routes for Get Games, Post Games, Update Games, Delete Games
