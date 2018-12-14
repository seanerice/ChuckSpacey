public class AudioGen {
    SndBuf buf => dac;
    fun void setFile(string f) {
        f => buf.read;
    }

    fun void start() {
        1 => buf.rate;
    }
    
    fun void stop() {
        0 => buf.rate;
        0 => buf.pos;
    }
    
    fun void setGain(float g) {
        g => buf.gain;
    }
}

Event AddAudioGenEvent;
fun void AddAudioGenListener(Event e) {
    while (true) {
        e => now;
        
    }
}