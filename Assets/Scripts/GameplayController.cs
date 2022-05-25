using UnityEngine;

using TMPro;


public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI tmp;

    float timeToInit = 3.0f;

    void Start()
    {
        tmp.text = "GAME STARTS IN " + timeToInit.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        timeToInit = (timeToInit - Time.deltaTime > 0.0f) ? timeToInit - Time.deltaTime : 0.0f;

        if (timeToInit <= 0.0f)
        {
            player.SetActive(true);
            tmp.gameObject.SetActive(false);
        }
        else
        {
            tmp.text = "GAME STARTS IN " + timeToInit.ToString("0");
        }
    }
}
