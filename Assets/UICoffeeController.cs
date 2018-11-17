using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Controla cuanto café se muestra en la interfaz, en el componente del café del canvas

// EL GAME MANAGER DEBE DE ASIGNAR MEDIANTE UICoffeeController.CoffeePercentage = X 
// EL PORCENTAJE (0.0 A 1.0) DE CAFÉ RESTANTE SIEMPRE QUE ESTE CAMBIE.
public class UICoffeeController : MonoBehaviour
{

    private float coffeePercentage; // from 0.0 to 1.0!!! 1.0 is filled | 0.0 is empty

    public float CoffeePercentage { 
		get { 
			return coffeePercentage; 
		} 
		set { 
			// Siempre que cambiemos el valor, se va a actualizar el display
			this.coffeePercentage = value; 
			UpdateDisplay(); 
		} 
	}

	// Imagen que representa el liquido del café en la UI
	public Image coffeeForeground;

    // Use this for initialization
    void Start()
    {
        this.CoffeePercentage = 1.0f;
    }

	// actualiza la imagen del café segun su porcentaje.
    void UpdateDisplay()
    {
		this.coffeeForeground.fillAmount = this.coffeePercentage;
    }
}
