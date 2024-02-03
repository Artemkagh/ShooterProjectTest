using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button quitBtn;
        
        public Button PlayBtn => playBtn;

        public Button QuitBtn => quitBtn;
    }
}