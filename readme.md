TRIS GAME:
Per la creazione di questo gioco ci siamo basati sul protocollo UDP.
Come funziona il protocollo da noi ideato:
1)STABILIMENTO CONNESSIONE:
Nella prima form viene stabilito l'host della partita e l'ospite attraverso l'IP del server si connette alla partita.
2)TRASMISSIONE:
Nella trasmissione vengono passate le posizione delle celle cliccate nella fase di gioco. Abbiamo implementato il controllo della disconnessione attraverso un timer (30 secondi).
La repository e' disponibile al seguente link: https://github.com/diegocividini/tris-udp.git
