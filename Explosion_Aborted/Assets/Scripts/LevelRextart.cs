using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRextart : MonoBehaviour
{
    public AmmoDisplay AmmoHUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitiateRestart()
    {
        StartCoroutine(RestartCountdown());
    }
    private IEnumerator RestartCountdown()
    {
        yield return new WaitForSeconds(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
