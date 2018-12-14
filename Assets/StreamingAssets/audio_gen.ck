//Filt f;
//f.out(dac);
//f.freq(5000.0);

//AudioGen a;
//a.read(me.dir() + "Snare.wav");
//a.out(f.thisGen);
//a.start();

Filt f @=> Node a;
(a$Filt).freq(5000);
a.out(dac);

AudioGen g @=> Node b;
b.out(a.thisGen);
(b$AudioGen).read(me.dir()+"Snare.wav");
(b$AudioGen).start ();

Node n[0];


1::second => now;



