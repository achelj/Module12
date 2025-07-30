using System;

public class Horloge
{
    private int heure;       // 0 à 23
    private int minute;      // 0 à 59
    private float seconde;   // 0 à 59.9999

    // Constructeur par défaut
    public Horloge()
    {
        heure = 0;
        minute = 0;
        seconde = 0.0f;
    }

    // Constructeur paramétré
    public Horloge(int heure, int minute, float seconde)
    {
        SetHeure(heure);
        SetMinute(minute);
        SetSeconde(seconde);
    }

    // Constructeur de copie
    public Horloge(Horloge autreHorloge)
    {
        heure = autreHorloge.heure;
        minute = autreHorloge.minute;
        seconde = autreHorloge.seconde;
    }

    // Getters
    public int GetHeure() => heure;
    public int GetMinute() => minute;
    public float GetSeconde() => seconde;

    // Setters avec validation
    public void SetHeure(int heure)
    {
        if (heure < 0 || heure > 23)
            throw new ArgumentOutOfRangeException("L'heure doit être entre 0 et 23.");
        this.heure = heure;
    }

    public void SetMinute(int minute)
    {
        if (minute < 0 || minute > 59)
            throw new ArgumentOutOfRangeException("Les minutes doivent être entre 0 et 59.");
        this.minute = minute;
    }

    public void SetSeconde(float seconde)
    {
        if (seconde < 0 || seconde >= 60)
            throw new ArgumentOutOfRangeException("Les secondes doivent être entre 0 et 59.9999.");
        this.seconde = seconde;
    }

    // Méthodes de transformation en chaînes de caractères
    public string FormatParDefaut()
    {
        return $"{heure}h {minute}m {seconde:F2}s";
    }

    public string FormatStandard()
    {
        string periode = heure >= 12 ? "pm" : "am";
        int heure12 = heure % 12;
        if (heure12 == 0) heure12 = 12; // Ajuste pour l'heure 12h am/pm
        return $"{heure12}h {minute}m {seconde:F2}s {periode}";
    }

    public string FormatMilitaire()
    {
        return $"{heure:D2}:{minute:D2}:{seconde:F2}";
    }

    // Méthode principale pour tester la classe
    public static void Main(string[] args)
    {
        // Test du constructeur par défaut
        Horloge horloge1 = new Horloge();
        Console.WriteLine("Par défaut: " + horloge1.FormatParDefaut());

        // Test du constructeur paramétré
        Horloge horloge2 = new Horloge(15, 30, 45.67f);
        Console.WriteLine("Paramétré: " + horloge2.FormatStandard());

        // Test du constructeur de copie
        Horloge horloge3 = new Horloge(horloge2);
        Console.WriteLine("Copie: " + horloge3.FormatMilitaire());
    }
}
