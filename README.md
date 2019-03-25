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

Dupliquer MyCollectionStringTest en MyCollectionCharTest et adapter le code de test en conséquence.

## Implémentation l'interface IList<T>

Indiquer l'implémentation de l'héritage de l'interface IList<T>.
Utiliser l'ampoule de Omnisharp pour :
* générer automatiquement le using manquant
* implémenter les prototypes des méthodes de l'interface

Coder ensuite les méthodes, et leurs tests.

## Manipulation de modèles

### Apartée sur les types nullables
```csharp

// Person est un type référence
Person person; // null
person = new Person(); // pas null
person = null; // re-null

// int est un Value Type
// les types primitifs (bool, int, long, float...)
// sont des types valeur
bool b; //pas null, il vaut sa valeur par défaut (false)
b = true; // true
// b = null; // interdit

// bool? est un bool nullable (type référence)
// bool? != bool
// bool? == Nullable<bool>
bool? nb = null; // null
Nullable<bool> nbb; // null aussi
var hasValue = nb.HasValue; // false
nb = true;
var val = nb.Value; // true

```

Dans le projet Library, créer un dossier Persons (au pluriel).  
Créer une classe Person (au singulier).  

### Retour au modèle
Une personne a 3 champs :
* Prénom
* Nom
* Date de naissance optionnelle

On crée 2 constructeurs (2 et 3 params).  
La version 3 param appelle celui à 2 params puis complète.  

Ajouter un accesseur lecteur seule (getter) pour obtenir l'âge.

