using UnityEngine;

namespace _Scripts.Timber_Man.Controllers.Ui
{
   public class UIController : MonoBehaviour
   {
      private void Start()
      {
         gameObject.SetActive(false);
      }

      public void ShowLostUIController()
      {
         gameObject.SetActive(true);
      }
   }
}
