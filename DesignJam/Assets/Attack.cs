﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Attack : MonoBehaviour
{

    public ParticleSystem fireCone;
    public ParticleSystem shockWave;
    public float fireballLength = 0.2f;
    public float fireballCooldown = 0.4f;
    public AudioSource AttackSound;

	public float ParticleStrengthScale = 5;

	public bool UseTap = true;

    private AudioClip clipRecord;

    public static bool Tapped { get; set; }
   
    public float MaxFireConeParticleLifetime = 5; 
    // 
    private float lastXAccel = 0;
    private float lastYAccel = 0;
    private float lastZAccel = 0;

    public int SpaceEmitNum = 200;
    public float SpaceEmitSpeed = 25;

    private bool isShooting = false;

    void Start ()
    {
        fireCone.enableEmission = false;
        //shockWave.enableEmission = false;

        clipRecord = Microphone.Start(null, true, 1, 44100);
		AttackSound.clip = clipRecord;
		AttackSound.PlayDelayed(0.2f);
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        int dec = 128;
        float[] waveData = new float[dec];

        int micPosition = Microphone.GetPosition(null)-(dec+1); // null means the first microphone
        if (micPosition >= 0)
        {
            clipRecord.GetData (waveData, micPosition);
            
            // Getting a peak on the last 128 samples
            float levelMax = 0;
            for (int i = 0; i < dec; i++)
            {
                float wavePeak = waveData [i] * waveData [i];
                if (levelMax < wavePeak)
                {
                    levelMax = wavePeak;
                }
            }
            // levelMax equals to the highest normalized value power 2, a small number because < 1
            // use it like:
			            
			fireCone.startColor = new Color(0.3f + (levelMax * ParticleStrengthScale), 0.2f + (levelMax * 2f), 0f);
			fireCone.startSpeed = Mathf.Max(Mathf.FloorToInt(Mathf.Sqrt(levelMax) * ParticleStrengthScale) * 10f, 25);
			fireCone.Emit(Mathf.FloorToInt(Mathf.Sqrt(levelMax) * ParticleStrengthScale));

        }

        if (Input.GetKeyUp (KeyCode.Space))
        {
            fireCone.Emit(SpaceEmitNum);
        }
    }

}
