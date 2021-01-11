# TP .NET et Serverless

### Pré-requis
1. Installer
    - [.NET Core](https://dotnet.microsoft.com/download/dotnet-core)
    - [Visual Studio Code](https://code.visualstudio.com/)
    - [Azure Functions extension for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)

### Hello World!
1. Suivre les [instructions officielles](https://docs.microsoft.com/en-us/dotnet/core/get-started) pour créer votre premier programme en .NET
2. Naviguez vers le dossier *sample1* et modifiez le programme en y ajoutant une classe *Personne* avec (Testez le snippet *prop* puis la touche *TAB* ):
    1. Une propriété **nom** de type *string*
    2. Une propriété **age** de type *int*
    3. (optionnel) Une méthode **Hello(bool isLowercase)** qui renvoit **"hello *name*, you are *age*** si **isLowercase** vaut *true*, ou la même chaîne mais en majuscule sinon.
    4. Créez une variable de type *Personne* en lui assignant un nom et un âge ([docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors))
    5. Affichez à l'écran **hello *name*, you are *age*** (au lieu du *Hello World!* d'origine)

Pour recompiler et exécuter votre code, depuis le dossier du projet:
> dotnet run

Pour recompiler uniquement
> dotnet build

### NuGet packages
Comme tout langage moderne, .NET bénéficie d'une communauté de développeurs partageant des librairies prêtes à l'emploi, en l'occurence [NuGet](https://nuget.org). Dans cette exercice nous allons utiliser la librairie la plus populaire de NuGet: **newtonsoft.json** qui permet de facilement travailler avec des données au format json.

1. Toujours sur la base du programme Hello World, installez le package **newtonsoft.json** en exécutant la commande *dotnet add package Newtonsoft.Json* depuis le dossier *sample1*
2. Modifiez le programme afin de sérialiser dans une chaîne de caractère la variable de type *Personne* créée précédemment en utilisant [**JsonConvert.SerializeObject**](https://www.newtonsoft.com/json/help/html/SerializingJSON.htm#JsonConvert) (n'oubliez d'inclure le namespace adéquat en ajoutant **using Newtonsoft.Json** en tête de fichier)
3. (optionnel) Formattez la sérialisation précédente en utilisant un **Formatting==Indented**
4. Affichez le json à l'écran à la place du texte précédemment présent

### Traitement d'image locale
Nous allons maintenant utiliser la librairie [ImageSharp](https://github.com/SixLabors/ImageSharp).

1. Toujours sur le même projet, ajoutez le package **SixLabors.ImageSharp**
2. En vous basant sur [ces exemples](https://docs.sixlabors.com/articles/imagesharp/gettingstarted.html), redimensionnez une image (ou effectuez une autre transformation!) et sauvegardez la. Pour préciser des noms de chemin Windows, je vous conseille la syntaxe **@"c:\chemin\monimage.jpeg"**
3. (optionnel avancé) La gestion du parallélisme et de l'asynchrone est un point fort de .NET. Utilisez **Parallel.ForEach** pour redimensionner plusieurs images en parallèle.

### Portage vers une Azure Function
Nous allons maintenant porter ce petit programme pour pouvoir l'héberger au sein d'une Azure Function. Elle se déclenchera sur un appel [HttpTrigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp) en POST.

1. Retournez à la page d'accueil du portail et créez une Function App (ex: lucvovan-fa) ciblant *.NET Core 3.1*, peu importe la localisation, laissez Azure créer un nouveau Storage Account pour héberger le code de la fonction, et sélectionnez un hosting *Consumption*.
2. [Créez un nouveau projet Azure Functions depuis Visual Studio Code](https://docs.microsoft.com/fr-fr/azure/azure-functions/create-first-function-vs-code-csharp) en faisant bien attention de sélectionner **Http Trigger**
3. Portez votre code de redimensionnement en utilisant le **Stream** en provenance du blob à la place du nom de fichier
4. Déployez votre code et appelez fonction avec curl () ou via un testeur de web service comme [Postman](https://www.postman.com/downloads/).
5. (optionnel) Ajoutez deux paramères GET à votre fonction afin que l'utilisateur puisse choisir les dimensions cibles.
