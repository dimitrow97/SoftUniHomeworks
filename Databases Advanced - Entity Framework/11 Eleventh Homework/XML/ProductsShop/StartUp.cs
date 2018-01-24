namespace ProductsShop
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Model;

    public class Application
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
                        
            //Import the data into the DB
            ImportUsers(context);
            ImportCategories(context);
            ImportProducts(context);

            //Run the methods to get the XML files in the ProductsShop.App folder
            ProductsInRange(context);
            SoldProducts(context);
            CategoriesByProduct(context);
            UsersAndProducts(context);
            
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            XDocument soldProductsDoc = new XDocument();
            XElement usersTag = new XElement("users");
            usersTag.SetAttributeValue("count", context.Users.Where(x => x.ProductsSold.Count() > 0).Count());

            foreach (var user in context.Users.Where(x => x.ProductsSold.Count() > 0).OrderByDescending(x => x.ProductsSold.Count()).ThenBy(x => x.LastName))
            {
                XElement userTag = new XElement("user");
                userTag.SetAttributeValue("first-name", user.FirstName);
                userTag.SetAttributeValue("last-name", user.LastName);
                userTag.SetAttributeValue("age", user.Age);
                XElement soldProduct = new XElement("sold-products");
                soldProduct.SetAttributeValue("count", user.ProductsSold.Count());
                
                foreach (var productSold in context.Products.Where(x => x.SelledId == user.Id))
                {
                    XElement product = new XElement("product");
                    product.SetAttributeValue("name", productSold.Name);
                    product.SetAttributeValue("price", productSold.Price);
                    soldProduct.Add(product);
                }                
                userTag.Add(soldProduct);
                usersTag.Add(userTag);
            }
            soldProductsDoc.Add(usersTag);
            soldProductsDoc.Save(@"../../Query4 - ProductsShop.xml");
        }

        private static void CategoriesByProduct(ProductShopContext context)
        {
            XDocument catByProDoc = new XDocument();
            XElement categoriesTag = new XElement("categories");

            foreach(var category in context.Categories.Where(x => x.Products.Count() > 0).OrderBy(x => x.Products.Count()))
            {
                XElement categoryTag = new XElement("category");
                categoryTag.SetAttributeValue("name", category.Name);
                XElement productsCount = new XElement("products-count");
                productsCount.Value = category.Products.Count().ToString();
                XElement avgPrice = new XElement("average-price");
                avgPrice.Value = category.Products.Average(x => x.Price).ToString();
                XElement totalRevenue = new XElement("total-revenue");
                totalRevenue.Value = category.Products.Sum(x => x.Price).ToString();
                categoryTag.Add(productsCount);
                categoryTag.Add(avgPrice);
                categoryTag.Add(totalRevenue);
                categoriesTag.Add(categoryTag);
            }
            catByProDoc.Add(categoriesTag);
            catByProDoc.Save(@"../../Query3 - ProductsShop.xml");
        }

        private static void SoldProducts(ProductShopContext context)
        {
            XDocument soldProductsDoc = new XDocument();
            XElement usersTag = new XElement("users");

            foreach(var user in context.Users.Where(x => x.ProductsSold.Count() > 0).OrderBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                XElement userTag = new XElement("user");
                userTag.SetAttributeValue("first-name", user.FirstName);
                userTag.SetAttributeValue("last-name", user.LastName);
                XElement soldProduct = new XElement("sold-products");
                XElement product = new XElement("product");                
                foreach (var productSold in context.Products.Where(x => x.SelledId == user.Id))
                {
                    XElement productName = new XElement("name");
                    productName.Value = productSold.Name;
                    XElement productPrice = new XElement("price");
                    productPrice.Value = productSold.Price.ToString();
                    product.Add(productName);
                    product.Add(productPrice);                    
                }
                soldProduct.Add(product);
                userTag.Add(soldProduct);
                usersTag.Add(userTag);
            }            
            soldProductsDoc.Add(usersTag);
            soldProductsDoc.Save(@"../../Query2 - ProductsShop.xml");
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            XDocument productsDoc = new XDocument();
            XElement productsTag = new XElement("products");

            foreach(var product in context.Products.Where(x => x.Price >= 1000 && x.Price <= 2000 && x.BuyerId != null).OrderBy(x => x.Price))
            {
                XElement productTag = new XElement("product");
                productTag.SetAttributeValue("name", product.Name);
                productTag.SetAttributeValue("price", product.Price);
                productTag.SetAttributeValue("buyer", String.Join(" ", product.Buyer.FirstName ,product.Buyer.LastName));
                productsTag.Add(productTag);
            }
            productsDoc.Add(productsTag);
            productsDoc.Save(@"../../Query1 - ProductsShop.xml");
        }

        private static void ImportProducts(ProductShopContext context)
        {
            XDocument productsDoc = XDocument.Load(@"../../Imports/products.xml");
            XElement productsRoot = productsDoc.Root;
            Random rnd = new Random();
            int num = 0;

            foreach (var product in productsRoot.Elements())
            {
                string name = product.Element("name")?.Value;
                decimal price = decimal.Parse(product.Element("price")?.Value);

                if (num % 4 != 0)
                {
                    Product productImp = new Product()
                    {
                        Name = name,
                        Price = price,
                        BuyerId = rnd.Next(1, context.Users.Count()),
                        SelledId = rnd.Next(1, context.Users.Count()),
                    };
                    context.Products.Add(productImp);
                }
                else
                {
                    Product productImp = new Product()
                    {
                        Name = name,
                        Price = price,
                        BuyerId = null,
                        SelledId = rnd.Next(1, context.Users.Count()),
                    };
                    context.Products.Add(productImp);
                }
                num++;
            }
            context.SaveChanges();

            foreach (var product in context.Products)
            {
                for (int i = 0; i < rnd.Next(1, 4); i++)
                {
                    int random = rnd.Next(1, context.Categories.Count());
                    var category = context.Categories.Where(x => x.Id == random);
                    foreach (var cat in category)
                    {
                        product.Categories.Add(cat);
                    }
                }
            }
            context.SaveChanges();
        }

        private static void ImportCategories(ProductShopContext context)
        {
            XDocument categoriesDoc = XDocument.Load(@"../../Imports/categories.xml");
            XElement categoriesRoot = categoriesDoc.Root;

            foreach(var category in categoriesRoot.Elements())
            {
                string name = category.Element("name")?.Value;

                Category categoryImp = new Category()
                {
                    Name = name                    
                };
                context.Categories.Add(categoryImp);
            }
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            XDocument userDoc = XDocument.Load(@"../../Imports/users.xml");
            XElement usersRoot = userDoc.Root;

            foreach (var user in usersRoot.Elements())
            {
                string firstName = user.Attribute("first-name")?.Value;
                string lastName = user.Attribute("last-name")?.Value;
                try
                {
                    int age = int.Parse(user.Attribute("age")?.Value);
                    User userImp = new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    };
                    context.Users.Add(userImp);
                }
                catch
                {
                    User userImp = new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = null
                    };
                    context.Users.Add(userImp);
                }
                
            }
            context.SaveChanges();
        }
    }
}
