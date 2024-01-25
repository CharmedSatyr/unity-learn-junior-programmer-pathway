﻿using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay;
    private float RotatingSpeed;
    private float TimeToNextText;
    private int CurrentText;

    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1.0f;

        TextToDisplay = new List<string>
        {
            "Congratulation",
            "All Errors Fixed"
        };

        Text.text = TextToDisplay[CurrentText];

        SparksParticles.Play();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotatingSpeed);

        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
        }

        if (CurrentText >= TextToDisplay.Count)
        {
            CurrentText = 0;

            Text.text = TextToDisplay[CurrentText];
        }
        else
        {
            Text.text = TextToDisplay[CurrentText];
        }
    }
}