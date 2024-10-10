using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtén el objeto del jugador
            GameObject jugador = collision.gameObject;

            // Teletransporta al jugador a la posición (0, 0, 0)
            jugador.transform.position = new Vector3(-9, -1, 0);
        }
    }
}
