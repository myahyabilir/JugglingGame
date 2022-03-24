using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public Text puanArea;
    public Transform empty;
    public Button RestartButton;
    public Button AddSphereButton;
    private sphere sphere;


    // Start is called before the first frame update
    void Start()
    {
        RestartButton.onClick.AddListener(delegate { restartGame(); });
        AddSphereButton.onClick.AddListener(delegate {
            addSphere(); 
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        int children = empty.childCount;
        puanArea.text = children.ToString();

        if(children == 0){
            restartGame();
        }

    }

    void restartGame(){
            SceneManager.LoadScene(0);
    }

    void addSphere(){
        sphere sphere = empty.GetComponent<sphere>();
        sphere.count += 1;
    }
}
