using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _Instance;

    public static UIManager _Inst
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType<UIManager>();
            }
            return _Instance;
        }
    }

    public Text amoText;
    public Text scoreText;
    public Text waveText;
    public GameObject gameOvetUI;

    public void UpdateAmoText(int magamo, int remainAmo)
    {
        amoText.text = magamo + "/" + remainAmo;
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Scroe: " + newScore;
    }

    public void UpdateWaveText(int waves, int count)
    {
        waveText.text = "Wave: " + waves + "\n" + "Count: " + count;
    }

    public void SetGameOver(bool active)
    {
        gameOvetUI.gameObject.SetActive(active);
    }


}
