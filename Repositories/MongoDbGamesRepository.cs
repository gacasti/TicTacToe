using System;
using System.Collections.Generic;
using TicTacToe.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace TicTacToe.Repositories
{
    public class MongoDbGamesRepository : IGamesRepository
    {
        private const string dbName = "tictactoe";
        private const string gamesCollectionName = "games";
        // private const string playerMovesCollectionName = "playerMoves";
        private readonly IMongoCollection<Game> gamesCollection;
        // private readonly IMongoCollection<PlayerMove> playerMovesCollection;

        // Filter Definition Builder to query a single game
        private readonly FilterDefinitionBuilder<Game> filterBuilder = Builders<Game>.Filter;
        public MongoDbGamesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(dbName);
            gamesCollection = database.GetCollection<Game>(gamesCollectionName);
            // playerMovesCollection = database.GetCollection<PlayerMove>(playerMovesCollectionName);
        }

        /* Command to run docker to post mongo db package

        -d detachable process
        -rm  the container is destroyed after closing the process
        -- name name of process
        -p port number (MongoDb uses 27017)
        -v the data is persisted

        docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo

        --> To stop MongoDB volume in docker run: docker stop mongo
        --> To list MongoDB volumes in Docker run: docker volume ls
        --> To remove a MongoDB volume run: docker volume rm mongodbdata in the terminal

        To create a new MongoDB volume with authentication run something like the following:
        docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
        
        To enable user secret passwords run: dotnet user-secrets init
        To set a secret run: dotnet user-secrets set MongoDbSettings:Password Pass#word1
        
        */

        public async Task CreateGameAsync(Game game)
        {
            await gamesCollection.InsertOneAsync(game);
        }

        public async Task DeleteGameAsync(Guid id)
        {
            var filter = filterBuilder.Eq(game => game.Id, id);
            await gamesCollection.DeleteOneAsync(filter);
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            var filter = filterBuilder.Eq(game => game.Id, id);
            return await gamesCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await gamesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            var filter = filterBuilder.Eq(savedGame => savedGame.Id, game.Id);
            await gamesCollection.ReplaceOneAsync(filter, game);
        }
    }

}