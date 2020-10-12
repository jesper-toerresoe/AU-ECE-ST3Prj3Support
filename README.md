# AU-ECE-ST3Prj3Support
Denne Visual Studio 2019 Solution giver et eksempel på hvordan koden i et ST3 PRJ3 kan organiseres efter principperne med en 3 Lags Deling af koden.
Denne Solutionen bruger MS .NET Core 3.1 platformen og er programmet i C#. 
Den indeholder en gren for opstart af hhv. Laptop/PC pgrammet og Raspberry PI programmet. 
Navgivningen af de enkelte projekter skulle gerne vise hvilken den del der er tale (Testes ved at vælge det ene eller det andet "Main" projekt som Startup Project 
Samtidig indtroduceres en måde at organisere designklassestereotyperne Domain, Controller og Boundary på.
Når man bruger en 3 lags (N-lags) arkitektur opstår behovet for Dependency Injection.
For WPF applikationenen på Laptop/PC bruges en Dependency Injection Container (DI Container) fra Microsoft. Se denne turtorial https://executecommands.com/dependency-injection-in-wpf-net-core-csharp/ 
For RPI applaiktionen bruges standard Contructor Injection.
Sammen mned WPF applikationen introduceres MS Entiry Framework Core som er et ORM Framework til databasen. Denne del kan med fordel bruges til at gemme data lokal, en lokal cache!
