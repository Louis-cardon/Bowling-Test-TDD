using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var program = new Program();
        program.LancerJeu();
    }

    public void LancerJeu()
    {
        List<(int, int?)> resultatJeu = new List<(int, int?)>();
        Console.WriteLine("Bienvenue dans le jeu de Bowling!");

        while (CanPlay(resultatJeu))
        {
            Console.WriteLine($"Frame {resultatJeu.Count + 1}:");
            int premierLancer = DemanderLancer("Entrez le nombre de quilles renversées au premier lancer: ");

            int? deuxiemeLancer = null;
            if (premierLancer < 10 || resultatJeu.Count >= 9) 
            {
                if (!(resultatJeu.Count == 10 && premierLancer == 10)) 
                {
                    deuxiemeLancer = DemanderLancer("Entrez le nombre de quilles renversées au deuxième lancer: ", 10 - premierLancer);
                }
            }

            resultatJeu.Add((premierLancer, deuxiemeLancer));
            Console.WriteLine($"Score après cette frame: {CalculScore(resultatJeu)}");
        }

        Console.WriteLine($"Score final: {CalculScore(resultatJeu)}");
    }

    public int DemanderLancer(string message, int quillesRestantes = 10)
    {
        int quillesRenversees;
        bool saisieValide;
        do
        {
            Console.Write(message);
            saisieValide = int.TryParse(Console.ReadLine(), out quillesRenversees) && EstSaisieValide(quillesRenversees, quillesRestantes);
            if (!saisieValide)
            {
                Console.WriteLine("Saisie invalide, veuillez réessayer.");
            }
        } while (!saisieValide);
        return quillesRenversees;
    }

    public bool EstSaisieValide(int quillesRenversees, int? quillesRestantes = null)
    {
        if (quillesRenversees < 0 || quillesRenversees > 10)
        {
            return false;
        }

        if (quillesRestantes.HasValue && (quillesRenversees > quillesRestantes.Value ))
        {
            return false;
        }

        return true;
    }

    public void Run()
    {
        Console.WriteLine("Hello, World!");
    }

    public int CalculScore(List<(int, int?)> resultatJeu)
    {
        int score = 0;
        for (int frameIndex = 0; frameIndex < Math.Min(10, resultatJeu.Count); frameIndex++)
        {
            var frame = resultatJeu[frameIndex];
            if (IsStrike(frame))
            {
                score += 10 + StrikeBonus(resultatJeu, frameIndex);
            }
            else if (IsSpare(frame))
            {
                score += 10 + SpareBonus(resultatJeu, frameIndex);
            }
            else
            {
                score += frame.Item1 + (frame.Item2 ?? 0);
            }
        }
        return score;
    }

    private int SpareBonus(List<(int, int?)> rolls, int frameIndex)
    {
        return rolls.Count > frameIndex + 1 ? rolls[frameIndex + 1].Item1 : 0;
    }

    private int StrikeBonus(List<(int, int?)> rolls, int frameIndex)
    {
        int bonus = 0;
        if (rolls.Count > frameIndex + 1)
        {
            var nextFrame = rolls[frameIndex + 1];
            bonus += nextFrame.Item1;
            if (nextFrame.Item2.HasValue)
            {
                bonus += nextFrame.Item2.Value;
            }
            else if (rolls.Count > frameIndex + 2)
            {
                bonus += rolls[frameIndex + 2].Item1;
            }
        }
        return bonus;
    }

    public bool IsSpare((int, int?) frame) => frame.Item1 + (frame.Item2 ?? 0) == 10 && frame.Item1 != 10;

    public bool IsStrike((int, int?) frame) => frame.Item1 == 10;

    public bool CanPlay(List<(int, int?)> lancers)
    {
        if (lancers.Count < 10) return true;

        if (lancers.Count == 10)
        {
            var dernierLancer = lancers.Last();
            return IsStrike(dernierLancer) || IsSpare(dernierLancer);
        }

        if (lancers.Count == 11)
        {
            var dixiemeFrame = lancers[10];
            if (IsStrike(dixiemeFrame))
            {
                return true;
            }
            return false;
        }
        return false;
    }




}
