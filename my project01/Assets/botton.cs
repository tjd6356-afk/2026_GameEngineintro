using UnityEngine;
using UnityEngine.SceneManagement;
public class botton : MonoBehaviour
{
    public GameObject helpPeael;
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene_Door1");
    }

    public void OpenHelp()
    {
        helpPeael.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPeael.SetActive(false);
    }
}