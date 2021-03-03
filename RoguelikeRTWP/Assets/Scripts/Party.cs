using System.Collections.Generic;

public class Party {
    public List<Hero> Heroes { get; }
    
    public Party(List<Hero> heroes) {
        Heroes = heroes;
    }
}
