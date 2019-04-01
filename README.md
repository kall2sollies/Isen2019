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

Dans le projet Library, créer un dossier Models (au pluriel).  
Créer une classe Person (au singulier).  

### Retour au modèle
Une personne a 3 champs :
* Prénom
* Nom
* Date de naissance optionnelle

On crée 2 constructeurs (2 et 3 params).  
La version 3 param appelle celui à 2 params puis complète.  

Ajouter un accesseur lecteur seule (getter) pour obtenir l'âge.

### Migration vers une entité

Ajouter un champ Id (int) et un champ Name.
Pour le champ Name, on va déclarer explicitement le champ de backup privé _name

### Modele City

Créer dans Models une classe City, avec Id et Name + ZipCode.

Dans Person, ajouter un champ BornIn de type City.  

### Refactoring
Déplacer Id et Name vers une classe de base, abstraite : `BaseModel`. 

Faire dériver City et Person de BaseModel.
Noter les champs Id et Name comme des override (puisque les champs sont virtuels dans BaseModel). 

### Display

Implémenter un mode d'affichage de base (string), overridable, et l'utiliser dans `ToString()`.  

Compléter ce mécanisme afin d'ajouter le ZipCode à l'affichage des City.  

Puis reprendre l'affichage d'une Person.  

# Création de Repositories

Créer cette arbo :
[Libray]
    /Repositories
    /Repositories/Base (repo abstrait)
    /Repositories/Interfaces (base et interfaces spécifiques)
    /Repositories/InMemory (implémentations InMemory)

## Exemple concret sur CityRepository

Sous InMemory, créer la classe `InMemoryCityRepository`.   

Implémenter une liste test (ModelCollection).  

### Single

Ajouter 2 méthodes `Single()` : recherche par Id, et recherche par Name.  

Ecrire des tests unitaires pour tester ces 2 méthodes single.

### Update

Créer une méthode qui permette de renvoyer le premier Id dispo (max + 1).

Créer une méthode Update qui gère automatiquement les créations de nouvelles entités, ou les mises à jour d'entités existantes.

Créer une méthode `SaveChanges()` qui permette un mécanisme de transaction (décider de sauver tous les changements ou non) via une copie du contexte.  

### Delete

Créer une méthode de `Delete()` d'une entité, qui utilise le mécanisme de transaction.  

### Listes

Créer une méthode `GetAll()` qui renvoie toutes les entités du contexte.

Créer une méthode `Find()` qui prend comme paramètre un prédicat de recherche, sous forme de lambda expression (méthode anonyme).

A ce stade, nous avons couvert toutes les opérations de CRUD:
* C = Create  
* R = Read  
* U = Update  
* D = Delete  

## Refactoring 

### Généralisation du repo
Dans le dossier Base, créer `BaseInMemoryRepository`.   
Déplacer toutes les méthodes de CityRepositoty vers BaseInMemoryRepository et les adapter en généric.  

### Extraction d'interface
Dans le dossier Interfaces, créer `IBaseRepository`  et y rappatrier toutes les signatures des opérations de CRUD.  

Créer une interface `ICityRepository`, qui implémente `IBaseRepository`, sans ajouter de méthode.  
`InMemoryCityRepository` devra implémenter cette interface.  

### TD : Refaire la même chose pour PersonRepository
* Créer l'interface IPersonRepository
* Créer InMemoryPersonRepository
* Créer InMemoryPersonRepoTest en dupliquant l'autre

### Composition / injection de repositories

Dans `PersonRepository`, ajouter un constructeur, qui prend comme paramètre une 
interface de `ICityRepository`.  

La classe `PersonRepository` nécessite d'avoir une instance de `ICityRepository` pour fonctionner. On dit qu'elle a une dépendance sur cette classe.

Cette dépendance est déclarée dans son constructeur.

Ce design pattern s'appelle :
* Pattern d'Injection de Dépendance
* également IoC : Inversion of Control
* ou encore DI : Dependency Injection  

### Relations réciproques

Nous avons la classe de modèle `Person` qui a un champ de type `City` dans sa propriété `BornIn`.  

En termes de verbatim OOP, c'est une relation par composition (une classe a un champ dont le type est une autre classe), par opposition à une relation par héritage.

En termes de verbatim de Base de données relationnelle, c'est une relation `one-to-many`, puisque une personne a une ville, mais une ville a potentiellement plusieurs personnes.  

On peut donc, au niveau de `City`, ajouter une propriété de liste de personnes, qui serait donc la relation réciproque de `Person.BornIn`.   

Attention cependant, même si on ajoute cette relation, elle ne va pas se remplir toute seule.  