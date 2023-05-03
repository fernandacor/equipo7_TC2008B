using UnityEngine;

// Script que define el funcionamiento de los objetos con los que se puede interactuar

public class Interactable : MonoBehaviour {

	public float radius = 3f;				// Radio de cercanía necesario para interactuar con el objeto
	public Transform interactionTransform;	// Transform del objeto

	bool isFocus = false;	// Booleano que se activa si el personaje está en el foco del objeto
	Transform player;		// Referencia al jugador

	bool hasInteracted = false;	// Booleano que se activa si ya se interactuó con un objeto

	public virtual void Interact ()
	{
		// Este metodo es virtual para que se pueda sobreescribir en los scripts de los objetos
		//Debug.Log("Interacting with " + transform.name);
	}

	void Update ()
	{
		// Función que se llama si el objeto está en foco y si no se ha interactuado con el
		if (isFocus && !hasInteracted)
		{
			// Si el personaje está suficientemente cerca del objeto:
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if (distance <= radius)
			{
				// Interacción con el objeto
				Interact();
				hasInteracted = true;
			}
		}
	}

	// Función que se llama cuando el objeto está en el foco
	public void OnFocused (Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Función que se llama cuando el objeto deja de estar en el foco
	public void OnDefocused ()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	// Función que dibuja un gizmo en el editor para ver el radio de interacción
	void OnDrawGizmosSelected ()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}