using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public static List<string> lines = new List<string>();
    public static bool end=true;

    public float textSpeed;
    private int index;


    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    
    }
    
    public IEnumerator TypeLine()
    {
        for(int i = 0; i < lines.Count; i++)
        {
            textComponent.text = string.Empty;
            DateTime previousTime = DateTime.Now;
            foreach (char c in lines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                DateTime currentTime = DateTime.Now;

                TimeSpan elapsedTime = currentTime - previousTime;

                if (Input.GetAxis("Jump") > 0 && elapsedTime.TotalMilliseconds > 1000)
                {
                    textComponent.text = string.Empty;
                    break ;
                }
            }
        }
        Dialogue.end = true;

   
    }

}
