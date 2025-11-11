using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Timber_Man.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public void MoveLeft()
        {
                MoveRight();
                //log
        }

        public async void MoveRight()
        {
            await ThrowAsync();
            //save
        }

        private async Task ThrowAsync()
        {
            await transform.DORotate(Vector3.back, 10).AsyncWaitForCompletion();
            
            await transform.DOMove(Vector3.back, 10).AsyncWaitForCompletion();
            
        }

    }
    
}
