using System;
using Player;

namespace Managers
{
    public class EventManager : Singelton<EventManager>
    {
        public event Action<float,PlayerMain.IDPlayer> OnHealthChanged;
        public event Action OnPlayerDeath;
        public event Action OnPlayerWin;
        public event Action OnlevelStart;
        
        public void PlayerDamage(float healthAmount,PlayerMain.IDPlayer player)
        {
            OnHealthChanged?.Invoke(healthAmount,player);
        }

        public void PlayerDead()
        {
            OnPlayerDeath?.Invoke();
        }

        public void Win()
        {
            OnPlayerWin?.Invoke();
        }
        public void StartLevel()
        {
            OnlevelStart?.Invoke();
        }
    }
}
