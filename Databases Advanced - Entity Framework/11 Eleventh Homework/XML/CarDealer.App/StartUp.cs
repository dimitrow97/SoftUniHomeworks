namespace CarDealer.App
{
    using System;

    using Data;
    using Models;
    using System.Xml.Linq;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //Import the data into the DB
            ImportSuppliers(context);
            ImportParts(context);
            ImportCars(context);
            ImportCustomer(context);
            ImportSales(context);

            //Run the methods to get the XML files in the CarDealer.App folder
            CarsToXML(context);
            CarsFromMakeFerrari(context);
            LocalSuppliers(context);
            CarsWithTheirParts(context);
            TotalSalesByCustomer(context);
            SalesWithAppliedDiscount(context);            
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            XDocument salesXml = new XDocument();
            XElement salesTag = new XElement("sales");

            foreach (var sale in context.Sales)
            {
                XElement saleTag = new XElement("sale");
                XElement carTag = new XElement("car");
                carTag.SetAttributeValue("make", sale.Car.Make);
                carTag.SetAttributeValue("model", sale.Car.Model);
                carTag.SetAttributeValue("travelled-distance", sale.Car.TravelledDistance);
                XElement customerTag = new XElement("customer-name");
                customerTag.Value = sale.Customer.Name;
                XElement discountTag = new XElement("discount");
                discountTag.Value = sale.Discount.ToString();
                XElement priceTag = new XElement("price");
                priceTag.Value = sale.Car.Parts.Sum(e => e.Price).ToString();
                XElement priceWithDiscountTag = new XElement("price-with-discount");
                priceWithDiscountTag.Value = (sale.Car.Parts.Sum(e => e.Price) - (sale.Car.Parts.Sum(e => e.Price)*sale.Discount)).ToString();
                saleTag.Add(carTag);
                saleTag.Add(customerTag);
                saleTag.Add(discountTag);
                saleTag.Add(priceTag);
                saleTag.Add(priceWithDiscountTag);
                salesTag.Add(saleTag);
            }            
            salesXml.Add(salesTag);
            salesXml.Save(@"../../Query6 - CarDealer.xml");
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            XDocument salesByCustomer = new XDocument();
            XElement customersTag = new XElement("customers");

            foreach(var customer in context.Customers.Where(x => x.Sales.Count() > 0).OrderByDescending(c => c.Sales.Sum(y => y.Car.Parts.Sum(e => e.Price))))
            {
                XElement customerTag = new XElement("customer");
                customerTag.SetAttributeValue("full-name", customer.Name);
                customerTag.SetAttributeValue("bought-cars", customer.Sales.Count());
                customerTag.SetAttributeValue("spent-money", customer.Sales.Sum(y => y.Car.Parts.Sum(e => e.Price)));
                customersTag.Add(customerTag);
            }
            salesByCustomer.Add(customersTag);
            salesByCustomer.Save(@"../../Query5 - CarDealer.xml");
        }

        private static void CarsWithTheirParts(CarDealerContext context)
        {
            XDocument carsAndTheirParts = new XDocument();
            XElement carsTag = new XElement("cars");
            foreach(var car in context.Cars)
            {
                XElement carTag = new XElement("car");
                XElement partsTag = new XElement("parts");
                carTag.SetAttributeValue("make", car.Make);
                carTag.SetAttributeValue("model", car.Model);
                carTag.SetAttributeValue("travelled-distance", car.TravelledDistance);
                foreach (var part in context.Parts.Where(c => c.Cars.Any(y => y.Id == car.Id)))
                {
                    XElement partTag = new XElement("part");
                    partTag.SetAttributeValue("name", part.Name);
                    partTag.SetAttributeValue("price", part.Price);
                    partsTag.Add(partTag);
                }
                carTag.Add(partsTag);
                carsTag.Add(carTag);
            }
            carsAndTheirParts.Add(carsTag);
            carsAndTheirParts.Save(@"../../Query4 - CarDealer.xml");
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers.Where(s => s.IsImporter == false).ToList();

            XDocument localSuppliersXml = new XDocument();
            XElement localSuppliersTag = new XElement("suppliers");

            foreach(var supplier in localSuppliers)
            {
                XElement supplierTag = new XElement("supplier");
                supplierTag.SetAttributeValue("id", supplier.Id);
                supplierTag.SetAttributeValue("name", supplier.Name);
                supplierTag.SetAttributeValue("parts-count", supplier.Parts.Count());

                localSuppliersTag.Add(supplierTag);
            }
            localSuppliersXml.Add(localSuppliersTag);
            localSuppliersXml.Save(@"../../Query3 - CarDealer.xml");
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            var ferrariCars = context.Cars.Where(c => c.Make == "Ferrari").OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance).ToList();

            XDocument ferrariCarsDoc = new XDocument();
            XElement carsXml = new XElement("cars");

            foreach(var ferrari in ferrariCars)
            {
                XElement car = new XElement("car");
                car.SetAttributeValue("id", ferrari.Id);
                car.SetAttributeValue("model", ferrari.Model);
                car.SetAttributeValue("travelled-distance", ferrari.TravelledDistance);
                carsXml.Add(car);
            }
            ferrariCarsDoc.Add(carsXml);
            ferrariCarsDoc.Save(@"../../Query2 - CarDealer.xml");
        }

        private static void CarsToXML(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.TravelledDistance > 2000000).OrderBy(c => c.Make).ThenBy(c => c.Model).ToList();

            XDocument carsToXmlDoc = new XDocument();
            XElement carsXml = new XElement("cars");

            foreach (var car in cars)
            {
                XElement carXml = new XElement("car");
                XElement make = new XElement("make");
                make.Value = car.Make;
                XElement model = new XElement("model");
                model.Value = car.Model;
                XElement distTrv = new XElement("travelled-distance");
                distTrv.Value = car.TravelledDistance.ToString();
                                
                carXml.Add(make);
                carXml.Add(model);
                carXml.Add(distTrv);
                carsXml.Add(carXml);
            }
            carsToXmlDoc.Add(carsXml);
            carsToXmlDoc.Save(@"../../Query1 - CarDealer.xml");
        }

        private static void ImportSales(CarDealerContext context)
        {
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();
            Random rnd = new Random();

            for(int i = 0; i < 100; i++)
            {
                Sale saleImp = new Sale()
                {
                    CarId = rnd.Next(1, carsCount + 1),
                    CustomerId = rnd.Next(1, customersCount + 1),
                    Discount = i % 2 == 0 ? 0.5M : 0.00M
                };
                context.Sales.Add(saleImp);
            }
            context.SaveChanges();
        }

        private static void ImportCustomer(CarDealerContext context)
        {
            XDocument customersDoc = XDocument.Load(@"../../Imports/customers.xml");
            XElement customersRoot = customersDoc.Root;

            foreach(var customer in customersRoot.Elements())
            {
                string name = customer.Attribute("name")?.Value;
                DateTime birthDate = DateTime.Parse(customer.Element("birth-date")?.Value);
                bool isYoungDriver = bool.Parse(customer.Element("is-young-driver")?.Value);

                Customer customerImp = new Customer()
                {
                    Name = name,
                    BirthDate = birthDate,
                    IsYoungDriver = isYoungDriver
                };
                context.Customers.Add(customerImp);
            }
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context)
        {
            XDocument carsDoc = XDocument.Load(@"../../Imports/cars.xml");
            XElement carsRoot = carsDoc.Root;
            int partsCount = context.Parts.Count();

            foreach(var car in carsRoot.Elements())
            {
                string make = car.Element("make")?.Value;
                string model = car.Element("model")?.Value;
                long trvldDist = long.Parse(car.Element("travelled-distance")?.Value);

                Car carImp = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = trvldDist
                };

                for(int i = 0; i < 10 + (i % 10); i++)
                {
                    Part part = context.Parts.Find(((car.GetHashCode() + i) % partsCount) + 1);
                    carImp.Parts.Add(part);
                }
                context.Cars.Add(carImp);
            }
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            XDocument partsDoc = XDocument.Load(@"../../Imports/parts.xml");
            XElement partsRoot = partsDoc.Root;
            int suppliersCount = context.Suppliers.Count();
            int num = 0;

            foreach (var part in partsRoot.Elements())
            {
                string name = part.Attribute("name")?.Value;
                decimal price = decimal.Parse(part.Attribute("price")?.Value);
                int quantity = int.Parse(part.Attribute("quantity")?.Value);

                Part partImp = new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    SupplierId = (num % suppliersCount) + 1
                };
                context.Parts.Add(partImp);
                num++;
            }
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            XDocument suppliersDoc = XDocument.Load(@"../../Imports/suppliers.xml");
            XElement suppliersRoot = suppliersDoc.Root;

            foreach(var supplier in suppliersRoot.Elements())
            {
                string name = supplier.Attribute("name")?.Value;
                bool isImporter = bool.Parse(supplier.Attribute("is-importer")?.Value);

                Supplier sup = new Supplier()
                {
                    Name = name,
                    IsImporter = isImporter
                };

                context.Suppliers.Add(sup);
            }
            context.SaveChanges();
        }
    }
}
