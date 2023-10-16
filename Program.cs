using System;

public interface Biryani //The Main Component
{
    string GetItemName();
    double price();
}
public class ChickenBiryani : Biryani //The Concrete Component
{

    public string GetItemName()
    {
        return "Chicken Biryani";
    }
    public double price()
    {
        return 12.0;
    }
}
public class MuttonBiryani : Biryani //The Concrete Component
{
    public string GetItemName()
    {
        return "Mutton Biryani";
    }
    public double price()
    {
        return 14.0;
    }
}
public abstract class BiryaniAddOns : Biryani //Decorator base class implementing the component interface
{
    protected Biryani _biryani;
    public BiryaniAddOns(Biryani biryani)
    {
        _biryani = biryani;
    }
    public virtual string GetItemName()
    {
        return _biryani.GetItemName();
    }
    public virtual double price()
    {
        return _biryani.price();
    }

}
public class Raita : BiryaniAddOns //Concrete decorator - 1
{
    public Raita(Biryani biryani) : base(biryani)
    {
    }

    public override string GetItemName()
    {
        return base.GetItemName() + ", Raita";
    }

    public override double price()
    {
        return base.price() + 3.0;
    }
}

public class OnionsandLemons : BiryaniAddOns //Concrete decorator - 2
{
    public OnionsandLemons(Biryani biryani) : base(biryani)
    {
    }

    public override string GetItemName()
    {
        return base.GetItemName() + ", Onions and Lemons";
    }

    public override double price()
    {
        return base.price() + 2.0;
    }
}
public class MasalaCurry : BiryaniAddOns //Concrete decorator - 3
{
    public MasalaCurry(Biryani biryani) : base(biryani)
    {
    }

    public override string GetItemName()
    {
        return base.GetItemName() + ", Masala Curry";
    }

    public override double price()
    {
        return base.price() + 3.0;
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose your base biryani: 1 - Chicken Biryani, 2 - Mutton Biryani");

        int choice;

        if (int.TryParse(Console.ReadLine(), out choice))
        {
            Biryani selectedBiryani;

            if (choice == 1)
            {
                selectedBiryani = new ChickenBiryani();
            }
            else if (choice == 2)
            {
                selectedBiryani = new MuttonBiryani();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            Console.WriteLine("Customize your biryani:");
            Console.WriteLine("1 - Add Raita");
            Console.WriteLine("2 - Add Onions and Lemons");
            Console.WriteLine("3 - Add Masala Curry");
            Console.WriteLine("4 - Exit");

            while (true)
            {
                int addOnChoice;

                if (int.TryParse(Console.ReadLine(), out addOnChoice))
                {
                    if (addOnChoice == 1)
                    {
                        selectedBiryani = new Raita(selectedBiryani);
                    }
                    else if (addOnChoice == 2)
                    {
                        selectedBiryani = new OnionsandLemons(selectedBiryani);
                    }
                    else if (addOnChoice == 3)
                    {
                        selectedBiryani = new MasalaCurry(selectedBiryani);
                    }
                    else
                    {
                        Console.WriteLine("Customization completed.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid add-on choice. Please enter a valid option.");
                }
            }

            Console.WriteLine("Your Customized Biryani: " + selectedBiryani.GetItemName());
            Console.WriteLine("Total Cost: $" + selectedBiryani.price());
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid option.");
        }
    }
}