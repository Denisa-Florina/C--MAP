using lab12.domain;
using lab12.repository;
using lab12.service;

namespace lab12.UI;

public class Ui
{
    private MeciService meciService;
    private EchipaService echipaService;
    private JucatorService jucatorService;
    private JucatorActivService jucatorActivService;

    public Ui()
    {
        string echipaFileName = "Echipa.txt";
        Repository<int, Echipa> echipaRepo = new EchipaRepo(echipaFileName);
        this.echipaService = new EchipaService(echipaRepo);
        
        string jucatorFileName = "Jucator.txt";
        Repository<int, Jucator> jucatorRepo = new JucatorRepo(jucatorFileName);
        this.jucatorService = new JucatorService(jucatorRepo);
        
        string MeciFileName = "Meci.txt";
        Repository<int, Meci> meciRepo = new MeciRepo(MeciFileName);
        this.meciService = new MeciService(meciRepo);
        
        string jucatorActivFileName = "JucatorActiv.txt";
        Repository<Tuple<int, int>, JucatorActiv> jucatorActivRepo = new JucatorActivRepo(jucatorActivFileName);
        this.jucatorActivService = new JucatorActivService(jucatorActivRepo, jucatorRepo);
    }

    private void DisplayMenu()
    {
        Console.WriteLine("__________________________________________________");
        Console.WriteLine("1. Jucatorii dintr-o echipa.");
        Console.WriteLine("2. Jucatorii activi dintr-o jucatorii echipa.");
        Console.WriteLine("3. Toatemeciurile dintr-o perioada de timp.");
        Console.WriteLine("4. Scorul dintr-un meci.");
        Console.WriteLine("10. Toti jucatorii");
        Console.WriteLine("0. Exit.");
        Console.WriteLine("__________________________________________________"); ;
    }

    private void JucatoriiDupaEchipa()
    {
        Console.WriteLine("Echipa: ");
        string input = Console.ReadLine();
        try
        {
            Echipa echipa = this.echipaService.EchipaDupaNume(input);
            List<Jucator> jucatori = (List<Jucator>)this.jucatorService.JucatoriDupaEchipa(echipa);
            jucatori.ForEach(j => Console.WriteLine("ID = " + j.Id + " | Nume = " + j.Nume));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void Jucatorii()
    {
        Console.WriteLine("Jucatorii: ");
        jucatorService.GetJucators().ToList().ForEach(j => Console.WriteLine("ID = " + j.Id + " | Nume = " + j.Nume));
    }

    private void JucatoriiActivDinMeci()
    {
        Console.WriteLine("Dati un meci: ");
        string inputgame = Console.ReadLine();
        Console.WriteLine("Dati o echipa: ");
        string inputteam = Console.ReadLine();

        try
        {
            Echipa echipa = this.echipaService.EchipaDupaNume(inputteam);
            string[] numeJoc = inputgame.Split(" vs. ");
            Echipa echipa1 = this.echipaService.EchipaDupaNume(numeJoc[0]);
            Echipa echipa2 = this.echipaService.EchipaDupaNume(numeJoc[1]);
            Meci meci = this.meciService.MeciuriDupaEchipe(echipa1, echipa2);
            List<JucatorActiv> jucatorActivi =
                this.jucatorActivService.GetJucatoriActiviDinMeciSiEchipa(meci, echipa).ToList();
            jucatorActivi.ForEach(x => Console.WriteLine(this.jucatorService.JucatorDupaID(x.IdJucator).Nume + " | " +
                                                         x.NrPuncteInscrise + " punctaj inscris | " +
                                                         x.Tip.ToString()));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void MeciDupaPerioada()
    {
        Console.Write("Data de inceput: ");
        string firstDateInput = Console.ReadLine();
        Console.Write("Data de final: ");
        string secondDateInput = Console.ReadLine();
        
        bool parse1 = DateTime.TryParse(firstDateInput, out DateTime firstDate);
        bool parse2 = DateTime.TryParse(secondDateInput, out DateTime secondDate);
        
        if (!parse1 || !parse2)
        {
            Console.WriteLine("Formatul datei este invalid!(mm/dd/yyyy).");
            return;
        }
        if (firstDate.CompareTo(secondDate) > 0)
        {
            Console.WriteLine("Data de inceput nu poate sa fie dupa data de la final!");
            return;
        }
        
        List<Meci> meciuri = this.meciService.MeciuriDupaPerioada(firstDate, secondDate).ToList();
        meciuri.ForEach(Console.WriteLine);
    }


    private void ScorulDinMeci()
    {
        Console.Write("Dati un meci: ");
        string inputGame = Console.ReadLine();

        try
        {
            string[] numeJoc = inputGame.Split(" vs. ");
            Echipa echipa1 = this.echipaService.EchipaDupaNume(numeJoc[0]);
            Echipa echipa2 = this.echipaService.EchipaDupaNume(numeJoc[1]);
            Meci meci = this.meciService.MeciuriDupaEchipe(echipa1, echipa2);
            List<JucatorActiv> jucatorActivi1 =
                this.jucatorActivService.GetJucatoriActiviDinMeciSiEchipa(meci, echipa1).ToList();

            List<JucatorActiv> jucatorActivi2 =
                this.jucatorActivService.GetJucatoriActiviDinMeciSiEchipa(meci, echipa2).ToList();

            Tuple<int, int> scor = this.meciService.Scor(meci, jucatorActivi1, jucatorActivi2);
            Console.WriteLine("[" + echipa1.Nume + "] " + scor.Item1 + " - " + scor.Item2 + " [" + echipa2.Nume + "]");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public void Start()
    {
        while (true)
        {
            DisplayMenu();
            Console.WriteLine("Introduce-ti o comanda: ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0": { return; }
                case "1": { this.JucatoriiDupaEchipa(); break; }
                case "10": { this.Jucatorii(); break; } 
                case "2": { this.JucatoriiActivDinMeci(); break; }
                case "3": { this.MeciDupaPerioada(); break; }
                case "4": { this.ScorulDinMeci(); break; }
                default: { Console.WriteLine("Comanda invalida!"); break; }
            }
        }
    }
}