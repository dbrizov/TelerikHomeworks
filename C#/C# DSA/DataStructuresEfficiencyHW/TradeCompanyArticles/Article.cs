using System;

namespace TradeCompanyArticles
{
    public class Article : IComparable
    {
        public string Barcode { get; private set; }
        public string Vendor { get; private set; }
        public string Title { get; private set; }
        public double Price { get; private set; }

        public Article(string barcode, string vendor, string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Article objAsArticle = obj as Article;
            if (objAsArticle == null)
            {
                return false;
            }

            if (this.Barcode != objAsArticle.Barcode)
            {
                return false;
            }

            if (this.Vendor != objAsArticle.Vendor)
            {
                return false;
            }

            if (this.Title != objAsArticle.Title)
            {
                return false;
            }

            if (Math.Abs(this.Price - objAsArticle.Price) < 0.0001)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Barcode.GetHashCode() ^
                   this.Vendor.GetHashCode() ^
                   this.Title.GetHashCode() ^
                   this.Price.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Barcode: {0}, Vendor: {1}, Title: {2}, Price: {3:f2}",
                this.Barcode, this.Vendor, this.Title, this.Price);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Can't compare null objects");
            }

            Article objAsArticle = obj as Article;
            if (objAsArticle == null)
            {
                throw new ArgumentException("Can't cast the given object to an Article");
            }

            return this.Price.CompareTo(objAsArticle.Price);
        }
    }
}
