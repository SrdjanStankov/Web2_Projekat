# Web2_Projekat

PUSGS – Projekat 2020
1. Namena sistema
Projektni zadatak predstavlja aplikaciju koja omogućava korisnicima da rezervišu avionske karte za željenu
destinaciju i datum. Prilikom rezervacije avionske karte, korisniku se dodatno može ponuditi da rezerviše
hotelski smeštaj i vozilo iz rent-a-car servisa dok je na putu.
Postoje različiti tipovi rezervacije:
1. Rezervacija samo avionske karte
2. Rezervacija avionske karte + hotel
3. Rezervacija avionske karte + vozilo iz rent-a-car servisa
4. Rezervacija avionske karte + hotel + vozilo
Postoji šest vrsta korisnika ovog sistema:
1. Neregistrovani korisnici: mogu da pregledaju informacije o avionskim kompanijama, letovima,
slobodnim mestima, hotelima, rent-a-car servisima;
2. Registrovani korisnici: mogu da rezervišu avionske karte, ocene aviokompaniju/let, otkažu
rezervaciju leta, rezervišu hotelski smeštaj, ocene hotel/sobu, otkažu rezervaciju hotelskog
smeštaja, rezervišu vozilo iz rent-a-car servisa, ocene rent-a-car servis/vozilo, otkažu rezervaciju
vozila, pozovu prijatelje;
3. Administrator aviokompanije: mogu da definišu destinacije (aerodrome) na kojima posluju,
nove letove za određene destinacije, cene karata, dobijaju izveštaje o prodatim kartama, ocenama
korisnika i ostvarenom prihodu na nedeljnom/mesečnom/godišnjem nivou, uređuju info stranicu
aviokompanije;
4. Administrator hotela: mogu da definišu cenovnik usluga hotela (noćenje, polupansion, pun
pansion, transfer od/do hotela, parking, sobni servis...), dobijaju izveštaje o slobodnim i zauzetim
sobama za određeni period, ocenama korisnika i ostvarenom prihodu na
nedeljnom/mesečnom/godišnjem nivou, uređuju info stranicu hotela;
5. Administrator rent-a-car servisa: mogu da definišu vozila koja su raspoloživa za iznajmljivanje,
cenovnik usluga, dobijaju izveštaje o slobodnim i zauzetim vozilima za određeni period, ocenama
korisnika i ostvarenom prihodu na nedeljnom/mesečnom/godišnjem nivou, uređuju info stranicu
rent-a-car servisa;
6. Administrator sistema: mogu da registruju aviokompanije, hotele, rent-a-car servise i njihove
administratore.
Registrovani korisnici se na ovom sistemu mogu povezati sa svojim prijateljima. Zahtev za prijateljstvo
druga strana može da prihvati ili da odbije. Svoje prijatelje (koji su ranije potvrdili zahtev za prijateljstvo)
korisnici mogu pozivati na putovanje. Po prijemu poziva, prijatelj može potvrditi ili otkazati pozivnicu. 
Nakon putovanja, korisnik koji je kreirao rezervaciju i prijatelji koji su se odazvali pozivu mogu oceniti svoje
iskustvo o aviokompaniji/hotelu/rent-a-car servisu ocenom od 1 do 5.
Sve ocene koje korisnici unesu čuvaju se trajno. Prilikom prikaza podataka o aviokompaniji/hotelu/rentacar servisu svakom korisniku se prikazuje i njegova prosečna ocena (dobijena iz ocena koje su dali svi
korisnici sistema).
Svakom rezervacijom, korisnik i prijatelji koji su se odazvali pozivu ostvaruju bonus poene u zavisnosti od
udaljenosti između dve destinacije za koje je rezervisana avionska karta. Ovi poeni se mogu iskoristiti za
umanjenje konačne cene rezervacije. Takođe, korisnik može ostvariti i dodatne popuste u zavisnosti od
tipa rezervacije (na primer, ukoliko je odabrao i hotelski smeštaj, ostvaruje 5% popusta na cenu smeštaja,
itd.). Način računanja dodatnog popusta prepušta se studentima.
2. Funkcije sistema
2.1 Prikaz informacija neregistrovanim korisnicima
Prva stranica koju (neprijavljeni) korisnik vidi je početna stranica aplikacije na kojoj se mogu odabrati
prikazi svih aviokompanija/hotela/rent-a-car servisa i preći na stranicu za registraciju/prijavu na sistem.
• Profil stranica aviokompanije: prikazuju se osnovni podaci o aviokompaniji kao što su naziv,
adresa, promotivni opis, prosečna ocena, informacije o destinacijama gde aviokompanija
saobraća. Takođe, neregistrovani korisnici imaju mogućnost pretrage letova po različitim
parametrima. Prilikom prikaza rezultata pretrage, za svaki let je potrebno prikazati informacije o
njemu;
• Profil stranica hotela: prikazuju se osnovni podaci o hotelu kao što su naziv, adresa, promotivni
opis, prosečna ocena, informacije o slobodnim sobama za određeni vremenski period, prikaz
cenovnika i dodatnih usluga koje hotel nudi. Takođe, neregistrovani korisnici imaju mogućnost
pretrage hotela po različitim parametrima. Prilikom prikaza rezultata pretrage, za svaki hotel je
potrebno prikazati informacije o njemu;
• Profil stranica rent-a-car servisa: prikazuju se osnovni podaci o servisu kao što su naziv, adresa,
promotivni opis, prosečna ocena, informacije o vozilima koja su dostupna unutar servisa i
informacije o filijalama koje postoje unutar servisa. Takođe, neregistrovani korisnici imaju
mogućnost pretrage vozila po različitim parametrima. Prilikom prikaza rezultata pretrage, za
svako vozilo je potrebno prikazati informacije o njemu.
Napomena: korišćenje mapa za prikaz adrese je dodatna funkcionalnost
2.2 Registracija korisnika i prijavljivanje na sistem
Na stranici za registraciju/prijavu na sistem pomoću korisnikove email adrese i lozinke ili putem neke
socijalne mreže, može se izvršiti prijava. (Potrebno je implementirati obe opcije)
Ukoliko korisnik još uvek nije registrovan na sistem, a želi da koristi napredne funkcije aplikacije, mora
prvo da se registruje na odgovarajućoj stranici. Registracija obuhvata unos email adrese, lozinke, imena,
prezimena, grada i broja telefona. Lozinka se unosi u dva polja da bi se otežalo pravljenje grešaka prilikom
odabira nove lozinke. Registracija obuhvata i slanje emaila na datu adresu sa linkom za aktivaciju korisnika. 
Korisnik ne može da se prijavi na aplikaciju dok se njegov nalog ne aktivira posećivanjem linka koji je dobio
u emailu.
Napomena: potrebno je obezbediti bilo kakav mehanizam za autentifikaciju i autorizaciju korisnika na
serverskoj strani.
2.3 Profil korisnika
Registrovani korisnik u mogućnosti je da ažurira svoje lične podatke na stranici za prikaz svog profila. Na
toj stranici je moguće i dodavati i uklanjati prijatelje iz liste prijatelja. Prijatelji se traže po imenu i/ili
prezimenu. Prijateljstvo je obostrano (šalje se zahtev za prijateljstvo koji druga strana može da prihvati ili
odbije).
2.4 Profil aviokompanije
Administrator aviokompanije može da uređuje profil koji sadrži:
• Naziv aviokompanije
• Adresu (dodatno prikaz lokacije korišćenjem mapa)
• Promotivni opis
• Destinacije na kojima posluje
• Letove
• Spisak karata sa popustima za brzu rezervaciju
• Konfiguraciju segmenata i mesta u avionima
• Cenovnik i informacije o prtljagu
Administrator aviokompanije ima mogućnost da dodaje, menja i uklanja sedišta aviona (rezervisano mesto
se ne može obrisati ili izmeniti).
Takođe, ima mogućnost i da definiše letove za različite destinacije. Za svaki let je potrebno definisati
sledeće podatke:
• Datum i vreme poletanja
• Datum i vreme sletanja
• Vreme putovanja
• Dužina putovanja
• Broj i lokacije presedanja
• Cena karte
Aplikacija omogućava administratoru aviokompanije prikaz izveštaja o poslovanju:
• Prosečnu ocenu aviokompanije
• Prosečnu ocenu pojedinačnih letova 
• Prikaz grafika prodatih karata na dnevnom, nedeljnom i mesečnom nivou
• Prihode aviokompanije u određenom periodu
Administrator aviokompanije može i da:
• Ažurira svoje podatke i da promeni lozinku
• Prvi put kada se loguje mora da promeni lozinku
2.5 Profil hotela
Administrator hotela može da uređuje profil koji sadrži:
• Naziv hotela
• Adresu (dodatno prikaz lokacije korišćenjem mapa)
• Promotivni opis
• Cenovnik usluga
• Konfiguraciju soba
Aplikacija omogućava administratoru hotela prikaz izveštaja o poslovanju:
• Prosečnu ocenu hotela
• Prosečnu ocenu pojedinačnih soba
• Prikaz grafika posećenosti hotela na dnevnom, nedeljnom i mesečnom nivou
• Prihode hotela u određenom periodu
Administrator hotela ima mogućnost da dodaje, menja i uklanja sobe (rezervisana soba se ne može
obrisati ili izmeniti).
Takođe, ima mogućnost i da definiše:
• Cenu noćenja za svaku sobu u određenom vremenskom periodu
• Dodatne usluge koje hotel nudi i cene za njihovo korišćenje (dodatne usluge mogu biti transfer
od/do aerodroma, parking, korišćenje bazena, restoran, sobni servis, welness, spa centar, WiFi,
itd.)
• Moguće popuste prilikom rezervacije sobe sa dodatnim uslugama
Administrator hotela može i da:
• Ažurira svoje podatke i da promeni lozinku
• Prvi put kada se loguje mora da promeni lozinku 
2.6 Profil rent-a-car servisa
Administrator rent-a-car servisa može da uređuje profil koji sadrži:
• Naziv servisa
• Adresu (dodatno prikaz lokacije korišćenjem mapa)
• Promotivni opis
• Cenovnik usluga
• Spisak vozila
• Filijale (lokacije na kojima servis posluje)
Administrator servisa ima mogućnost da dodaje, menja i uklanja vozila (rezervisano vozilo se ne može
obrisati ili izmeniti) I filijale.
Aplikacija omogućava administratoru rent-a-car servisa prikaz izveštaja o poslovanju:
• Prosečnu ocenu servisa
• Prosečnu ocenu pojedinačnog vozila
• Prikaz grafika rezervisanih vozila na dnevnom, nedeljnom i mesečnom nivou
• Prihode servisa u određenom periodu
Administrator rent-a-car servisa može i da:
• Ažurira svoje podatke i da promeni lozinku
• Prvi put kada se loguje mora da promeni lozinku
2.7 Home page za registrovanog korisnika
Na osnovnoj stranici za autentifikovanog korisnika prikazana je istorija njegovih letova, rezervisanih hotela
i vozila. Takođe, dostupni su i linkovi za:
• Listu aviokompanija u sistemu – aviokompanije mogu biti sortirane po nazivu, gradu...
• Listu hotela u sistemu – hoteli mogu biti sortirani po nazivu, gradu, udaljenosti...
• Listu rent-a-car servisa u sistemu – servisi mogu biti sortirani po nazivu, gradu, udaljenosti...
• Listu prijatelja - sortirani po imenu, prezimenu, sa mogućnošću dodavanja ili brisanja
• Profil korisnika
Iz liste rezervacija korisnik može da otkaže:
• Let - najkasnije 3 sata pre početka leta. Otkazivanjem leta, otkazuje se i rezervacija hotelskiog
smeštaja i vozila (ukoliko su napravljene dodatne rezervacije)
• Hotelski smeštaj - najkasnije 2 dana ranije (osim u slučaju otkazivanja leta) 
• Vozilo iz rent-a-car servisa - najkasnije 2 dana ranije (osim u slučaju otkazivanja leta)
Sa osnovne stranice, korisniku je potrebno omogućiti prelazak na stranicu koja prikazuje spisak svih
pozivnica. Poziv prijatelja se može prihvatiti ili odbiti. Ukoliko korisnik ne odgovori na poziv (prihvati ili
odbije) u roku od 3 dana od slanja poziva ili 3 sata do početka leta, smatra se da je korisnik odbio pozivnicu.
Registrovani korisnik svakim letom dobija određeni broj bonus poena koje može da iskoristi za umanjenje
konačne cene rezervacije.
2.8 Postupak rezervacije letova
Korak 1: Registrovani korisnik pretragom pronalazi odgovarajući let (sekcija 2.14).
Korak 2: Korisnik bira mesto (ili više njih) iz grafičkog prikaza slobodnih mesta u avionu za izabrani let.
Korak 3: Korisnik opciono poziva prijatelje ukoliko je rezervisao više mesta. Prijateljima se šalje email sa
pozivom. U emailu se nalazi link na stranicu na kojoj prijatelj može da potvrdi ili otkaže rezervaciju. Ukoliko
prijatelj odbije, mesto iz rezervacije postaje slobodno.
Korak 4: Za svako odabrano mesto na letu je potrebno popuniti lične podatke putnika (ime i prezime). Ovi
podaci mogu da se kupe na osnovu registrovanog korisnika koji je kreirao rezervaciju, prijatelja koji je
potvrdio rezervaciju, ili u slučaju da je mesto rezervisano za osobu koja nije korisnik aplikacije, polja se
popunjavaju ručno. Takođe, za svakog putnika na letu je potrebno uneti broj pasoša.
Korak 5: Korisniku se opciono nudi rezervacija smeštaja u mestu na koje leti (sekcija 2.9) i rezervacija vozila
iz nekog rent-a-car servisa koji se nalazi u mestu na koje je sleteo (sekcija 2.10).
Korak 6: Korisniku se šalje email sa podacima o napravljenoj rezervaciji (potrebno je prikazati i podatke o
rezervaciji hotela/vozila, ukoliko je takva rezervacija izvršena).
2.9 Postupak rezervacije hotelskog smeštaja
Korak 1: Registrovani korisnik bira hotel iz liste ili ga pronalazi pretragom (sekcija 2.15).
Korak 2: Korisnik unosi datum dolaska u hotel, broj noćenja, broj gostiju kao i potreban broj soba
određenog tipa (jednokrevetna, dvokrevetna...). Opciono, može da definiše cenovni rang.
Korak 3: Korisniku se prikazuju slobodne sobe koje zadovoljavaju kriterijume koje je uneo i pruža mu se
mogućnost da izvrši selekciju soba koje želi da rezerviše. Za svaku stavku rezultata prikazani su detalji o
sobi (sprat, broj kreveta, tip sobe, itd.), prosečna ocena i ukupna cena za sve noći boravka. Dodatne
informacije koje se mogu prikazati u sklopu rezultata ostavljaju se na izbor studentima.
Korak 4: Korisniku se prikazuju dodatne usluge koje hotel nudi koje su dostupne da ih doda na svoju
rezervaciju.
Napomena: Ukupan broj kreveta u rezervisanim sobama ne sme biti veći od broja kupljenih karata za let.
2.10 Postupak rezervacije vozila
Korak 1: Registrovani korisnik bira rent-a-car servis iz liste ili ga pronalazi pretragom (sekcija 2.16).
Korak 2: Korisnik unosi datum i mesto preuzimanja vozila, datum i mesto vraćanja vozila, tip vozila koje
želi da iznajmi, broj putnika. Opciono, može da definiše cenovni rang. 
Korak 3: Korisniku se prikazuju slobodna vozila koja zadovoljavaju kriterijume koje je uneo i pruža mu se
mogučnost da odabere vozilo. Za svaku stavku rezultata prikazani su detalji o vozilu (naziv, marka, model,
godina proizvodnje, broj sedišta, tip vozila, itd.), prosečna ocena i ukupna cena za sve dane. Dodatne
informacije koje se mogu prikazati u sklopu rezultata ostavljaju se na izbor studentima.
2.11 Postupak brze rezervacije avionskih karata
Na stranici aviokompanije postoji link ka listi karata sa popustima za brzu rezervaciju. Svaka karta iz liste
ima podatak o polaznoj i odredišnoj destinaciji, datumu, vremenu, mestu u avionu, originalnoj ceni i
popustu. Karte se mogu rezervisati isključivo pojedinačno, klikom na dugme rezerviši. Opcija predstavlja
brzu rezervaciju karata koja jednim klikom zamenjuje ceo postupak rezervacije opisan u sekciji 2.8, bez
koraka 5. Mesta koja su vezana za karte na popustu na grafičkom prikazu rasporeda mesta pri klasičnoj
rezervaciji moraju biti onemogućena za izbor. Za ovaj tip rezervacije ne postoji mogućnost dodatnog
rezervisanja hotelskog smeštaja ili vozila iz rent-a-car servisa.
2.12 Postupak brze rezervacije hotelskog smeštaja
Ukoliko je korisnik posle rezervacije leta odabrao da želi da rezerviše i hotelski smeštaj (sekcija 2.8, korak
5), na stranici profila hotela postoji link ka listi soba koje se nalaze na popustu. Korisniku se prikazuju samo
one sobe koje se nalaze na popustu u periodu kada je on na putu. Svaka stavka iz liste ima podatak o sobi,
datumu, vremenu, originalnoj ceni i popustu. Sobe se mogu rezervisati isključivo pojedinačno, klikom na
dugme rezerviši. Opcija predstavlja brzu rezervaciju soba koja jednim klikom zamenjuje ceo postupak
rezervacije opisan u sekciji 2.9. Dodatne usluge koje hotel nudi su unapred definisane za ovaj tip
rezervacije. Sobe koje se nalaze na popustu moraju biti onemogućene za izbor prilikom klasične
rezervacije u periodu u kom se nalaze na brzoj rezervaciji.
2.13 Postupak brze rezervacije vozila
Ukoliko je korisnik posle rezervacije leta odabrao da želi da rezerviše i vozilo (sekcija 2.8, korak 5), na
stranici profila rent-a-car servisa postoji link ka listi vozila koja se nalaze na popustu. Korisniku se prikazuju
samo ona vozila koja se nalaze na popustu u periodu kada je on na putu. Svaka stavka iz liste ima podatak
o vozilu, datumu, vremenu, originalnoj ceni i popustu. Vozila se mogu rezervisati isključivo pojedinačno,
klikom na dugme rezerviši. Opcija predstavlja brzu rezervaciju vozila koja jednim klikom zamenjuje ceo
postupak rezervacije opisan u sekciji 2.10. Vozila koje se nalaze na popustu moraju biti onemogućene za
izbor prilikom klasične rezervacije u periodu u kom se nalaze na brzoj rezervaciji.
2.14 Pretraga i filtriranje letova
Na stranici koja prikazuje listu aviokompanija postoji opcija za pretragu gde je potrebno uneti polazni i
odredišni aerodrom, kao i datume polaska i povratka. Kao dodatni kriterijumi pretrage mogu se postaviti
i tip puta (round-trip, one-way, multi-city), broj osoba, klasa (economy, business, first, … - opciono),
količina prtljaga. Rezultati pretrage za postavljene filtere prikazuju informacije o dostupnim letovima. Za
svaku stavku rezultata prikazani su vreme poletanja i sletanja, broj presedanja, ukupno vreme trajanja
leta, naziv aviokompanije koja obavlja let, cena, itd. Dodatne informacije koje se mogu prikazati u sklopu
rezultata ostavljaju se na izbor studentima. Rezultate pretraga moguće je filtrirati po aviokompaniji,
ukupnom trajanju leta, ceni, itd. Odabirom željenog leta vrši se redirekcija na stranicu sa kompletnim
detaljima za dalju rezervaciju koja uključuje detaljnije informacije o putu (šifre puta, datumi, ...) prtljagu
(količina, težina, dimenzije, ...), dodatnim uslugama (posluženje, novine, ...). Potvrda ovog koraka
rezervacije vodi na korak dva iz sekcije 2.8. 
2.15 Pretraga hotela
Na stranici koja prikazuje listu hotela postoji opcija gde je potrebno uneti lokaciju ili naziv hotela, kao i
vremenski period za koji mu je potreban hotelski smeštaj. Za svaku stavku rezultata prikazani su naziv
hotela, lokacija i ocena. Odabirom željenog hotela, vrši se redirekcija na stranicu sa komplentnim detaljima
za dalju rezervaciju (korak dva iz sekcije 2.9).
2.16 Pretraga rent-a-car servisa
Na stranici koja prikazuje listu rent-a-car servisa postoji opcija gde je potrebno uneti lokaciju ili naziv rentacar servisa, kao i vremenski period za koji mu je potrebno vozilo. Za svaku stavku rezultata prikazani su
naziv rent-a-car servisa, lokacije filijala I ocenu. Odabirom željenog servisa, vrši se redirekcija na stranicu
sa komplentnim detaljima za dalju rezervaciju (korak dva iz sekcije 2.10).
2.17 Postupak ocenjivanja
Korisnik može, na svojoj početnoj stranici, u istoriji rezervacija, uneti ocenu za:
• Let / aviokompaniju (nakon sletanja aviona)
• Hotelsku sobu / hotel (nakon napuštanja sobe)
• Vozilo / rent-a-car servis (nakon vraćanja iznajmljenog vozila)
2.18 Profil administratora sistema
Administratori sistema mogu da registruju aviokompanije/hotele/rent-a-car servise i njihove
administratore. Postoji jedan predefinisani administrator sistema koji može da dodaje druge
administratore sistema. Administrator sistema definiše način određivanja popusta koji korisnici ostvaruju
na osnovu ostvarenih bonus poena.
3. Nefunkcionalni zahtevi
3.1 Serverske platforme
Za realizaciju projekta može se izabrati serverska platforma po želji. Neke od platformi mogu biti:
• .NET CORE (koristi se na vežbama)
• ASP.NET
• Java + EJB 3.0 + Servlets
• Java + Spring
• Java + Play framework
• Java + Spark framework
• Python + Django
• Ruby on Rails
• ... 
3.2 Klijentske platforme
Za realizaciju projekta može se izabrati klijentska platforma po želji:
• Klasična web aplikacija
• Single-page interface aplikacija (npr. Angular + REST servisi)
• Mobilna aplikacija (Android ili iOS)
Vizuelni izgled aplikacije utiče na ocene 7 i više. Lepši izgled svakako ostavlja bolji utisak.
3.3 Slanje e-maila
Za slanje emaila nije obezbeđen poseban servis. Možete koristiti sopstveni email nalog.
3.4 Konkurentni pristup resursima
Važno je da više istovremenih posetilaca, tj. korisnika aplikacije, ne može da rezerviše ista mesta u istom
avionu za isti let, istu hotelsku sobu ili isto vozilo u istom vremenskom periodu. Pored navedenih
ograničenja, svaki student treba da pronađe još po jednu konfliktnu situaciju za svoj deo zahteva i
adekvatno je reši.
3.5 Lokacijski servisi
Za prikazivanje lokacije mogu se koristiti proizvoljni servisi poput Google mapa, Yandex mapa, OpenLayers,
itd.
3.6 Grafički prikaz rasporeda mesta i posećenosti
Za grafički prikaz rasporeda mesta u avionima i pravljenje različitih grafika mogu se koristiti third party
biblioteke za iscrtavanje elemenata.
3.7 Saveti za implementaciju
Dodatne ideje za izgled, opcije i informacije možete videti na postojećim aplikacijama za pretragu kao što
su www.kayak.com, www.momondo.com, www.kiwi.com, www.skyscanner.net, itd. Aplikacija ne koristi
eksterne servise stvarnih aviokompanija, hotela, rent-a-car servisa na kojima bi se obavila zvanična
rezervacija (tema nekog drugog predmeta). Ideja je da se napravi objedinjeni sistem na koji će se
registrovati pružaoci usluga i korisnici istih. Online plaćanja takođe su izuzeta iz implementacije.
4. Raspored zadataka (ko šta treba da radi)
Student 1:
• Tipovi korisnika: 2, 3
• Funkcije: 2.3, 2.4, 2.8, 2.11, 2.14
Student 2:
• Tipovi korisnika: 1, 2, 4, 6
• Funkcije: 2.1, 2.5, 2.9, 2.12, 2.15, 2.18
Student 3: 
• Tipovi korisnika: 1, 2, 5
• Funkcije: 2.2, 2.6, 2.7, 2.10, 2.13, 2.16, 2.17

Napomena: mora se koristiti Git za kontrolu verzija i repozitorijum mora biti na GitHubu dostupan
predavačima na uvid prilikom izrade i odbrane projekta. Mockupi su informativne prirode i ne sadrže sve
podatke navedene u specifikaciji! Takodje se ne očekuje da aplikacija bude 1-1 sa mockup-om! Mockupi
su okvirni kako bi se stekao utisak koji nivo detalja se očekuje!
