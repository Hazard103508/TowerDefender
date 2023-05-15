using TowerDefender.Application.Interfaces;

namespace TowerDefender.Application.Services
{
    public static class AllServices
    {
        public static ICoinService CoinService { get; private set; }
        public static IMatchService MatchService { get; private set; }

        public static void Load()
        {
            CoinService = ServiceLocator.Current.Get<ICoinService>();
            MatchService = ServiceLocator.Current.Get<IMatchService>();
        }
    }
}