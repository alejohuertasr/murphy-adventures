using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public void LoadScene(int index) {
        StartCoroutine(WaitForLoad(index));
    }

    private IEnumerator WaitForLoad(int index) {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(index);
    }

}
