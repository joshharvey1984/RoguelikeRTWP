using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour {
    public List<Hero> heroes;
    public Hero selectedHero;

    private void Start() {
        heroes.AddRange(FindObjectsOfType<Hero>());
        selectedHero = heroes[0];
    }

    private void Update() { }
}