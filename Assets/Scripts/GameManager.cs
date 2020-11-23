using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 


    public void NextLevel(int scene)
    {
                SceneManager.LoadScene(scene);
        }
    }