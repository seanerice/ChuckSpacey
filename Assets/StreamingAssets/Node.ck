class Node {
    string id;
    string type;
    UGen inGen;
    UGen thisGen;
    UGen outGen;
    
    fun void in(UGen i) {
        i @=> inGen;
        inGen => thisGen;
    }
    
    fun void out(UGen o) {
        o @=> outGen;
        thisGen => outGen;
    }
}