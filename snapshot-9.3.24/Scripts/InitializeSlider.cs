using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InitializeSlider : MonoBehaviour
{
    [SerializeField]
    public Slider[] sliders;

    // Start is called before the first frame update
    void Start()
    {
        // Set all listed sliders to the rightmost position by default
        foreach (var slider in sliders)
        {
            slider.value = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
