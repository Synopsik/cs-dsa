namespace Chapter6;

public class HashSet
{
    public static void CouponDemo()
    {
        HashSet<int> usedCoupons = [];
        do
        {
            Console.Write("Enter the number: ");
            var number = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(number, out int coupon)) {break;}

            if (usedCoupons.Contains(coupon))
            {
                Console.WriteLine("Already used.");
            }
            else
            {
                usedCoupons.Add(coupon);
                Console.WriteLine("Thank you!");
            }
            
            Console.WriteLine("\nUsed coupons:");
            foreach (var couponCode in usedCoupons){Console.WriteLine(couponCode);}
            
            
        } while (true);
    }


    public static void PoolDemo()
    {
        Random random = new();
        Dictionary<PoolTypeEnum, HashSet<int>> tickets = new()
        {
            { PoolTypeEnum.Recreation, new() },
            { PoolTypeEnum.Competition, new() },
            { PoolTypeEnum.Thermal, new() },
            { PoolTypeEnum.Kids, new() }
        };

        for (var i = 1; i < 100; i++)
        {
            foreach ((PoolTypeEnum p, HashSet<int> t) in tickets)
            {
                if (random.Next(2) == 1) {t.Add(i);}
            }
        }
        
        Console.WriteLine("Number of visitors by a pool type:");
        foreach ((PoolTypeEnum p, HashSet<int> t) in tickets)
        {
            Console.WriteLine($"- {p}: {t.Count}");
        }

        var maxVisitors = tickets
            .OrderByDescending(t => t.Value.Count)
            .Select(t => t.Key)
            .FirstOrDefault();
        Console.WriteLine($"\n{maxVisitors} - the most popular.\n");

        HashSet<int> any = new(tickets[PoolTypeEnum.Recreation]);
        any.UnionWith(tickets[PoolTypeEnum.Competition]);
        any.UnionWith(tickets[PoolTypeEnum.Thermal]);
        any.UnionWith(tickets[PoolTypeEnum.Kids]);
        Console.WriteLine($"{any.Count} people visited at least one pool.");

        HashSet<int> all = new(tickets[PoolTypeEnum.Recreation]);
        any.IntersectWith(tickets[PoolTypeEnum.Competition]);
        any.IntersectWith(tickets[PoolTypeEnum.Thermal]);
        any.IntersectWith(tickets[PoolTypeEnum.Kids]);
        Console.WriteLine($"{any.Count} people visited all pools.");
        
    }
}