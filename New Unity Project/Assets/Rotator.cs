using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    public GameObject model;
    public GameObject secondmodel;
    private GameObject current;
    public Slider slider;
    public Slider scaling;
    public Toggle toggle;
    private float previousvalue;
    private float previousScale;
    // Start is called before the first frame update
    void Start()
    {
        current=model;
        secondmodel.SetActive(false);
        model.SetActive(false);
        current.SetActive(true);
        //toggle = GetComponent<Toggle>();
        //previousScale = new Vector3(1f, 1f, 1f);
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        scaling.onValueChanged.AddListener(OnScalingChanged);
        toggle.onValueChanged.AddListener(OnToggle);
    }

    // Update is called once per frame
    void Update()
    {
        //model.transform.localScale = new Vector3(scale, scale, scale);
        //.GetComponent<Renderer>().enabled = false;
    }
    public void OnToggle(bool change)
    {
        if(change == true)
        {
            model.SetActive(false);
            secondmodel.SetActive(true);
            current = secondmodel;
        }
        else
        {
            secondmodel.SetActive(false);
            model.SetActive(true);
            current = model;
        }
    }
    public void OnSliderChanged(float value)
    {
        float delta = value - previousvalue;
        if (delta != previousvalue)
        {
            current.transform.Rotate(Vector3.right * delta * 360);
        }
        previousvalue = value;
    }
    public void OnScalingChanged(float value)
    {
        float deltat = value + previousScale;
        if (deltat != previousScale)
        {
            current.transform.localScale = new Vector3(deltat, deltat, deltat);;
        }
        previousScale = value;
    }
}

