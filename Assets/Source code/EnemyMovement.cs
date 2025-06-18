using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 moveDirection;
    private Camera mainCam;
    private Vector2 screenMin;
    private Vector2 screenMax;
    private float halfW;
    private float halfH;
    void Start()
    {
        float angle = Random.Range(0f, 360f);
        float rad = angle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
        mainCam = Camera.main;
        screenMin = mainCam.ViewportToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
        screenMax = mainCam.ViewportToWorldPoint(new Vector3(1, 1, mainCam.nearClipPlane));
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            halfW = sr.bounds.extents.x;
            halfH = sr.bounds.extents.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenMin.x + halfW, screenMax.x - halfW);
        pos.y = Mathf.Clamp(pos.y, screenMin.y + halfH, screenMax.y - halfH);
        transform.position = pos;
    }
}
