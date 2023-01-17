using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image img;
    public string[] lines = default;
    public float textSpeed;
    public int index=0;
    delegate void MyDelegate(int num);


    private void OnEnable()
    {
        EventManager.OnSomethingToSay += StartDialogue;
    }
    private void OnDisable()
    {
        EventManager.OnSomethingToSay -= StartDialogue;
    }
    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDialogue() {
        Debug.Log("Iniciando");

        textComponent.gameObject.active = true;
        img.color = new Color(255, 255, 255, 255);
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());


    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(0.5f);
        img.color = new Color(255, 255, 255, 0);
        textComponent.gameObject.active = false;
    }
}
