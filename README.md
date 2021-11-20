# Blazor-fagdag

Her finner du Microsoft sin offisielle dokumentasjon til Blazor.

<https://docs.microsoft.com/en-gb/aspnet/core/blazor/?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0>

.Net Runtime og SDK:

<https://dotnet.microsoft.com/download/dotnet/6.0>

## For å kjøre

Gå til Server folder i prosjektet
`dotnet run`

Åpne nettleser på valgfri url i output:
`Now listening on: https://localhost:7094`

## Oppgaver

1. I filen NavMenu.Razor ligger menyen. I denne oppgaven skal du bruke Mobil-skjerm. Åpne developer tools og velg mobilskjerm-format. Da blir hamburger-menyen synlig. Ved å bruke klassen 'collapse' skal du implementere åpning og lukking av menyen.
2. Vi trenger en komponent som kan legges til på diverse sider. Den kan ha mulighet til å ta en tittel og lenke til spørreskjemaet. Tittel kan f.eks være "Hva synes du om fagdagen?"
3. Vi må ha en enkel kalkulator, lag et menypunkt for en enkel kalkulator med 2 input felter, og to knapper som enten summerer eller multipliserer verdiene i input feltene. Vis resultatet under knappene.
4. På weatherforecast trenger vi værdata fra Yr.no.
   Yr sitt API returnerer på longitude og latitude, du finner den her:

   <https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latString}&lon={lonString}>

   Det ligger en WeatherForecastController i blazorFagdag.Server prosjektet. Implementer en HTTP GET metode i kontrolleren som tar inn lattitude og longitude og returnerer en liste av WeatherForecast til klienten.

5. Siden det er vanskelig å huske lengde og breddegrader trenger vi en komponent hvor de største byene i Norge er lagt inn. Da kan vi heller velge by fra en dropdown eller lignende.
6. Hvis du er uheldig/trykker feil og velger å se været i Oslo ønsker du gjerne å nullstille listen med værdata. Da kan vi legge på en knapp for å nullstille listen. Før vi nullstiller kan vi vise en javascript confirm dialog for å være sikker på at vi skal nullstille (<https://developer.mozilla.org/en-US/docs/Web/API/Window/confirm>).

   Lag en knapp med en onclick metode som bruker IJSRuntime for å kjøre javascript. Vis en confirm dialog, og fjern listen med værdata dersom resultatet er true/ja/ok/confirm.

7. Ekstra, legg til autentisering?
