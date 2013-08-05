using System;
using System.Data.SqlClient;

namespace AddProduct
{
    class Program
    {
        static void AddProduct(
            SqlConnection sqlDBCon,
            string name,
            int? supplierID,
            int? categoryID,
            string quantityPerUnit,
            decimal? unitPrice,
            int? unitsInStock,
            int? unitsOnOrder,
            int? reorderLevel,
            bool discontinued)
        {
            string queryText =
                "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "Values (@name, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, " +
                "@unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

            SqlCommand cmdAddProduct = new SqlCommand(queryText, sqlDBCon);

            cmdAddProduct.Parameters.AddWithValue("@name", name);

            SqlParameter supplierIDParam = new SqlParameter("@supplierID", supplierID);
            if (supplierID == null)
            {
                supplierIDParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(supplierIDParam);

            SqlParameter categoryIDParam = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                categoryIDParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(categoryIDParam);

            SqlParameter quantityPerUnitParam = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                quantityPerUnitParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(quantityPerUnitParam);

            SqlParameter unitPriceParam = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                unitPriceParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(unitPriceParam);

            SqlParameter unitsInStockParam = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                unitsInStockParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(unitsInStockParam);

            SqlParameter unitsOnOrderParam = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                unitsOnOrderParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(unitsOnOrderParam);

            SqlParameter reorderLevelParam = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                reorderLevelParam.Value = DBNull.Value;
            }

            cmdAddProduct.Parameters.Add(reorderLevelParam);

            cmdAddProduct.Parameters.AddWithValue("@discontinued", discontinued);

            cmdAddProduct.ExecuteNonQuery();
        }

        static void Main(string[] args)
        {
            const string ConnectionString =
                "Server=localhost; Database=Northwind; Integrated Security=true";

            SqlConnection sqlDBCon = new SqlConnection(ConnectionString);
            sqlDBCon.Open();

            using (sqlDBCon)
            {
                AddProduct(sqlDBCon, "Coca-Cola", 1, 1, "5 x (5x5)cartridges", 27.99m, 1, 10, 10, true);
            }
        }
    }
}
