# Prérequis 
* Installer Visual Studio Code
* Installer .Net Core SDK 2.2 :
  https://www.microsoft.com/net/download/core    
  
  
# Préparation de la structure de la solution
* `mkdir Isen.DotNet`  
* `cd Isen.DotNet`  
* `git init`  
* `touch .gitignore`  (ou créer un fichier avec ce nom depuis VS Code)
   puis récupérer un gitignore spécifique à .Net Core.  

   Créer un repository sur GitHub / GitLab, puis l'ajouter en temps que
   remote sur notre repository local :
   `git remote add origin https://github.com/kall2sollies/Isen2019.git`  

   Faire un commit initial de nos sources :
   `git add .`  
   `git commit -m "initial commit"`  
   `git push origin master`  