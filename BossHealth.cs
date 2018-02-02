﻿using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class BossHealth : MonoBehaviour {

    [SerializeField]
    private int health = 100;
    public bool isDead;

    [SerializeField]
    private GameObject[] wings;
    private Collider col;

    private Animator animator;

    [SerializeField]
    private AudioClip takeHitClip;
    private AudioSource audioSource;

    private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        col = GetComponent<Collider>();
    }

    public void TakeDamage(int amount) {
        if (!isDead) {
            health -= amount;

            audioSource.PlayOneShot(takeHitClip);

            if (health <= 0) {
                isDead = true;

                col.enabled = false;

                foreach (GameObject obj in wings) {
                    obj.SetActive(false);
                }

                animator.SetBool("Dead", true);
            }
            else {
                animator.SetTrigger("TakeHit");
            }
        }
    }
}
