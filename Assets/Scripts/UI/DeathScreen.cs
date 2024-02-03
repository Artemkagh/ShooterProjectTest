using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button quitBtn;

        public Button RestartBtn => restartBtn;

        public Button QuitBtn => quitBtn;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void SetDead(bool state)
        {
            SetDeadActive(state);
        }
        private void SetDeadActive(bool isDead)
        {
            if (isDead)
            {
                ShowDeadScreen();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                CloseDeadScreen();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void ShowDeadScreen()
        {
            gameObject.SetActive(true);
        }

        private void CloseDeadScreen()
        {
            gameObject.SetActive(false);
        }
    }
}