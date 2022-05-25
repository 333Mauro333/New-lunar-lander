using UnityEngine;
using UnityEngine.SceneManagement;


namespace NewLunarLander
{
    class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int score;



        void Awake()
        {
            Initialize();
        }



        public void LoadGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
        public void LoadResultsScreen()
        {
            SceneManager.LoadScene("Results");
        }
        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        void Initialize()
        {
            // Si no hay una instancia del SceneController...
            if (instance == null)
            {
                // Este controlador se convierte en la escena.
                instance = this;

                // No me destruyo al cargar la escena.
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // Para qué quiero crearme si ya hay una instancia de mí? Me destruyo.
                Destroy(gameObject);
            }
        }


    }
}
