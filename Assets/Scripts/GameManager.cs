using UnityEngine;
using UnityEngine.SceneManagement;


namespace NewLunarLander
{
    class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int score;
        public bool won;

        public enum SCENE { MENU, GAMEPLAY };


        void Awake()
        {
            Initialize();
        }



        public void LoadGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
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
                // Para qu� quiero crearme si ya hay una instancia de m�? Me destruyo.
                Destroy(gameObject);
            }
        }


    }
}
