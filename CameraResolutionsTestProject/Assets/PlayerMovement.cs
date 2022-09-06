using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float timer = 1f;
    public float growTime = 0.5f;

    private bool _shouldShrink;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Grow());
        _shouldShrink = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldShrink)
            StartCoroutine(Shrink());
    }

    public IEnumerator Grow()
    {
        var scale = transform.localScale;
        Vector2 maxScale = new Vector2(1.2f, 1.2f);

        do
        {
            transform.localScale = Vector3.Lerp(scale, maxScale, timer / growTime);
            timer += Time.deltaTime;
            print("Growing: " + transform.localScale);
            yield return null;

        } while (timer < growTime);

        timer = 0;
        _shouldShrink = true;
    }

    public IEnumerator Shrink()
    {
        var scale = transform.localScale;
        Vector2 minScale = new Vector2(1, 1);

        do
        {
            transform.localScale = Vector3.Lerp(scale, minScale, 0.01f);
            timer += Time.deltaTime;
            print("Shrinking: " + transform.localScale);
            yield return null;

        } while (timer < growTime);
    }
}
