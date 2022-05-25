using UnityEngine;

using UnityEngine.SceneManagement;


public class ForLoadGameplay : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
