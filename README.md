# PIN_PROJEKT
#author-Ante Mišković
#PoliticalPartyAPP

Aplikacija služi kao simulacija upravljanja radom stranke.

#1

Pokretanjem aplikacije, pokrenuti će se i metode klase IdentityDataInitializer (/Data/IdentityDataInitializer)
koja će kreirati 2 osnovna korisnika.

Jedan od njih ( username - admin@localhost  / password- Admin1!) će biti administrator i imati će prava

-pregledavati,prihvaćati ili odbijati pridošle aplikacije/zahtjeve za članstvom u stranci
	CONTROLLER - Account AKCIJE- Accept i Delete   VIEW-Account/Applications

-Dodavati,brisati i pregledavati ZADATKE ( Assigments )
CONTROLLER - AssigmentsController AKCIJE-SVE

-pregledavati članove te ih po potrebi izbacivati
HomeController- Akcije members/delete

Drugi korisnik - guest@localhost pw- Guest1!

#2
 services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<MyIdentityRole>()

U kontekst baze podataka injektirano je prošireno sučelje osnovnog korisnika po modelu AppUser (/Models/AppUser.cs)
te prošireno sučelje Identity.Roles (/Models/MyIdentityRole). 