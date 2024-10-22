# Github actions Fagdag - C# .net core prosjekt

Dette git repoet inneholder en liten C# .net core solution, med en Azure Function app, og et lite Test prosjekt.

I Github, kan du trykke "Fork", for å lage din egen kopi av repoet, til din egen brukerkonto.
Da kan du sette opp og kjøre Github Actions, ved å endre på `.github/workflows/workflow.yaml` filen.

Målet er å teste ut Github actions i praksis, og du skal dermed få løse noen oppgaver.

Du kan redigere og committe filer direkte på Github nettsiden, 
eller trykke `.` for å åpne repoet i et VSCode interface i browseren (anbefales).
Eller laste ned koden lokalt, gjøre endringer og pushe tilbake. 

Det kan være lurt å lage en ny commit, (og pushe til Github, om du jobber lokalt), 
for hver oppgave, for å se om du har gjort det riktig. 
Vi kan holde oss til å jobbe i `main` branchen.


## Oppgaver

*Dette prosjektet er et lite "mandags-prosjekt", og det har en unit-test som kanskje ikke virker som den skal, en dependency med en kjent sårbarhet, samt en eller flere lint/formaterings feil.
Dette skal vi forsøke å finne ved hjelp Github actions `steps`, og fikse med nye commits.*

Pga muligens lite tid, er oppgave 2 og 3 gjort ferdig for dere.

1. "Fork" repoet, slik at du har det på din egen Github konto og kan committe og herje på med Github actions.
2. I workflow.yaml filen, sett opp en `job` som gjør følgende: 
   1. Kjører ved alle nye commits på `main` branchen
   2. Bruker ubuntu-latest til å kjøre jobben
   3. Og et `step` som Sjekker ut koden i repoet (`actions/checkout@v4`)
3. Legg til en `action` som setter opp .net miljøet vi skal bruke til å bygge koden (solutionen). Bruk .net versjon `8.0.x`.
4. Legg til en action som bruker `dotnet` verktøyet for å bygge solutionen, i Release mode, til mappen: `./output`. (Vi skal deploye fra den mappen i opg 8) (Se om du får `Build succeeded` i job loggen) (`dotnet build --configuration Release --output ./output`)
5. Legg til en action som kjører unit testene i `Tests` prosjektet. (`dotnet test --verbosity minimal`)
   1. Dersom den klarte å kjøre testene, var det noe som feilet?
   2. Kan du lage en ny commit med kode-endringer som fikser feilen, og se om testene nå blir grønne (får "Passed") i Github actions?
6. Legg til en action som utfører såbarhets sjekk av Nuget pakker i prosjektet. (`dotnet list package --vulnerable`)
   1. Sjekk loggen til jobben på Github, var det noen Nuget pakker sårbarheter?
7. Legg til en action som installerer "dotnet format" verktøyet: `dotnet tool install -g dotnet-format`
   1. Legg til en ny action som bruker dotnet format til å Linte koden: `dotnet format --verify-no-changes`
   2. Sjekk loggen til jobben på Github, var det noen Lint feil? 
   3. Kan du lage en ny commit som fikser Lint feilen i koden?
8. Siste oppgave (type: Stor oppgave): Å Deploye koden til en Azure Function app! Se egen readme fil: [azure-oppsett.md](azure-oppsett.md)


- For oppgave 4 til 7, trenger vi bare steps som kjører `dotnet` kommandoer på kommandolinjen (ingen tredje parts actions).
- Oppgave 5, 6 eller 7 kan skippes, dersom du har problemer med en av de (bare kommenter ut eller fjern de fra workflow filen), eller vil forsøke å deploye til Azure.


