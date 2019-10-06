using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}