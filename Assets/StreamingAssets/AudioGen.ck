public class AudioGen extends Node {
    "AudioGen" => type;
    SndBuf buf @=> thisGen;
    1 => buf.gain;
    
    fun void start() {
        0 => buf.pos;
        1 => buf.rate;
    }
    
    fun void stop() {
        0 => buf.rate;
        0 => buf.pos;
    }
    
    fun void read(string file) {
        file => buf.read;
    }
    
    stop();
}