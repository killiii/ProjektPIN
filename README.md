﻿# PIN_PROJEKT
#Autor - Ante Mišković


//////////
Political Party App
/////////

Opis:
Aplikacija simulira upravljanje političkom strankom.


RAD APLIKACIJE

Aplikacija pri pokretanju kreira inicijalnog korisnika s administratorskim pravima 
pomocu metoda klase /Data/IdentityDataInitilizer
username- admin@localhost
pass- Admin1!

te jednog korisnika s "obicnim" pravima 
username- guest@localhost
pass- Guest1!
/////////////////////

Prilikom registracije/aplikacije novog korisnika, administrator na poveznici Applications (controller - Applications)
odobrava ili odbija dolazeće aplikacije.

Korisnici mogu: 
-pregledavati članove stranke (Members - HomeController/Members)
-dodavati,priključiti se ili napustiti zadatke na poveznici (Assigments - AssigmentsController)

Administrator može:
-pregledavati članove stranke (Members - HomeController/Members) i brisati ih (akcija Delete)
-dodavati,priključiti se,napustiti ili brisati zadatke na poveznici (Assigments - AssigmentsController)
