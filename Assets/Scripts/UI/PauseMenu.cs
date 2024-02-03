using GameCore.Pause;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;


namespace UI
{
    public class PauseMenu : MonoBehaviour, IPauseable
    {
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button quitBtn;
        
        private bool _isPaused;

        public Button ContinueBtn => continueBtn;

        public Button QuitBtn => quitBtn;

        private void Start()
        {
            gameObject.SetActive(false);
            _isPaused = false;
        }

        public void SetPaused(bool state)
        {
            _isPaused = state;
            SetPauseActive(_isPaused);
        }
        private void SetPauseActive(bool isPaused)
        {
            if (isPaused)
            {
                ShowPauseMenu();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                ClosePauseMenu();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void ShowPauseMenu()
        {
            gameObject.SetActive(true);
        }

        private void ClosePauseMenu()
        {
            gameObject.SetActive(false);
        }


    }
}