using Spell; 

public interface SpellController  {
    void cast(Style style);
    void enable();
    void disable();
    Element get_element();
}
