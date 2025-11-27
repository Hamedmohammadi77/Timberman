namespace _Scripts.Timber_Man.Handlers
{
    public class UIHandler
    {
        private UIController _uiController;
        
        public UIHandler(UIController uiController)
        {
            _uiController= uiController;
        }
        
        public void OnPlayerDied()
        {
            _uiController.ShowLostUIController();
        }
    }
}