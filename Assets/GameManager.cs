using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalDust;
    private int collectedDust;

    public TextMeshProUGUI winText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalDust = GameObject.FindGameObjectsWithTag("Dust").Length;
        collectedDust = 0;
        winText.gameObject.SetActive(false);
    }

    public void DustCollected()
    {
        collectedDust++;
        if (collectedDust >= totalDust)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
