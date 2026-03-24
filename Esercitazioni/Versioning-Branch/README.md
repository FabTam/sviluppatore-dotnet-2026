## Mini glossario dei comandi usati

```bash
- git switch <branch>: passa a un branch.
- git switch-c <branch>: crea e passa al nuovo branch.
- git pull --ff-only: aggiorna il branch solo se può "avanzare dritto" (evita merge automatici).
- git fetch (--all): scarica aggiornamenti dal remoto senza toccare i file locali.
- git add<file>: prepare i file per il commit.
- git commit -m "messaggio" registra le modifiche con un messaggio breve e chiaro-
- git push -u origin <branch>: pubblica il branch e imposta il tracciamento con origin.
- git push  origin :<branch>  : elimina un branch sul remoto.
- git branch -m <nuovo nome>: rinomina un branch locale.
- git branch -d <branch>: elimina un branche locale già mergiato(sicuro).
- git revert: annnulla un commit già pubblicato creando un commit inverso.
- git merge origin/<branch>: unisce nel tuo branch le ultime modifiche del branch remoto.
- git tag -a vX.Y.Z -m "note": crea un tag di versione con descrizione.
```
## Regole semplici per non pestarsi i piedi

- Solo una persona crea il repository e i branch principali(main, developer).
- La persona che crea il repository assegna i ruoli e le regole. In questo caso seguiamo le regole standard che prevedono che solo il Leader sia autorizzato a fare il merge.
- Il branch main è solo per il codice stabile e rilasciato, non ci si lavora direttamente. Solo una persona del team fa merge su main, dopo aver testato e verificato che è tutto ok.
- Gli altri sviluppatori che hanno fatto una modifica o un fix devono APRIRE una pull request.
- Ogni Task o modifica o fix deve essere più semplice possibile, cioè se è troppo complessa deve essere separata in più task semplice.
- Bisogna necessariamente far procede il lavoro e di conseguenza fare il merge di piccoli task semplici, invece di aspettare un task complesso completo per fare un unico merge.
- Bisogna necessariamene rispettare le convenzioni per i nomi dei branch ma anche per le variabili del codice, per i messaggi dei commmit, per i nomi dei file, ecc.
- Il branch main è solo per il codice stabile e rilasciato, non ci si lavora direttamente.s
- Creare sempre un branch developer per integrare le modifiche prima di protarle su main.
- Non bisogna mai lavorare sul developer o sul main.
- Prima di creare una feature: git switch developer && git pull --ff only.
- Una feature = un branch = una PR verso developer. (PR = pull request).
- Evita di modificare le stesse righe: se serve, parlatevi prima.
- Risolvi i conflitti in locale, poi aggiorna la PR.
- Niente push forzati su developer o main.
- Elimina i branch feature dopo il merge(locale e remoto).




