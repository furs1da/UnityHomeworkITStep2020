using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonsList : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Button buttonPrefab;
    // Update is called once per frame

    private void Start()
    {
        //PlayerPrefs.SetInt("Key1", 10);
        //PlayerPrefs.SetFloat("Key2", 10f);
        //PlayerPrefs.SetString("Key3", "10");


        //AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        //Destroy(audioSource);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                int x = i;
                Button inst = Instantiate(buttonPrefab, this.transform);
                inst.onClick.AddListener(() => Debug.Log(x));
            }
        }
    }
}
