using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material MaterialOutline;

    public Material MaterialDefault;
    
    public static Character _selectedCharacter;
    
    public GameUI UI;
    
    public enum SelectionMode
    {
        Default,
        Attack
    }

    public SelectionMode _currentMode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /* On obtient un rayon à partir de la scène
             à partir de la position de la souris*/
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // On récupére une intersection entre le rayon et un collider2D de la scène
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            
            //Si il y a un un élément sous la souris
            if (hit.collider != null)
            {
                //On récupère le composant Character de l'élèment
                Character character = hit.collider.gameObject.GetComponent<Character>();
                //On vérifie si l'élèment contient bien un composant character
                if (character != null)
                {
                    if (_currentMode == SelectionMode.Default)
                    {
                        {
                            //si on a déjà un character sélectionner, alors on remet son material pardéfaut
                            if (_selectedCharacter != null)
                            {
                                _selectedCharacter.Visual.material = MaterialDefault;
                            }
                            //On enregistre dans la variable le character sélectionné
                            Debug.Log(character);
                            _selectedCharacter = character;
                            Debug.Log(_selectedCharacter);
                            //on change le material de l'élément
                            character.Visual.material = MaterialOutline; 
                            UI.SetCharacter(character); 
                        }
                    }
                        
                    else
                    {
                        _selectedCharacter.Attack(character);
                    }
                    
                }
            }
        }
    }

    public void SetAttackMode()
    {
        if (_selectedCharacter == null)
        {
            return;
        }

        _currentMode = SelectionMode.Attack;
    }
}
