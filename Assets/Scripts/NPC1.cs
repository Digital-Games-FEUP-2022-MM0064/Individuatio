using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public float radius = 1f;
    public LayerMask layerMask;
    List<string> lines = new List<string>();
    public Dialogue dialogue;
    // Start is called before the first frame update
    bool f = true;
    void Start()
    {
        Dialogue.end = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (colliders.Length > 0 && f)
        {
            f = false;
            Dialogue.lines.Clear();
            dialogue.gameObject.active = true;
            Dialogue.lines.Add("FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 FALA1 ");
            Dialogue.lines.Add("Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 Fala2 ");
            Dialogue.lines.Add("Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 Fala3 ");
            Dialogue.lines.Add("Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 Fala4 ");
            Dialogue.lines.Add("Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 Fala5 ");
            dialogue.StartDialogue();


        }

        if (colliders.Length > 0 && (Input.GetKeyDown(KeyCode.F)))
        {
            Debug.Log("Reset F");
            f = true;
            Dialogue.end = false;
        }

        if (Dialogue.end)
        {
            dialogue.gameObject.active = false;
        }
    }
}
