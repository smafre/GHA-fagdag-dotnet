# Oppgave 8: Deploye applikasjonen til din egen Function app på Azure.

Ja, mange steg, men ikke vær redd, det går fort.

1. Logg inn i Sonat Azure, og velg "Sonat Playground" subscriptionen. 
2. Eventuelt, naviger til resource groupen: ["fagdag-github-actions"](https://portal.azure.com/#@sonatconsulting.onmicrosoft.com/resource/subscriptions/8db703d9-3a2c-49a9-9f7f-48fb8aa55aed/resourceGroups/fagdag-github-actions/overview)
3. Opprett din egen Azure Function app i resource group: "fagdag-github-actions", ved å trykke "+ Create"...
   1. Velg "Azure services only", og finn "Function app" i listen. Trykk på "Create" 
   2. På "hosting options" velg "Consumption"
   3. Navngi Function appen slik: 'github-fagdag-<ditt-navn>' for å kunne skille de fra hverandre.
   4. Velg ".NET" som runtime stack. Og "8 (LTS) isolated worker model" som version. Velg "Norway east" som "Region", og "Windows" som operativsystem.
   5. Trykk "Create" nederst. Det er basics vi trenger for å sette opp denne demoen.
   6. Når Function appen er ferdig opprettet, trykk "Go to resource"
   7. Inne på Function appen, gå til "Configuration" -> "General settings", og sett "SCM Basic Auth Publishing" til "On", for å kunne publisere med publish profile. Lagre.
4. Gå tilbake til "Overview" på function appen, trykk "Get publish profile" for å laste ned publishprofile.PublishSettings fil
5. På Github repoet ditt, gå til "Settings" -> "Secrets and variables" -> "Actions" -> "New repository secret", med navn "AZURE_FUNCTIONAPP_PUBLISH_PROFILE", og legg innholdet av filen inn som secreten.
6. Skriv inn navnet på din Azure Function app, i env variabelen "AZURE_FUNCTIONAPP_NAME" i workflow.yaml
7. Alle Github actions workflow steg før Deploy steget, må virke (test,lint og sårbarhets sjekk). Eller bare kommenter de ut.
8. Push en ny commit, med Deploy steget i workflow.yaml, og følg med på status på jobben i Github actions. Får den til å deploye? ("Successfully deployed web package to App Service." i Deploy loggen)
9. I azure, trykk "Refresh" i menyen på function appen. Ser du Functionen "SumAvToTall" i listen?
10. Trykk på Functionen "SumAvToTall". Test den ved å: Trykke "Test/Run" og legg til url parameter "a" og "b" der. (Alternativt: "Get function url", og manuelt legg til to tall som parameter a og b)


## Bildeguide til stegene over her (nice!):

Steg 2:

![alt text](docs/2.png)

Steg 3.1: 

![alt text](docs/3.1.png)

Steg 3.3 - 3.5:

![alt text](docs/3.3.png)

Steg 3.7:

![alt text](docs/3.7-scm-basic-publishing.png)

Steg 4:

![alt text](docs/4.png)

Steg 5:

![alt text](docs/5-secrets.png)

Steg 9:

![alt text](docs/9.png)

Steg 10:

![alt text](docs/10a.png)

![alt text](docs/10b.png)

![alt text](docs/10c.png)

Alternativt, bruk urlen direkte, med query params:
![alt text](docs/10d.png)






