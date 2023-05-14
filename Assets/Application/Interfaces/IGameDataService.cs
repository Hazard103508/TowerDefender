namespace TowerDefender.Application.Interfaces
{
    public interface IGameDataService : IGameService
    {
        int Coins { get; set; }
    }
}