using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PaintingWall : MonoBehaviour
{
    public static PaintingWall intance;

    public GameObject Brush,RestartPanel;

    public float Brushsize = 0.1f;
    public float percentage=0;
    public Text percentagetxt;


    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.instance.paint == true)
        {
            if (Input.GetMouseButton(0))
            {
                var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(Ray, out hit))
                {
                    var go = Instantiate(Brush, hit.point + Vector3.zero * 0.1f, Quaternion.identity, transform);
                    percentage = percentage + 0.05f;
                    go.transform.localScale = Vector3.one * Brushsize;
                }
            }
        }
        
        if (percentage >= 100)
        {
            percentage = 100;
            RestartPanel.gameObject.SetActive(true);
        }
        

        percentagetxt.text = "%" + percentage;

        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
