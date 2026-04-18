using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManagerUI : Singelton<SceneManagerUI>
    {
        public void ChangeScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
