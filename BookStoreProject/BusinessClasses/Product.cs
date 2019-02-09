using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookStoreProject.BusinessClasses
{
    public class Product
    {

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }

        public Product(int id)
        {
            Id = id;
            switch (id) {
                case 1:
                    this.Price = 73.95m;
                    this.Title = "Applying UML and Patterns - An Introduction to Object-Oriented Analysis and Design, and the Unifield Process";
                    this.ISBN = "0130925691";
                    this.Publisher = "Prentice Hall";
                    this.Author = "Craig Larman";
                    break;
                case 2:
                    this.Price = 75.00m;
                    this.Title = "Design patterns:Elements of Reusable Object-Oriented Software";
                    this.ISBN = "0201633612";
                    this.Publisher = "Addison-Wesley Professional";
                    this.Author = "Erich Gamma, Richard Helm,Ralph Johnson, John Vlissides";
                    break;
                case 3:
                    this.Price = 67.50m;
                    this.Title = "Refactoring-Improving the Design of Existing Code";
                    this.ISBN = "0201485672";
                    this.Publisher = "Addison-Wesley Professional";
                    this.Author = "Martin Fowler, Kent Beck, John Brant, William Opdyke, Don Roberts";
                    break;
                case 4:
                    this.Price = 73.95m;
                    this.Title = "Obejct Design - Roles, Responsibilities, and Collaborations";
                    this.ISBN = "0201379430";
                    this.Publisher = "Addison-Wesley Professional";
                    this.Author = "Rebecca Wirfs-Brock,Alan McKean";
                    break;
            }
        }
    }

    public class ProductCollection : List<Product> {

    }

    public class Products {
        public static ProductCollection LoadAll(string sortExpression) {
            ProductCollection col1 = new ProductCollection();

            col1.Add(new Product(1));
            col1.Add(new Product(2));
            col1.Add(new Product(3));
            col1.Add(new Product(4));

            col1.Sort(new GenericComparer<Product>(sortExpression, GenericComparer<Product>.SortOrder.Ascending));

            return col1;
        }

        

    }

    public sealed class GenericComparer<T>:IComparer<T> {
        public enum SortOrder { Ascending, Descending};

        #region member variables;
        private string sortColumn;
        private SortOrder sortingOrder;
        #endregion

        #region constructor

        public GenericComparer(string sortColumn, SortOrder sortingOrder)
        {

            this.sortColumn = sortColumn;

            this.sortingOrder = sortingOrder;

        }

        #endregion

        #region public property

        /// <summary> 

        /// Column Name(public property of the class) to be sorted. 

        /// </summary> 

        public string SortColumn
        {

            get { return sortColumn; }

        }



        /// <summary> 

        /// Sorting order. 

        /// </summary> 

        public SortOrder SortingOrder
        {

            get { return sortingOrder; }

        }

        #endregion

        #region public methods

        /// <summary> 

        /// Compare interface implementation 

        /// </summary> 

        /// <param name="x">custom Object</param> 

        /// <param name="y">custom Object</param> 

        /// <returns>int</returns> 

        public int Compare(T x, T y)
        {

            PropertyInfo propertyInfo = typeof(T).GetProperty(sortColumn);

            IComparable obj1 = (IComparable)propertyInfo.GetValue(x, null);

            IComparable obj2 = (IComparable)propertyInfo.GetValue(y, null);

            if (sortingOrder == SortOrder.Ascending)
            {

                return (obj1.CompareTo(obj2));

            }

            else
            {

                return (obj2.CompareTo(obj1));

            }

        }

        #endregion


    }
}