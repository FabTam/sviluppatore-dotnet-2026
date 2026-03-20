# HTML

L'html è un linguaggio di markup realizzato per creare pagine web. Esso definisce la struttura e il contenuto di una pagina web utilizzando una serie di tag e attributi.

## Tag

Un tag è un elemento di base dell'htmil, che viene utilizzato per definie la strutture a e il contenuto di una pagina web. I tag sono racchiusi tra parentesi angolari <> e possono
essere di apertura o di chiusura.

```html
<p> Questo è un paragrafo.</p>
```
I tag vanno messi in ordine opposto, tipo:

```html
<p><b> Questo è un paragrafo.</b></p>
```
l'ultimo aperto è il primo che si chiude.

Alcuni tag hanno un vaore semantico, cioè indicando al browser ed ai motori di ricerca il significato del cotnenuto, ad esempio `<h1>` indica un titolo principale, mentre `<strong>` indica un testo
importante.
Altri tag invece sono utilizzati principalmente per la formattazione del testo, come `<b>` per il greassetto e `<i>` per il corsivo.
# Attributi

Gli attributi sono utilizzati per fornire ulteriori informazioni sui tag. Gli attributi sono scritti all'interno del tag di apertura e sono composti da un nome e un valore:

```html
<p class = "testo"> Questo è un paragrafo</p>
```
- **p** è il nome del tag.
- **class** è il nome dell'attributo.
- **"testo"** è il valore dell'attributo.

# Pagina HTML

La struttura di un apagina HTML è composta da diversi elementi, tra cui head e body.
- **Head** contiene le informazioni sulla pagina, come il titolo e il link ai file CSS e Javascript.
- **Body** contiene il contenuto della pagina, come testo, immagini e altri elementi.

Esempio di pagina base HTML:


```html
<!DOCTYPE html>
<html>
    <head>
        <title> La mia pagina web </title>
    </head>
    <body>
        <h1>Benvenuti nella mia pagina web</h1>
        <p>Questo è un paragrafo di esempio</p>  
    </body>
</html>    
```

I commenti in HTML si scrivono così:
```html
<!-- Questo è un commento in HTML -->
```

 # HEADING

 Generalmente nell'head si mettono le informazioni riguardanti:
- Il titolo della pagina.
- I link ai file CSS.
- Le indicazioni riguardanti il viewport.
- Le indicazioni sulla localizzazione della pagina.
- Le indicazioni sulla codifica dei caratteri della pagina.

Quindi un esempio completo di head potrebbe essere:

```html
<head>
    <title> La mia pagina web</title>
    <link rel="stylesheet" href="style.css">
    <meta name="viewport" content="width-device-width, initial-scale=1.0">
    <meta name="language" content="it">
    <meta charset="UTF-8">
</head>
```