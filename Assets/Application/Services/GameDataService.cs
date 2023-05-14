using TowerDefender.Application.Interfaces;

namespace TowerDefender.Application.Services
{
    public class GameDataService : IGameDataService
    {
        public int Coins { get; set; }
    }
}