# CommLink

# Komunikacinės sąsajos diegimo vadovas.
 1. Parsisiųsti ir įsidiegti .NET 6.0 Runtime darbalaukio programoms ir serverinėms programoms. Oficialus puslapis: https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime?cid=getdotnetcore
 2. Parsisiųsti ir įsidiegti ASP.NET Core Runtime 6.0.5. Oficialus puslapis: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
 3. Savo kompiuteryje atsidarę komandinės eilutės langą (komandinę eilutę galite atsidaryti windows paieškoje įvedę „cmd“ ir paspaudę enter) įveskite komandą „dotnet dev-certs https“. Bus sukurti sistemos veikimui reikalingi sertifikatai.
 4. Parsisiūskite šią repozitoriją ir išskleiskite norimoje vietoje.
 ![image](https://user-images.githubusercontent.com/50969311/169722720-56ad74e0-3a53-449b-8b59-d432143872da.png)
 5. Išskleistame aplankale yra createCommLinkDB.sql failas. Tai yra užklausų rinkinys sukuriantis duomenų bazę reikalingą sistemai. Prieš inicijuojant šias užklausas reikia atkreipti dėmesį į duomenų bazės vietą nurodytą čia: 
 ![image](https://user-images.githubusercontent.com/50969311/169723039-7d8b714e-c3d4-42b3-b438-11a3059ac381.png)
 ![image](https://user-images.githubusercontent.com/50969311/169723071-6fe96c5d-d60b-4238-ab56-9f3f768417e9.png)
  Įsitikinkite, kad šie keliai teisingi, C:/ diske sukurdami aplankalą pavadinimu Sql, arba nurodykite savo vietą duomenų bazei. Neikeiskite duomenų bazės pavadinimo. Pakoregavę duomenų bazės kelią inicijuokite užklausas „Sql Server Management Studio“ įrankyje.
 6. Parsisiųstame aplankale nueikite šiuo keliu CommLink\CommLink\CommLink\bin\CommLink\net6.0-windows10.0.22000.0 . Programai veikti užtenka net6.0-windows10.0.22000.0 aplankalo turinio. Čia rasite komunikacinės sąsajos .exe failą, CommLink.dll.config konfigūracijos failą ir vėliau naudojant sistemą čia atsiras du aplankalai su komunikacijų žinučių žurnalais ir gautais rezultatais XML formatu. Atverkite CommLink.dll.config failą naudodami teksto redagavimo įrankį notepad. Šio failo turinys atrodo štai taip: 
![image](https://user-images.githubusercontent.com/50969311/169723609-d682d5f6-479c-4b0a-b469-47970de96d42.png)
Pakoreguokite pažymėtą vietą įvesdami savo kompiuterio pavadinimą: pvz. Data source= < Kompiuterio pavadinimas >. Išsaugokite ir uždarykite failą.
 7. Komunikacinę sąsają paleiskite du kartus spustelėjus CommLink.exe failą.
