using Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] public Image healthBarPlayer1;
        [SerializeField] public Image healthBarPlayer2;

        private void OnEnable()
        {
            EventManager.Instance.OnHealthChanged += UpdateHealth;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnHealthChanged -= UpdateHealth;
        }

        private void UpdateHealth(float healthAmount,PlayerMain.IDPlayer player)
        {
            switch (player)
            {
                case PlayerMain.IDPlayer.Player1: 
                    healthBarPlayer1.fillAmount = healthAmount;
                    break;
                case PlayerMain.IDPlayer.Player2:
                    healthBarPlayer2.fillAmount = healthAmount;
                    break;
            }
        }
    }
}
