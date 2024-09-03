using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private Button reload;

    // Start is called before the first frame update
    void Start()
    {
        reload = GetComponent<Button>();
        reload.onClick.AddListener(Reloading);

        reload.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Reloading()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
