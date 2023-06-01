using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float maxScale = 1.2f;
    private Vector2 _scaleChange;
    private Vector2 maxSize = new Vector2(1.2f, 1.2f);
    private float timeElapsed;
    private float lerpDuration = 3;
    public GameObject knightOutline;
    private SpriteRenderer outlineSprite;

    private bool _shouldShrink;
    // Start is called before the first frame update
    void Start()
    {
        _scaleChange = new Vector2(0.01f, 0.01f);
        timeElapsed = 0;
        outlineSprite = knightOutline.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        // if (Input.GetAxisRaw("Horizontal"))
    }

    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    private void Move()
    {
        
    }
    
    private void OnMouseOver()
    {
        if (transform.localScale.x < maxSize.x)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, maxSize, Time.deltaTime * 10);
        }

        outlineSprite.enabled = true;
    }

    private void OnMouseExit()
    {
        outlineSprite.enabled = false;
        StartCoroutine(Shrink());
    }
    private IEnumerator Shrink()
    {
        float t = 0;
        var scale = transform.localScale;
        do
        {
            transform.localScale = Vector3.Lerp(scale, new Vector3(1, 1, 1), t);
            t += 10f * Time.deltaTime;
            yield return null;
    
        } while (transform.localScale.x > 1);
    }
}
