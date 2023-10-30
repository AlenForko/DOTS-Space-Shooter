using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class FPSDisplayMono : MonoBehaviour
{
    private float _deltaTime;

    private World _world;
    private EntityManager _entityManager;
    

    void Update()
    {
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);

        var Asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        float msec = _deltaTime * 1000.0f;
        float fps = 1.0f / _deltaTime;

        string text = string.Format("{0:0.0} ms ({1:0.} fps / Asteroids: {2})", msec, fps, Asteroids.Length);
        GUI.Label(rect, text, style);
    }
}
