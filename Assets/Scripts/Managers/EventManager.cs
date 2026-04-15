using System;
using Player;

namespace Managers
{
    public class EventManager : Singelton<EventManager>
    {
        public event Action<float,PlayerMain.IDPlayer> OnHealthChanged;
        
        public void PlayerDamage(float healthAmount,PlayerMain.IDPlayer player)
        {
            OnHealthChanged?.Invoke(healthAmount,player);
        }
    }
}
