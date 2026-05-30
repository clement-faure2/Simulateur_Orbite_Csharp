// See https://aka.ms/new-console-template for more information
namespace ProjetOrbite
{
    //Création de la classe position
    public class Position
    {
        private double PositionX;
        private double PositionY;

        //Création du constructeur de la classe position
        public Position(double PositionX_, double PositionY_)
        {
            PositionX = PositionX_;
            PositionY = PositionY_;
        }
        //Pour pouvoir modifier PositionX
        public void setPositionX(double PositionX_)
        {
            this.PositionX = PositionX_;
        }
        //Pour pouvoir modifier PositionY
        public void setPositionY(double PositionY_)
        {
            this.PositionY = PositionY_;
        }
        //Pour pouvoir consulter PositionX
        public double getPositionX()
        {
            return this.PositionX;
        }
        //Pour pouvoir consulter PositionY
        public double getPositionY()
        {
            return this.PositionY;
        }
        public void affichePosition()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("position:   x:" + this.PositionX + "Km");
            Console.WriteLine("            y:" + this.PositionY + "Km");
            Console.WriteLine("--------------------------------------");
        }
    }

    //Création de la classe objet
    public class Objet
    {
        private double PositionX_Objet;
        private double PositionY_Objet;
        private double Masse_Objet;

        //Création du constructeur de la classe objet
        public Objet(Position Position, double Masse_)
        {
            PositionX_Objet = Position.getPositionX();
            PositionY_Objet = Position.getPositionY();
            Masse_Objet = Masse_;
        }

        //Pour pouvoir consulter Masse_Objet
        public double getMasse_Objet()
        {
            return this.Masse_Objet;
        }

    }

    //Création de la classe planete
    public class Planete : Objet
    {
        private string NomPlanete;
        private double Diametre;
        private double PositionX_Planete;
        private double PositionY_Planete;
        private double Masse_Planete;

        //Création du constructeur de la classe planete
        public Planete(String NomPlanete_, double Diametre_, Position Position, double Masse_) : base(Position, Masse_)
        {
            NomPlanete = NomPlanete_;
            Diametre = Diametre_;
            PositionX_Planete = Position.getPositionX();
            PositionY_Planete = Position.getPositionY();
            Masse_Planete = Masse_;
        }
        //Pour pouvoir consulter Masse_Planete
        public double getMasse_Planete()
        {
            return this.Masse_Planete;
        }
        //Pour pouvoir consulter Diametre
        public double getDiametre()
        {
            return this.Diametre;
        }
    }

    //Création de la classe Constante
    public class Constante
    {
        private static double ConstanteGravitation = 6.674 * Math.Pow(10, -11);

        //Création du constructeur de la classe Constante
        private Constante()
        {

        }
        //Pour pouvoir consulter ConstanteGravitation
        public static double getConstanteGravitation()
        {
            return ConstanteGravitation;
        }

        //Création de la classe Position
        public static Position calculVecteurDirection(Position Position_Planete, double Vitesse, double Angle, double Masse_Objet,Position Position_Objet, double Masse_Planete)
        {
            //conversion de l'angle degre en radian
            double angleEnRadians = (double)Angle * (double)(Math.PI / 180.0);
            double distance = Constante.distanceMarsSatellite(Position_Objet, Position_Planete);

            //calcul pour l'accélération
            double acceleration = Masse_Objet / Constante.calculForceGravitationelle(distance, Masse_Objet, Masse_Planete / Masse_Objet);

            //calcul des vecteur vitesse pour

            double vecteurVitesseX = (double)Vitesse * Math.Cos(angleEnRadians);
            double vecteurVitesseY = (double)Vitesse * Math.Sin(angleEnRadians);
            double NouvellePositionX = (double)Position_Planete.getPositionX() + (vecteurVitesseX * (double)1);
            double NouvellePositionY = (double)Position_Planete.getPositionY() + (vecteurVitesseY * (double)1);

            //On inverse pour avoir la distance retour vers la planete
            Position vecteurDeLaPlanete = new Position(Position_Objet.getPositionX() * -1,Position_Objet.getPositionY() * -1);

            //On met le vecteur sur un repere normé
            Position vecteurNorme = new(vecteurDeLaPlanete.getPositionX()/distance, vecteurDeLaPlanete.getPositionY()/distance);

            //Calcul du vecteur pour le deplacement
            Position vecteurDuDeplacement = new(vecteurNorme.getPositionX() * Math.Sqrt(acceleration), vecteurNorme.getPositionY() * Math.Sqrt(acceleration));

            //Calcul du vecteur directeur Final
            Position vecteurDirecteur = new(NouvellePositionX - Position_Objet.getPositionX(), NouvellePositionY - Position_Objet.getPositionY());
            Position vecteurFinal = new(vecteurDirecteur.getPositionX() + vecteurDuDeplacement.getPositionX(), vecteurDirecteur.getPositionY() + vecteurDuDeplacement.getPositionY());
            return new Position(vecteurFinal.getPositionX() + Position_Objet.getPositionX(), vecteurFinal.getPositionY()+ Position_Objet.getPositionY());



        }
        public static double distanceMarsSatellite(Position PositionPlanete, Position PositionObjet)
        { 
            // Calcul de la distance entre Planete et Objet
            double xA = (double)PositionPlanete.getPositionX();
            double yA = (double)PositionPlanete.getPositionY();
            
            double xB = (double)PositionObjet.getPositionX();
            double yB = (double)PositionObjet.getPositionY();


            double DistFinale = Math.Sqrt(Math.Pow((xB - xA), 2) + Math.Pow((yB - yA), 2));

            return DistFinale;
        }

        public static double calculForceGravitationelle(double Distance, double poidsObj1, double poidsObj2)
        { 
            double ForceGravitationelle = (double)ConstanteGravitation * ((poidsObj1 * poidsObj2) / Math.Pow(Distance, 2));
            return ForceGravitationelle;
        }

    }

    //Création de la classe Simulation
    public class Simulation
    {
        private Planete Planete;
        private Object Objet;
        private double AngleDeLancer;
        private double Vitesse;
        
        //Pour pouvoir stocker l'historique des positions
        private static System.Collections.Generic.List<Position> historiqueTrajectoire = new System.Collections.Generic.List<Position>();

        //Création du constructeur de la classe Simulation
        public Simulation(Planete planete_, Object Objet_, double AngleDeLancer_, double Vitesse_)
        {
            this.Planete = planete_;
            this.Objet = Objet_;
            this.AngleDeLancer = AngleDeLancer_;
            this.Vitesse = Vitesse_;
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("======= CONFIGURATION DE LA SIMULATION =======");
            
            Console.Write("Entrez la masse de la planète : ");
            double dynamicMassePlanete = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entrez la Position X de départ du satellite : ");
            double dynamicX = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entrez la Position Y de départ du satellite : ");
            double dynamicY = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entrez la Vitesse de lancer : ");
            double dynamicVitesse = Convert.ToDouble(Console.ReadLine());

            Console.Write("Entrez l'Angle de lancer en degrés : ");
            double dynamicAngle = Convert.ToDouble(Console.ReadLine());

            Position PositionPlanete = new(0,0);
            Position PositionObjet = new(dynamicX, dynamicY);
            Planete Mars = new("Mars", 6779000 , PositionPlanete, dynamicMassePlanete);
            Objet Satellite = new(PositionObjet, 749000);
            Simulation simulation = new(Mars, Satellite, dynamicAngle, dynamicVitesse);

            startSimulation(PositionPlanete, PositionObjet, Mars, Satellite, simulation);
        }

        //Pour pouvoir consulter Simulation
        public static void startSimulation(Position PositionPlanete, Position PositionObjet, Planete Mars, Objet Satellite, Simulation simulation)
        {
            double hauteur = 2;
            double distanceInitiale = Constante.distanceMarsSatellite(PositionObjet, PositionPlanete);

            while (hauteur > 0)
            {
                Console.Clear();
                PositionObjet.affichePosition();
                hauteur = Constante.distanceMarsSatellite(PositionObjet,PositionPlanete)-(Mars.getDiametre()/2);
                
                Console.WriteLine("Altitude : " + Math.Round(hauteur) + " Km");
                
                //Pour pouvoir ajouter la position actuelle dans l'historique
                historiqueTrajectoire.Add(new Position(PositionObjet.getPositionX(), PositionObjet.getPositionY()));
                
                afficheGraphique(PositionObjet, distanceInitiale);

                //Pour pouvoir calculer la position finale
                Position prochainePosition = Constante.calculVecteurDirection(PositionPlanete, simulation.Vitesse, simulation.AngleDeLancer, Satellite.getMasse_Objet(), PositionObjet, Mars.getMasse_Planete());
                
                //Pour pouvoir modifier PositionX et PositionY
                PositionObjet.setPositionX(prochainePosition.getPositionX());
                PositionObjet.setPositionY(prochainePosition.getPositionY());
                
                Thread.Sleep(300);
            }

            Console.WriteLine("\nImpact le satellite s'est écrasé.");
        }

        //Pour pouvoir afficher le graphique
        public static void afficheGraphique(Position posSat, double maxDist)
        {
            int tailleEcran = 15;
            Console.WriteLine("\n--- VISUALISATION GRAPHIQUE (X = Mars, O = Satellite, . = Trajectoire) ---");
            
            double echelle = maxDist / (tailleEcran / 2 - 1);

            for (int y = tailleEcran / 2; y >= -tailleEcran / 2; y--)
            {
                for (int x = -tailleEcran / 2; x <= tailleEcran / 2; x++)
                {
                    int satGridX = (int)Math.Round(posSat.getPositionX() / echelle);
                    int satGridY = (int)Math.Round(posSat.getPositionY() / echelle);

                    //Pour pouvoir verifier l'historique des positions
                    bool estSurLaTrajectoire = false;
                    foreach (Position anciennePos in historiqueTrajectoire)
                    {
                        int histGridX = (int)Math.Round(anciennePos.getPositionX() / echelle);
                        int histGridY = (int)Math.Round(anciennePos.getPositionY() / echelle);
                        if (x == histGridX && y == histGridY)
                        {
                            estSurLaTrajectoire = true;
                        }
                    }

                    if (x == 0 && y == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (x == satGridX && y == satGridY)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("O ");
                        Console.ResetColor();
                    }
                    else if (estSurLaTrajectoire)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("* ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------------");
        }

    }

            
}