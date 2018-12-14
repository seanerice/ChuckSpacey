public class Filt extends Node {
    "Filt" => type;
    inGen => LPF lpf @=> thisGen;
    
    fun void freq(float frq) {
        frq => lpf.freq;
    }
    
    fun void res (float q) {
        q => lpf.Q;
    }
}