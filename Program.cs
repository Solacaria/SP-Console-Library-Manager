/*
Du ska skapa ett objektorienterat program i C# för att hantera utlåning och återlämning av böcker i ett bibliotek. 
Programmet ska möjliggöra för bibliotekspersonal att registrera nya böcker, låna ut böcker till låntagare,
ta emot återlämnade böcker samt visa information om tillgängliga böcker och låntagare.

Krav:
Skapa klasser för:

Bok(med egenskaper som titel, författare, låntagare, utlåningsstatus etc.).
Bibliotek(som hanterar en samling av böcker och låntagare).
Låntagare(med egenskaper som namn, personnummer, lånade böcker etc.).
Implementera funktioner för att:

Lägga till nya böcker i biblioteket.
Låna ut böcker till låntagare.
Återlämna böcker.
Visa tillgängliga böcker.
Visa låntagare och deras lånade böcker.
Använd listor och/eller andra lämpliga datastrukturer/filer för att hantera samlingar av böcker och låntagare.

Skapa ett användargränssnitt (konsol-baserat eller GUI) där bibliotekspersonal kan interagera med programmet och utföra ovanstående åtgärder. Skapa en användarvänlig och intuitiv design för användargränssnittet.

Se till att programmet följer god praxis för objektorienterad programmering inklusive inkapsling och  arv.

Testa programmet genom att låna ut och återlämna böcker samt visa korrekt information om tillgängliga böcker och låntagare.*/
using Bilbiotek;

LibraryManager manager = new LibraryManager();
Library library = new Library();


UI userUI = new UI(library, manager);

userUI.MainMenu();







