#  TP1 - Simulation interactive et collecte de données (Unity)

##  Description 

Ce projet est une simulation interactive développée avec **Unity 6** et **C#**.  
L’objectif est de créer un environnement 3D où l’utilisateur peut se déplacer, interagir avec des objets et générer des données qui seront enregistrées pour analyse.



##  Fonctionnalités

###  Joueur
- Déplacement avec clavier (WASD)
- Contrôle de la caméra avec la souris
- Mode FPS (première personne)

###  Objets interactifs
- Clic sur objets (Cube / Sphere)
- Changement de couleur aléatoire
- Détection via Raycast

###  Collecte de données
- Nombre total de clics
- Temps passé dans la scène
- Position du joueur enregistrée périodiquement
- Liste des objets cliqués

###  Sauvegarde
- Export des données en fichier JSON
- Fichier généré à la fermeture de l’application

---

##  Technologies utilisées

- Unity 6
- C#
- Input System
- Physics (Raycast)
- JSON Serialization

---

##  Structure du projet

Assets/
├── ClickableObject.cs
├── PlayerMovement.cs
├── PlayerInteraction.cs
├── DataLogger.cs
├── Scenes/
│ └── SampleScene.unity


---

##  Lancement du projet

1. Ouvrir le projet avec Unity Hub
2. Charger la scène :

Assets/Scenes/SampleScene.unity
3. Cliquer sur ▶ Play

---

##  Données générées

Les données sont sauvegardées sous forme de JSON et contiennent :

- Nombre de clics
- Temps total dans la scène
- Positions du joueur
- Historique des interactions

---

##  Auteurs

- Fati Ab
- Farmati Aya

---



- Ajouter une interface UI (HUD)
- Export des données vers une base de données


