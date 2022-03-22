using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpectrum : MonoBehaviour
{
    private RectTransform[] bars;
    private float[] spectrum;

    void Start()
    {
        bars = transform.GetComponentsInChildren<RectTransform>();
        spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);


        Debug.Log(spectrum);
        Debug.Log(spectrum[5]);
        Debug.Log("!!!");

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            bars[i].sizeDelta = new Vector2(15, spectrum[i]);
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            /*bars[i].sizeDelta = new Vector2(5, 1000*spectrum[i]);*/
            bars[i].sizeDelta = new Vector2(5, 100 * (Mathf.Log(spectrum.Length*spectrum[i])));
        }
    }
}
