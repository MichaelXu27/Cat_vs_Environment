using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Transform howToPlayPanel;

    public void SwitchHowToPlayPanel()
    {
        howToPlayPanel.gameObject.SetActive(!howToPlayPanel.gameObject.activeSelf);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
