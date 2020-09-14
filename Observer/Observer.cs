using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ObserverPattern
{
    public interface Observer
    {
        void updateObserver(Observable observable);
    }

    public interface Observable
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }

    public abstract class AbstractObservable : Observable
    {
        private List<Observer> observers = new List<Observer>();

        public void registerObserver(Observer observer)
        {
            writeLine("    Ein Zuhörer betritt den Raum");
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            observers.Remove(observer);
            writeLine("    Ein Zuhörer verlässt den Raum");
        }

        public void notifyObservers()
        {
            writeLine("    Benachrichtige alle Zuhörer...");

            foreach (var observer in observers)
            {
                observer.updateObserver(this);
            }
        }

        private void writeLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(line);
            Console.ResetColor();
        }
    }

    public class JokeTeller : AbstractObservable
    {
        public static List<string> jokes = new List<string>()
        {
            "Sorry, aber du siehst so aus, wie ich mich fühle.",
            "Eine Null kann ein bestehendes Problem verzehnfachen.",
            "Wer zuletzt lacht, hat es nicht eher begriffen.",
            "Wer zuletzt lacht, stirbt wenigstens fröhlich.",
            "Trifft sich ein Informatiker mit seinen Freunden. XD",
            "Warum bevorzugen Programmierer den Dark-Mode? Weil Licht Bugs anzieht.",
            "What do programmers want from their bosses? Arrays",
            "Wie viele boolsche Programmierer benötigt es um eine Glühbirne zu wechseln? Ja",
            "Wie viele Programmierer braucht man, um eine Glühbirne zu wechseln? – Keinen einzigen, ist ein Hardware-Problem!",
            "Es gibt genau 10 Typen von Menschen. Solche, die Binärzahlen verstehen und solche, die es nicht tun.",
            "Ein Ingenieur, ein Physiker und ein Microsoft-Programmierer fahren im Auto. Das Auto bleibt auf einmal stehen.\nMeint der Physiker: \"Mist das liegt bestimmt am Shellbenzin, das wir vorher getankt haben.\"\nSagt der Ingenieur: \"Ach was das liegt bestimmt an der Zylinderkopfdichtung.\"\nSagt der Windows-Programmierer: \"Moment mal, jetzt schließen wir alle Fenster, schalten den Motor aus, steigen aus und dann wieder ein und dann gehts schon wieder.\""
        };
        public string joke { get; set; } = "Hab noch gar keinen Witz erzählt...";

        public void tellJoke()
        {
            Console.WriteLine("\nMarkus: Ich bereite meinen neuesten Witz vor...");

            joke = jokes.OrderBy(x => Guid.NewGuid()).ToList()[0];

            Thread.Sleep(5000);
            notifyObservers();
            Thread.Sleep(5000);
        }
    }

    public class JokeListener : Observer
    {
        public string name { get; set; } = "Mr. X";

        public void updateObserver(Observable observable)
        {
            if (observable is JokeTeller jokeTeller)
            {
                Console.WriteLine(name + " lacht über: " + jokeTeller.joke);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var markus = new JokeTeller();
            var david = new JokeListener() { name = "David" };
            var tobias = new JokeListener() { name = "Tobias" };

            markus.registerObserver(tobias);

            markus.tellJoke(); // Nur Tobias hört zu
            markus.tellJoke(); // Nur Tobias hört zu

            markus.registerObserver(david);

            markus.tellJoke(); // David und Tobias hören zu

            markus.removeObserver(tobias);

            markus.tellJoke(); // Nur David hört zu
        }
    }
}
