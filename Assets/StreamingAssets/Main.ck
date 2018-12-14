public class AudioPath {
    static UGen @ nodes[];

    fun static void SetIn(string prevIn, string in, string n) {
        if (prevIn != """") {
            nodes[prevIn] =< nodes[n];
        }
        nodes[in] => nodes[n];
    }

    fun static void SetOut(string n, string prevOut, string out) {
        if (prevOut != """") {
            nodes[n] =< nodes[prevOut];
        }
        nodes[n] => nodes[out];
    }
}
UGen nodes[0] @=> AudioPath.nodes;
dac @=> AudioPath.nodes[""dac""];
while (true) {
    1::second => now;
}