using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{

    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "The Witcher 3: Wild Hunt",
                Genre = "RPG",
                Price = 30.99M,
                ReleaseDate = new DateTime(2015, 5, 19),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Grand Theft Auto V",
                Genre = "Action",
                Price = 20.99M,
                ReleaseDate = new DateTime(2013, 9, 17),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "The Legend of Zelda: Breath of the Wild",
                Genre = "Adventure",
                Price = 40.99M,
                ReleaseDate = new DateTime(2017, 3, 3),
                ImageUri = "https://placehold.co/100"
            },
        };
        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? Get(int id)
        {
            return games.Find(g => g.Id == id);
        }

        public void Create(Game game)
        {
            game.Id = games.Max(g => g.Id) + 1;
            games.Add(game);
        }

        public void Update(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
        }

        public void Delete(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }
    }
}
