using System;

bool fortuna = true;
int giriFortunati = 3;

Console.WriteLine("Per girare la ruota e vincere premi inserire almeno un euro e premere invio");
double cash = double.Parse(Console.ReadLine());
var creditoResiduo = cash;
Random giroRuota = new Random();

string[] premiRuota = {
    "+1 giro ruota gratis", "+ 10 euro", "+ 4 euro", "- 1 euro", "hai preso tutto", "passa", "+1 giro ruota gratis", 
    "+1 giro ruota gratis", "+1 giro ruota gratis", "- 1 euro", "- 1 euro", "- 1 euro", "+ 4 euro", "- 2 euro", 
    "- 1 euro", "- 1 euro", "RADDDDOPPPPIA", "passa", "passa", "- 2 euro", "- 2 euro", "+1 giro ruota gratis", 
    "+1 giro ruota gratis", "FORTUNA AUMENTATA MA ATTENZIONE","FORTUNA AUMENTATA MA ATTENZIONE","FORTUNA AUMENTATA MA ATTENZIONE","FORTUNA AUMENTATA MA ATTENZIONE","FORTUNA AUMENTATA MA ATTENZIONE"
};

if (cash >= 1)
{
    while (creditoResiduo >= 1)
    {
        var gira = premiRuota[giroRuota.Next(0, premiRuota.Length)];
        creditoResiduo--;
        string messaggio;
        Console.WriteLine(gira);
        Console.ReadKey();

        if (gira == "+1 giro ruota gratis")
        {
            creditoResiduo++;
        }
        else if (gira == "+ 10 euro")
        {
            creditoResiduo += 10;
        }
        else if (gira == "+ 4 euro")
        {
            creditoResiduo += 4;
        }
        else if (gira == "- 2 euro")
        {
            creditoResiduo -= 2;
        }
        else if (gira == "hai preso tutto")
        {
            creditoResiduo = 0;
        }
        else if (gira == "passa" || gira == "- 1 euro")
        {
            creditoResiduo--;
        }
        else if (gira == "RADDDDOPPPPIA")
        {
            creditoResiduo *= 2;
        }
        else if (gira == "FORTUNA AUMENTATA MA ATTENZIONE")
        {
            string[] premiMaggiori = {
                "passa", "+1 giro ruota gratis", "+1 giro ruota gratis", "+1 giro ruota gratis", "+1 giro ruota gratis", 
                "+1 giro ruota gratis", "+1 giro ruota gratis", "+ 4 euro", "+ 4 euro", "+ 4 euro", "+ 10 euro", "+ 10 euro", 
                "hai preso tutto", "RADDDDOPPPPIA", "+1 giro ruota gratis", "+1 giro ruota gratis", "+1 giro ruota gratis"
            };

            var spin = premiMaggiori[giroRuota.Next(0, premiMaggiori.Length)];
            Console.WriteLine(spin);

            if (giriFortunati > 0)
            {
                giriFortunati--;
                if (giriFortunati == 0)
                {
                    fortuna = false;
                    Console.WriteLine("Giri fortunati terminati");
                }
            }
        }

        messaggio = $"Hai a disposizione {creditoResiduo} giri di ruota";
        Console.WriteLine(messaggio);

        if (creditoResiduo <= 0)
        {
            Console.WriteLine("Hai terminato i giri di ruota, vuoi ricaricare? SI/NO");
            string ricaricare = Console.ReadLine().ToLower();

            if (ricaricare == "si")
            {
                Console.WriteLine("Inserire l'importo da ricaricare");
                double importoRicaricato = double.Parse(Console.ReadLine());
                creditoResiduo += importoRicaricato;
                Console.WriteLine($"Hai a disposizione {creditoResiduo} giri di ruota");
            }
            else
            {
                Console.WriteLine("Grazie per aver giocato");
                break;
            }
        }
    }
}
else
{
    Console.WriteLine("Inserire almeno 1 euro");
}

Console.ReadKey();
