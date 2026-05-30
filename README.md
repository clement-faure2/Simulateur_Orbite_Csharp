# 🌌 Simulateur d'Orbite - Moteur Physique 2D en C#

Ce projet est un simulateur de trajectoire orbitale en 2D développé en C#. Il permet de calculer et de visualiser en temps réel l'impact de la force gravitationnelle d'une planète sur un satellite en mouvement, selon les lois de la mécanique classique.

---

## 🚀 Fonctionnalités principales

- **Configuration dynamique :** Saisie au clavier des variables initiales (masse de la planète, coordonnées de départ $X$ et $Y$, vitesse initiale et angle de lancer).
- **Moteur algorithmique complet :** Prise en compte de la constante de gravitation universelle, calcul des forces, de l'accélération et gestion des vecteurs directeurs pour mettre à jour la position de l'objet.
- **Rendu graphique Console :** Affichage d'une grille matricielle 2D dynamique qui s'actualise en direct pour tracer l'historique complet de la trajectoire (Marquage des anciennes positions par des symboles `*`).
- **Gestion des collisions :** Arrêt automatique de la boucle de calcul dès que la hauteur de l'objet passe en dessous du diamètre de la planète.

---

## 🧠 Notions informatiques & scientifiques mises en valeur

- **Programmation Orientée Objet (POO) :** Modélisation rigoureuse via des classes (`Position`, `Objet`, `Planete`, `Simulation`), utilisation des principes d'héritage, d'encapsulation et de constructeurs.
- **Mathématiques appliquées :** Trigonométrie (conversion degrés/radians, calcul de sinus et cosinus pour les vecteurs de vitesse) et calcul vectoriel de repère normé.
- **Physique Newtonienne :** Implémentation de la Loi Universelle de la Gravitation.
