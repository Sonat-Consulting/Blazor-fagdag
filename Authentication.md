# Autentisering i Blazor

Her finner du Microsoft sin offisielle dokumentasjon til hvordan å sikre en ASP.NET Core Blazor WebAssembly standalone app:

<https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/standalone-with-authentication-library?view=aspnetcore-6.0&tabs=visual-studio-code>

I menyen til venstre ligger også eksempler på andre måter å få inn autentisering på.

Denne guiden kan følges for å kjapt få opp en ny Blazor app med Google innlogging. Ved å spesifisere flagget `-au` (kort for `--auth`) i

`dotnet new blazorwasm -au Individual -o {APP NAME}`

kan man få generert en app med "autentiseringsskjelettet" på plass. Her skal vi altså opprette en ny app.

Guiden nevner hva og hvor man skal legge inn Google OAuth 2.0 OIDC informasjon i Blazor appen for at innlogging med Google skal funke. Dette krever at man setter opp OAuth 2.0 credentials i Google Cloud Platform (<https://console.cloud.google.com/apis/credentials>):

- Opprett et nytt prosjekt hvis du ikke har gjort dette før.
- Sett opp en app i "OAuth consent screen".

  - Jeg valgte en app av typen "External".
  - Jeg la inn "App name", "User support email" og e-postadressen min i "Developer contact information".
  - "Authorised domains" lot jeg være tom, det var ikke nødvendig i dette enkle eksempelet.
  - I "Scopes" valgte jeg bare email, men her kan man velge fritt selv hva man ønsker å hente på vegne av brukeren i Google.
  - I "Test users" la jeg inn meg selv slik at det er mulig å teste innloggingen uten å "gå live".

- Gå til "Credentials" og velg "Create credentials" og "OAuth client ID"

  - Velg application type "Web application"
  - Gi client'en et navn (for eksempel Blazor fagdag)
  - Under "Authorised JavaScript origins" legger jeg inn `https://localhost:7042` - hentet fra `launchSettings.json` i det nye prosjektet jeg opprettet. Det er denne URL'en Blazor appen kjører på.
  - Under "Authorised redirect URIs" legger jeg inn `https://localhost:7042/authentication/login-callback`.
  - Jeg trykker "Create" og får opprettet en Client ID. Denne legger jeg inn i `appsettings.Development.json` slik som dokumentasjonen til Microsoft viser eksempel på (under "Google OAuth 2.0 OIDC example").

- Nå skal du kunne logge inn med din Google konto i din nye Blazor app

Les gjennom dokumentasjonen til Microsoft for å få en gjennomgang av hvordan dette fungerer. Videre kan man eksperimentere med `<AuthorizeView>` og lignende for å lage ruter som for eksempel kun vises for innloggede brukere. Ler mer her: <https://docs.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-6.0>

Eksempel på en enkel Blazor side som viser forskjellig innhold basert på om man er innlogget eller ikke:

```
@page "/private"

<AuthorizeView>
    <Authorized>
        <h1>Hello, @context.User.Identity.Name!</h1>
        <p>You can only see this content if you're authenticated.</p>
    </Authorized>
    <NotAuthorized>
        <a href="authentication/login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

@code {

}
```

Prøv å gjøre menyen dynamisk, slik at menypunktet for å komme til `/private` kun vises når man er innlogget.
