using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Masks : MonoBehaviour
{
    [SerializeField]
    public GameObject mask1 = default;
    [SerializeField]
    public GameObject mask2 = default;
    [SerializeField]
    public GameObject mask3 = default;
    protected PlayerInput m_Input;                 // Reference used to determine how Ellen should move.
    bool canSwap = true;
    public Light light;
    public Color startColor;
    public Color endColor;
    public float duration = 1f;
    private float currentTime = 0f;
    void Start()
    {
        startColor = Color.white;
        endColor = Color.green;
        m_Input = GetComponent<PlayerInput>();
        mask1 = GameObject.Find("GREEN");
        mask2 = GameObject.Find("RED");
        mask3 = GameObject.Find("BLUE");
        light = GameObject.Find("Directional Light").GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        light.color = Color.Lerp(startColor, endColor, currentTime / duration);
        if (canSwap && m_Input.TabPress && m_Input.MoveInput == Vector2.zero)
        {
            endColor = Color.blue;
            currentTime = 0;
            GameObject middle = GameObject.FindGameObjectWithTag("middle");
            GameObject left = GameObject.FindGameObjectWithTag("left");
            GameObject right = GameObject.FindGameObjectWithTag("right");
            canSwap = false;
            Sequence reset = DOTween.Sequence().Insert(0, DOTween.To(() => 0, x => { }, 0, 2))
         .AppendCallback(() => {
             canSwap = true;
         });
            if (Mathf.Abs(mask1.transform.position.y - middle.transform.position.y) < 0.2f)
            {

                endColor = Color.green;
                currentTime = 0;

                mask1.transform.DOMove(left.transform.position, .1f)
                    .SetEase(Ease.InOutQuad)
                   ;

                mask2.transform.DOMove(right.transform.position, .1f)
                                     .SetEase(Ease.InOutQuad)
                                     ;

                mask3.transform.DOMove(middle.transform.position, .1f)
                             .SetEase(Ease.InOutQuad);

            }
            else if (Mathf.Abs(mask1.transform.position.x - left.transform.position.x) < 0.2f)
            {
                endColor = Color.red;
                currentTime = 0;
                mask1.transform.DOMove(right.transform.position, .1f)
                            .SetEase(Ease.InOutQuad)
                            ;

                mask2.transform.DOMove(middle.transform.position, .1f)
                             .SetEase(Ease.InOutQuad)
                             ;

                mask3.transform.DOMove(left.transform.position, .1f)
                             .SetEase(Ease.InOutQuad);
                ;


             

            }
            else if (Mathf.Abs(mask1.transform.position.x - right.transform.position.x) < 0.2f)
            {

                mask1.transform.DOMove(middle.transform.position, .1f)
                            .SetEase(Ease.InOutQuad)
                            ;

                mask2.transform.DOMove(left.transform.position, .1f)
                             .SetEase(Ease.InOutQuad)
                             ;

                mask3.transform.DOMove(right.transform.position, .1f)
                             .SetEase(Ease.InOutQuad); ;
            }


        }
    }
}
