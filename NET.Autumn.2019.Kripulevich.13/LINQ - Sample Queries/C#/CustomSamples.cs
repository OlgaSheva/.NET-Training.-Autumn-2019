using SampleQueries;
using SampleSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuerySamples
{
    [Title("LINQ Query Samples")]
    [Prefix("Linq")]
    class CustomSamples : SampleHarness
    {
        private readonly List<LinqSamples.Customer> customers;
        private readonly List<LinqSamples.Product> products;
        private readonly List<LinqSamples.Supplier> suppliers;

        public CustomSamples()
        {
            var linqSamples = new LinqSamples();
            this.customers = linqSamples.GetCustomerList();
            this.products = linqSamples.GetProductList();
            this.suppliers = linqSamples.GetSupplierList();
        }

        [Category("Task13")]
        [Title("01")]
        [Description("Gets a list of all customers whose total orders exceed some given value.")]
        public void LinqQuery01()
        {
            var vipCustomers =
                from customer in customers
                let sum = customer.Orders.Sum(x => x.Total)
                where sum > 100000
                select new { customer, sum };

            Console.WriteLine("Customers with total orders over 100'000:");
            foreach (var vip in vipCustomers)
            {
                Console.WriteLine($"{vip.customer.CompanyName}: {vip.sum}");
            }
        }

        [Category("Task13")]
        [Title("02 join")]
        [Description("For each customer receives a list of suppliers located in the same country and the same city.")]
        public void LinqQuery02()
        {
            var list =
                from customer in customers
                join supplier in suppliers on new { customer.Country, customer.City } equals new { supplier.Country, supplier.City } into cs
                select new { customer, suppliersList = cs };

            foreach (var sl in list)
            {
                int sCount = sl.suppliersList.Count();
                if (sCount > 0)
                {
                    Console.WriteLine($"{sl.customer.CustomerID} ({sl.customer.City}). Suppliers from the same city: {sCount}");
                    foreach (var s in sl.suppliersList)
                    {
                        Console.WriteLine($" - {s.SupplierName}");
                    }
                }
            }
        }

        [Category("Task13")]
        [Title("02")]
        [Description("For each customer receives a list of suppliers located in the same country and the same city.")]
        public void LinqQuery02_()
        {
            var list =
                from customer in customers
                select new
                {
                    customer,
                    suppliersList = from supplier in suppliers
                                   where customer.Country == supplier.Country && customer.City == supplier.City
                                   select supplier
                };

            foreach (var sl in list)
            {
                int sCount = sl.suppliersList.Count();
                if (sCount > 0)
                {
                    Console.WriteLine($"{sl.customer.CustomerID} ({sl.customer.City}). Suppliers from the same city: {sCount}");
                    foreach (var s in sl.suppliersList)
                    {
                        Console.WriteLine($" - {s.SupplierName}");
                    }
                }
            }
        }

        [Category("Task13")]
        [Title("03")]
        [Description("They will receive a list of those customers whose orders exceed the set value in total.")]
        public void LinqQuery03()
        {
            var cust =
                from customer in customers
                where customer.Orders.Any(o => o.Total > 1000)
                select customer;

            Console.WriteLine("Customers with total orders over 100'000:");
            foreach (var c in cust)
            {
                Console.WriteLine(c.CompanyName);
            }
        }

        [Category("Task13")]
        [Title("04")]
        [Description("Get a list of all customers in sorted form by year, month of peer order, customer" +
            " turnover (maximum to minimum) and customer name.")]
        public void LinqQuery04()
        {
            var cust =
                from customer in customers
                where customer.Orders.Count() > 0
                let firstOrder = customer.Orders.Min(o => o.OrderDate)
                let ordersSum = customer.Orders.Sum(o => o.Total)
                orderby firstOrder.Year, firstOrder.Month, ordersSum descending, customer.CompanyName
                select new { customer, firstOrder, ordersSum };

            foreach (var c in cust)
            {
                Console.WriteLine($"{ c.firstOrder} - {c.ordersSum} - {c.customer.CompanyName}");
            }
        }

        [Category("Task13")]
        [Title("05")]
        [Description("Get a list of those customers whose non-digital postal code is indicated or " +
            "the region is not filled out or the operator’s code is not indicated on the telephone.")]
        public void LinqQuery05()
        {
            var cust =
                from customer in customers
                where (customer.PostalCode?.All(x => char.IsDigit(x)) ?? false)
                    || ((customer.Region?.Length ?? 0) == 0) 
                    || (customer.Phone?.StartsWith("(") ?? false)
                select customer;

            foreach (var c in cust)
            {
                Console.WriteLine($"{c.CompanyName} - {c.PostalCode} - {c.Region} - {c.Phone}.");
            }
        }

        [Category("Task13")]
        [Title("06")]
        [Description("Group all products into categories, inside - according to stock availability, " +
            "inside the last group - according to cost.")]
        public void LinqQuery06()
        {
            var fruitsGroups =
            from product in products
            group product by product.Category into categoryGroup
            select
                new
                {
                    category = categoryGroup.Key,
                    StockGroups =
                         from product in categoryGroup
                         group product by product.UnitsInStock into stockGroup
                         select
                             new
                             {
                                 stock = stockGroup.Key,
                                 PriceGroups =
                                      from product in stockGroup
                                      group product by product.UnitPrice into PriceGroup
                                      select new { PriceKey = PriceGroup.Key,
                                                   ProductName =
                                                        from product in PriceGroup
                                                        select product.ProductName
                                                 }
                             }
                };

            ObjectDumper.Write(fruitsGroups, 3);
        }

        [Category("Task13")]
        [Title("07")]
        [Description("Group all products into groups of “cheap”, “average price”, “expensive”, " +
            "defining the boundaries of each group in an arbitrary way.")]
        public void LinqQuery07()
        {
            var productsGroups =
                from product in products
                group product by GetPriceGroup(product, 50, 150) into priceGroup
                select new { priceGroup.Key, priceGroup };
            
            ObjectDumper.Write(productsGroups, 1);
        }

        [Category("Task13")]
        [Title("08")]
        [Description("Calculate the average order amount for all customers from a given city and the " +
            "average number of orders per customer from each city.")]
        public void LinqQuery08()
        {
            var categories =
                 from customer in customers
                 from order in customer.Orders
                 group new {customer, order} by customer.City into cityGroup
                 select new
                 {
                     City = cityGroup.Key,
                     AverageOrder = cityGroup.Average(cg => cg.order.Total),
                     AverageOrdersOfCustomers = (double)cityGroup.Select(x => x.order.OrderID).Distinct().Count()
                                                / cityGroup.Select(x => x.customer.CustomerID).Distinct().Count()
                 };

            ObjectDumper.Write(categories, 1);
        }

        [Category("Task13")]
        [Title("09_1")]
        [Description("Display categories of products in which all products are in the stock.")]
        public void LinqQuery09_1()
        {
            var productGroups = products.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0));

            ObjectDumper.Write(productGroups, 1);
        }

        [Category("Task13")]
        [Title("09_2")]
        [Description("Withdraw customers from Italy and sort them by city.")]
        public void LinqQuery09_2()
        {
            var italyCustomers = customers.Where(c => c.Country == "Italy").OrderBy(x => x.City);

            foreach (var c in italyCustomers)
            {
                Console.WriteLine($"{c.CompanyName} - {c.Country} - {c.City}.");
            }
        }

        [Category("Task13")]
        [Title("09_3")]
        [Description("Sort customers by the total amount of orders and group them by country. " +
            "Withdraw the first three customers from each country.")]
        public void LinqQuery09_3()
        {
            var customerList =
                from customer in customers
                let ordersSum = customer.Orders.Sum(o => o.Total)
                orderby ordersSum
                group customer by customer.Country into CustomerGroup
                select new { CustomerGroup.Key, c = CustomerGroup.Take(3) };

            ObjectDumper.Write(customerList, 1);
        }

        [Category("Task13")]
        [Title("09_4")]
        [Description("Gets all products from the Seafood category and sort them by price in descending order.")]
        public void LinqQuery09_4()
        {
            var seafoodProducts = products.Where(p => p.Category == "Seafood").OrderByDescending(p => p.UnitPrice);

            foreach (var sp in seafoodProducts)
            {
                Console.WriteLine($"{sp.ProductName} - {sp.UnitPrice}.");
            }
        }

        [Category("Task13")]
        [Title("09_5")]
        [Description("Gets suppliers from Germany, sort them by name and group by city.")]
        public void LinqQuery09_5()
        {
            var supplierList = suppliers.Where(s => s.Country == "Germany").OrderBy(s => s.SupplierName).GroupBy(s => s.City);

            ObjectDumper.Write(supplierList, 1);
        }

        private static string GetPriceGroup(LinqSamples.Product product, decimal cheapLimit, decimal expensiveLimit)
        {
            if (product.UnitPrice < cheapLimit)
            {
                return "cheap";
            }
            else if (product.UnitPrice < expensiveLimit)
            {
                return "average price";
            }
            else
            {
                return "expensive";
            }
        }
    }
}
