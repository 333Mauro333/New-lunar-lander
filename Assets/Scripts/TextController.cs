using UnityEngine;

using UnityEngine.UI;
using TMPro;


namespace NewLunarLander
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI tmp;
        [SerializeField] Button b;



        void Start()
        {
            tmp.text = "You have ended with " + GameManager.instance.score + " points.\nPress ESCAPE to back to menu.";
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.score = 0;
                GameManager.instance.LoadMenu();
            }
        }
    }
}
