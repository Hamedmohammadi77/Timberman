using System;
using UnityEngine;

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
