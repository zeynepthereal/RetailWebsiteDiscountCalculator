using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public MembershipType MembershipType { get; set; }
    public int YearsAsCustomer { get; set; }
}

public abstract class Membership
{
    public abstract decimal GetDiscount(Bill bill);
}

public class GoldMembership : Membership
{
    public override decimal GetDiscount(Bill bill)
    {
        return bill.TotalAmount * 0.3m;
    }
}

public class SilverMembership : Membership
{
    public override decimal GetDiscount(Bill bill)
    {
        return bill.TotalAmount * 0.2m;
    }
}

public class AffiliateMembership : Membership
{
    public override decimal GetDiscount(Bill bill)
    {
        return bill.TotalAmount * 0.1m;
    }
}

public class Bill
{
    public decimal TotalAmount { get; set; }
    public List<Item> Items { get; set; }

    public decimal CalculateNetPayableAmount(User user)
    {
        decimal discount = 0;

       
        Membership membership = GetMembership(user.MembershipType);
        if (membership != null)
        {
            discount = membership.GetDiscount(this);
        }

        
        if (user.YearsAsCustomer > 2)
        {
            discount += TotalAmount * 0.05m;
        }

      
        discount += Math.Floor(TotalAmount / 200) * 5;

        
        foreach (Item item in Items)
        {
            if (!(item is PhoneItem))
            {
                item.ApplyDiscount(discount);
            }
        }

        return TotalAmount - discount;
    }

    private Membership GetMembership(MembershipType type)
    {
        switch (type)
        {
            case MembershipType.Gold:
                return new GoldMembership();
            case MembershipType.Silver:
                return new SilverMembership();
            case MembershipType.Affiliate:
                return new AffiliateMembership();
            default:
                return null;
        }
    }
}

public abstract class Item
{
    public decimal Price { get; set; }

    public abstract void ApplyDiscount(decimal discount)
   ;
}

public class PhoneItem : Item
{
    public override void ApplyDiscount(decimal discount)
    {
       
        Price -= discount;
    }
}

public enum MembershipType
{
    Gold,
    Silver,
    Affiliate
}

public class mainpg
{
    public static void Main(string[] args)
    {
        
        User user = new User
        {
            Name = "John Doe",
            MembershipType = MembershipType.Gold,
            YearsAsCustomer = 3
        };

        
        Bill bill = new Bill
        {
            TotalAmount = 950,
            Items = new List<Item>
            {
                new PhoneItem { Price = 500 },
                new Item { Price = 200 },
                new Item { Price = 250 }
            }
        };

       
        decimal netPayableAmount = bill.CalculateNetPayableAmount(user);

        Console.WriteLine("Net Payable Amount: $" + netPayableAmount);
    }
}

