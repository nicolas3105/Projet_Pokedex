using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

//Créer par Nicolas LEFEBVRE G4

namespace Projet_pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            //Création liste pokémons
            List<Pokemon> pokemon = new List<Pokemon>();

            //Créations des différents threads pour chaque génération
            var generation1 = Task.Run(() => AjouterPokemon(1, 151, ref pokemon));
            var generation2 = Task.Run(() => AjouterPokemon(152, 251, ref pokemon));
            var generation3 = Task.Run(() => AjouterPokemon(252, 386, ref pokemon));
            var generation4 = Task.Run(() => AjouterPokemon(387, 493, ref pokemon));
            var generation5 = Task.Run(() => AjouterPokemon(494, 649, ref pokemon));
            var generation6 = Task.Run(() => AjouterPokemon(650, 721, ref pokemon));
            var generation7 = Task.Run(() => AjouterPokemon(722, 802, ref pokemon));
            var generation8 = Task.Run(() => AjouterPokemon(803, 898, ref pokemon));

            //On attend la fin de l'éxecution des threads pour continuer
            Task.WaitAll(generation1, generation2, generation3, generation4, generation5, generation6, generation7, generation8);

            Console.WriteLine("----Exercice 1----");
            //Pour chaque pokémon, on affiche son id ainsi que son nom
            foreach (Pokemon poke in pokemon)
            {
                Console.WriteLine(poke.id + " - "+ poke.name.fr);
            }

            Console.WriteLine("----Exercice 2----");
            Console.WriteLine("-Generaion 1-");
            Exercice2(1, 151, ref pokemon);
            Console.WriteLine("-Generaion 2-");
            Exercice2(152, 251, ref pokemon);
            Console.WriteLine("-Generaion 3-");
            Exercice2(252, 386, ref pokemon);
            Console.WriteLine("-Generaion 4-");
            Exercice2(387, 493, ref pokemon);
            Console.WriteLine("-Generaion 5-");
            Exercice2(494, 649, ref pokemon);
            Console.WriteLine("-Generaion 6-");
            Exercice2(650,721, ref pokemon);
            Console.WriteLine("-Generaion 7-");
            Exercice2(722,802, ref pokemon);
            Console.WriteLine("-Generaion 8-");
            Exercice2(803, 898, ref pokemon);

            Console.WriteLine("----Exercice 3----");
            Console.WriteLine("Afficage de tous les pokémons de type Normal : ");
            //Pour chaque pokémons, si il contient le type Normal, on affiche son id et son nom
            foreach (Pokemon poke in pokemon)
            {
                if (poke.types.Contains("Normal"))
                {
                    Console.WriteLine(poke.id + " - " + poke.name.fr);
                }
            }

            Console.WriteLine("----Exercice 4----");
            //Pour chaque pokémon, si il fait partie de la génération 3(id entre 252 et 386), on l'affiche 
            foreach (Pokemon poke in pokemon)
            {
                if (poke.id >= 252 && poke.id <= 386) { Console.WriteLine(poke.id + " - " + poke.name.fr); }
                
            }

            Console.WriteLine("----Exercice 5----");

            int nbPokemonAcier = 0;
            int poidsTotalPokemonAcier = 0;
            // On compte le nombre total de pokémons de type Acier et le poids total puis on divise le poids total des pokémon de type Acier par le nombre.
            foreach(Pokemon poke in pokemon)
            {
                if (poke.types.Contains("Steel"))
                {
                    poidsTotalPokemonAcier = poidsTotalPokemonAcier + poke.weight;
                    nbPokemonAcier++;
                }
            }
            try
            {
                //On fait un try/catch pour eviter la division par 0 si il n'y a pas de pokémon de type Acier.
                Console.WriteLine("Moyenne des poids des Pokémons de type Acier : " + poidsTotalPokemonAcier / nbPokemonAcier);
            }
            catch
            {
                Console.WriteLine("Moyenne des poids des Pokémons de type Acier : 0 ");
            }
            
        }

        public static void AjouterPokemon(int idMin, int idMax, ref List<Pokemon> pokemon)
        {
            for (int i = idMin; i <= idMax; i++)
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    //On récupère le json du pokémon demandé
                    string jsonString = webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + i);
                    //Puis on déserialize le json pour ajouter le pokémon dans la liste des pokémons
                    pokemon.Add(JsonSerializer.Deserialize<Pokemon>(jsonString));
                }
            }
        }

        public static void Exercice2(int min,int max, ref List<Pokemon> pokemon)
        {

            bool normal = false, fire = false, water = false, electric = false, grass = false, ice = false, fighting = false, poison = false, ground = false, flying = false, psy = false, bug = false, rock = false, ghost = false, dragon = false, dark = false, steel = false, fairy = false;
            foreach (Pokemon poke in pokemon)
            {
               if(poke.id>=min&&poke.id<=max)
                {
                    if (poke.types.Contains("Normal") && normal == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Normal");
                        normal = true;
                    }
                    if (poke.types.Contains("Fire") && fire == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Feu");
                        fire = true;
                    }
                    if (poke.types.Contains("Water") && water == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Eau");
                        water = true;
                    }
                    if (poke.types.Contains("Electric") && electric == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Electrik");
                        electric = true;
                    }
                    if (poke.types.Contains("Grass") && grass == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Terre");
                        grass = true;
                    }
                    if (poke.types.Contains("Ice") && ice == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Glace");
                        ice = true;
                    }
                    if (poke.types.Contains("Fighting") && fighting == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Combat");
                        fighting = true;
                    }
                    if (poke.types.Contains("Poison") && poison == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Poison");
                        poison = true;
                    }
                    if (poke.types.Contains("Ground") && ground == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Sol");
                        ground = true;
                    }
                    if (poke.types.Contains("Flying") && flying == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Vol");
                        flying = true;
                    }
                    if (poke.types.Contains("Psy") && psy == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Psy");
                        psy = true;
                    }
                    if (poke.types.Contains("Bug") && bug == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Bug");
                        bug = true;
                    }
                    if (poke.types.Contains("Rock") && rock == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Rock");
                        rock = true;
                    }
                    if (poke.types.Contains("Ghost") && ghost == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Ghost");
                        ghost = true;
                    }
                    if (poke.types.Contains("Dragon") && dragon == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Dragon");
                        dragon = true;
                    }
                    if (poke.types.Contains("Dark") && dark == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Dark");
                        dark = true;
                    }
                    if (poke.types.Contains("Steel") && steel == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Acier");
                        steel = true;
                    }
                    if (poke.types.Contains("Fairy") && fairy == false)
                    {
                        Console.WriteLine(poke.id + " - " + poke.name.fr + " - Fairy");
                        fairy = true;
                    }
                }
            }
        }


    }
}
