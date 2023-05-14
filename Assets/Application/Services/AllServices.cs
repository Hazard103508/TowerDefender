using TowerDefender.Application.Interfaces;
using TowerDefender.Application.Services;

namespace TowerDefender.Application.Services
{
    public static class AllServices
    {
        public static IGameDataService GameDataService { get; private set; }
        public static ICoinService CoinService { get; private set; }

        public static void Load()
        {
            GameDataService = ServiceLocator.Current.Get<IGameDataService>();
            CoinService = ServiceLocator.Current.Get<ICoinService>();
        }
    }
}