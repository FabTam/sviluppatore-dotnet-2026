# SETUP FRONTEND CON ANGULAR

## INSTALLARE NODE JS
- Attraverso il powershell come amministratore( avendo chocolatey installato) digita il comando
```bash
choco install nodejs
```


# SETUP ANGULAR PER IL NOSTRO BACKEND.

## Elenco di tutti gli endpoint.
## Quali dati che entrano e quali dati escono.
## Quali endpoint richiedono il login.
## Quali endpoint richiedono dei ruoli specifici.


- il nostro register riceve Email, Password, NomeCompleto, Eta.

- modello entità dati in una tabella con i dati, con i dto che espongono i dati


# CARTELLE DEL PROGETTO ANGULAR

## models

Contiene solo interfacce TypeScript.

Serve per descrivere la forma dei dati.

- Trasportare manualmente tutti i modelli del backend (esempio: login.model.ts)


## services

Contiene la logica HTTP.

Qui fai:
- chiamate ai backend
- logica riusabile collegata ai dati

Esempi:

- auth.service.ts
ecc ecc

## pages

Contiene le schermate vere:

 - login
 - register
 - dashboard
 - ecc ecc

 ## core

 Contiene infrastruttura applicativa globale:

 - guard
 - interceptor

 ## shared

 Contiene componenti riusabili.

Nel tuo caso:
- navbar


# Generazione dei file

## Navbar condivisa

- ng generate component shared/components/navbar