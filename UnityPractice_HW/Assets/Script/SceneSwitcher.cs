using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    public int SceneIndex = 0;
    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current scene name = " + scene.name + "and scene index = " + scene.buildIndex);
        SceneManager.LoadScene(SceneIndex);
    }
    
}
