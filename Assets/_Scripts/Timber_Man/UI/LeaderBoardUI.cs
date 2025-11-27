using UnityEngine;

public class LeaderBoardUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenLeaderBoardUIController()
    {
        gameObject.SetActive(true);
    }

    public void CloseLeaderBoardUIController()
    {
        gameObject.SetActive(false);
    }
}
