using UnityEngine;

namespace GameCore.Input.Data
{    
    [CreateAssetMenu(fileName = "NonGameplayInputData", menuName = "PlayerInputData/NonGameplayInputData", order = 1)]
    public class NonGameplayInputData : ScriptableObject
    {
        #region Data
        private bool _pauseClicked;
        #endregion

        #region Properties

        public bool PauseClicked
        {
            get => _pauseClicked;
            set => _pauseClicked = value;
        }

        #endregion

        #region Custom Methods
            public void ResetInput()
            { 
                _pauseClicked = false;
            }
        #endregion
    }
}