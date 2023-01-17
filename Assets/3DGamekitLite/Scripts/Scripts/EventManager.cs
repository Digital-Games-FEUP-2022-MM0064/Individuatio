using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void SomethingToSay();
    public static event SomethingToSay OnSomethingToSay;
    public float radius = 5f;
    public LayerMask NPCMask;
    protected PlayerInput m_Input;                 // Reference used to determine how Ellen should move.
    private GameObject _target;
    CharacterController charCtrl;
    void Awake()
    {
        m_Input = GetComponent<PlayerInput>();
    }
    void Start()
    {
        _target = null;
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Debug.Log(m_Input.Speak);
        // Bit shift the index of the layer (7) to get a bit mask
        int layerMask = 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        RaycastHit hit;
        Vector3 p1 = transform.position + charCtrl.center;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(p1, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(p1, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (m_Input.Speak) {

                if (hit.distance < 3 &&  (_target == null ||   hit.collider.gameObject != _target))
                {
                    _target = hit.collider.gameObject;
                    OnSomethingToSay();
                    StartCoroutine(resetTarget());
                }
            }
          
        }
        else
        {
            Debug.DrawRay(p1, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
           
        }
    }

    IEnumerator resetTarget() {
        yield return new WaitForSeconds(3f);
        _target = null;
    }
}
