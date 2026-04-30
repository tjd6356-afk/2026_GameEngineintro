using UnityEngine;
using UnityEngine.SceneManagement;
public class botton : MonoBehaviour
{
    public GameObject reloadPanel;
    public GameObject helpPanel;
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene_Door1");
    }
    public void Gametitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
    }

        public void OpenRelaod()
    {
        reloadPanel.SetActive(true);
    }

    public void CloseRelaod()
    {
        reloadPanel.SetActive(false);
    }
}