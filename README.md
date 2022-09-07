# SBES_TIM42_SUPER_PROJEKAT
SBES 2021/22 super projekat
SBES super projekat 2021/22 – Password Manager

Tema projekta je pravljenje Password Manager-a, aplikacije koja sluzi za skladistenje i kreiranje lozinki. Klijent ima mogucnost da unese vec postojecu lozinku, ili da od aplikacije zatrazi kreiranje nove lozinke. 
Pri registraciji korisnika mora se priloziti USB flash drive na koji se smesta secret key kojim se moze pristupiti aplikaciji. Da bi logovanje korisnika bilo uspesno, taj USB flash drive mora da bude ukljucen u racunar. Korisnik moze da zatrazi backup fajl sa svojim podacima koji su enkriptovani pomocu sifre koje korisnik odredi. 
Korisnik takodje moze da unese 2FA kod pomocu kojeg ce se generisati 2FA autentifikacioni tokeni pomocu kojih se moze pristupiti nalozima na sajtovima koje nudi takvu vrstu autentifikacije.
Korisnik ima i uvid u sve pokusaje logovanja i sve izvrsene/pokusane akcije na aplikaciji (Auditing putem Event Viewer-a i logovanja u enkriptovanom tekstualnom formatu).
Putem kombinacije tipki korisnik moze da otvori jednostavniju verziju aplikacije pomocu koje moze da automatski popuni podatke na pretrazivacu/aplikaciji.
Korisnik moze da unese podatke o svojoj platnoj kartici kojima moze pristupati prilikom unosa tih istih podataka na neki sajt.
Za cuvanje lozinki u bazi podataka, koristi se AES-256. Aplikacija je odradjena koriscenjem .NET Framework-a (C#). 

PREDMET PROJEKAT NADOGRADNJA:

Kao nadogradnja za predmet projekat napravljena je web ekstenzija koja salje API pozive ka desktop aplikaciji, i na osnovu trenutno ucitane web stranice, povlaci kombinaciju username/password za datu stranicu. Ukoliko ima vise kombinacija, korisnik moze da izabere jednu od njih i klikom na button "Fill", ispuni polja za unosenje username/email/password.
