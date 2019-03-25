# Prérequis 
* Installer Visual Studio Code
* Installer .Net Core SDK 2.2 :
  https://www.microsoft.com/net/download/core    
# Préparation de la structure de la solution
* `mkdir Isen.DotNet`  
* `cd Isen.DotNet`  
* `git init`  
* `touch .gitignore`  (ou créer un fichier avec ce nom depuis VS Code) puis récupérer un gitignore spécifique à .Net Core.  

Créer un repository sur GitHub / GitLab, puis l'ajouter en temps que
remote sur notre repository local :
`git remote add origin https://github.com/kall2sollies/Isen2019.git`  

Faire un commit initial de nos sources :
`git add .`  
`git commit -m "initial commit"`  
`git push origin master`  

Créer un projet Console, dans un sous-dossier src:
* Créer le dossier src/ et naviguer dedans  
* Dans le dossier src, créer    Isen.DotNet.ConsoleApp et naviguer dedans  
* Créer le projet console : `dotnet new console`  

Créer le fichier solution (.sln) :
* naviguer vers la racine du projet  
* Créer le fichier .sln : `dotnet new sln` 
* Ajouter les différents éléments de la solution à ce projet (projet console):
** `dotnet sln add src/Isen.DotNet.ConsoleApp/`  
Créer un dossier src/Isen.DotNet.Library et naviguer dedans.
Avec la CLI .Net (dont l'interface en ligne de commande, que l'on utilise depuis le début), créer un projet de type 'librairie de classe':
`dotnet new classlib`  

Référencer ce nouveau projet dans le fichier de solution (.sln).
Depuis la racine : `dotnet sln add src/Isen.DotNet.Library`  

Ajouter le projet Library comme référence du projet ConsoleApp:
* Naviguer dans le dossier du projet console  
* `dotnet add reference ../Isen.DotNet.Library`  
# Le C#

## Création d'une classe Hello
Supprimer la classe autogénée (Class1.cs).  
Créer un fichier Hello.cs, et coder la classe.  

## Création d'une class MyCollection
Cette classe aura pour but de manipuler 
une liste de string dans un premier temps.  
* Créer dans le projet Library un 
  sous-dossier Lists,
* une classe MyCollection
* Coder la methode `Add(string item)`  

## Ajouter un projet de tests unitaires
* A la racine de la solution, créer un dossier `tests` et un sous-dossier `Isen.DotNet.Library.Tests` 
* Naviguer vers ce dossier
* `dotnet new xunit`  
* Ajouter ce projet au sln. Depuis la racine: `dotnet sln add tests/Isen.DotNet.Library.Tests`  
* Revenir dans le dossier du projet de test
* Référencer le projet Library dans le projet de test: `dotnet add reference ../../src/Isen.DotNet.Library`  
* Renommer la classe générée automatiquement dans le projet de test et l'appeler `MyCollectionTest`  
* Coder un test de la méthode Add
* Exécuter `dotnet test`  
* Coder les accesseurs indexeurs
* Coder méthodes de tests Count et Index

## Refactoring de la classe MyCollection en classe générique

Réécriture de la classe `MyCollection` qui devient le générique `MyCollection<T>`  

Modification de la classe de test: `new MyCollection()` devient `new MyCollection<string>()`  

Renommer MyCollectionTest.cs en MyCollectionStringTest.cs et renommer la classe de la même façon.