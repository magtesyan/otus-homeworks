using bd.Models;

Console.WriteLine("Hello, World!");




IEnumerable<Customer> customers = bd.DapperRepository.GetCustomers(2);

//foreach (var item in customers)
//{
//    PrintCustomer(item);
//}

IEnumerable<Order> orders = bd.DapperRepository.GetOrders(2);

IEnumerable<Product> products = bd.DapperRepository.GetProducts(412);

foreach (var item in products)
{
    PrintProduct(item);
}



static void PrintCustomer(bd.Models.Customer customer)
{
    Console.WriteLine($"{customer.Id}\t {customer.FirstName} \t{customer.LastName} \t{customer.Age}");
}

static void PrintProduct(bd.Models.Product product)
{
    Console.WriteLine($"{product.Id}\t {product.Name} \t{product.Price}");
}



