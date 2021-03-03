using System.Linq;
using UnityEngine;

public class PartyController : MonoBehaviour {
    private static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");
    private Party Party { get; set; }
    private Hero SelectedHero { get; set; }

    private void Start() {
        Party = new Party(FindObjectsOfType<Hero>().ToList());
        SelectedHero = Party.Heroes[0];
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Tab)) {
            ChangeHero();
        }
    }

    private void ChangeHero() {
        var spriteRenderer = SelectedHero.gameObject.GetComponent<Renderer>();
        spriteRenderer.material.SetColor(OutlineColor, Color.gray);
        
        var currentHeroIndex = Party.Heroes.IndexOf(SelectedHero);
        currentHeroIndex++;
        if (currentHeroIndex >= Party.Heroes.Count) {
            currentHeroIndex = 0;
        }
        SelectedHero = Party.Heroes[currentHeroIndex];
        
        spriteRenderer = SelectedHero.gameObject.GetComponent<Renderer>();
        spriteRenderer.material.SetColor(OutlineColor, Color.cyan);
    }
}