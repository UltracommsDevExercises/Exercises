using System;
using System.Collections.Generic;
using System.Data;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 2");

            DataTable result = InnerJoin(GetLeftTable(), GetRightTable(), "Id");
            Console.WriteLine("Result table has " + result.Rows.Count + " rows");
            Console.ReadLine();
        }


        /// <summary>
        /// TODO: This method is a simple, and very manual implementation of an inner join.
        /// Can you add some comments on it?
        /// - How efficient is it?
        /// - How would it perform with very large input tables?
        /// - Can it be improved?
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="joincolumn"></param>
        /// <returns></returns>
        public static DataTable InnerJoin(DataTable left, DataTable right, string joincolumn)
        {
            DataTable result = new DataTable();
            
            foreach(DataColumn col in left.Columns)
            {
                result.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach(DataColumn col in right.Columns)
            {
                if (col.ColumnName != joincolumn)
                {
                    result.Columns.Add(col.ColumnName, col.DataType);
                }
            }

            foreach(DataRow leftrow in left.Rows)
            {                
                var keyItem = leftrow[joincolumn];
                foreach(DataRow rightrow in right.Rows)
                {
                    List<object> items = new List<object>();                    
                    if (rightrow[joincolumn].Equals(keyItem))
                    {
                        foreach(DataColumn col in left.Columns)
                        {
                            items.Add(leftrow[col.ColumnName]);
                        }
                        foreach(DataColumn col in right.Columns)
                        {
                            if (col.ColumnName != joincolumn)
                            {
                                items.Add(rightrow[col.ColumnName]);
                            }
                        }

                        result.Rows.Add(items.ToArray());
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// This is a simple method to get some rows in a table without any data source
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLeftTable()
        {
            DataTable left = new DataTable();
            left.Columns.Add("Id");
            left.Columns.Add("Value");

            left.Rows.Add(new object[2] { 10, "Test1"});
            left.Rows.Add(new object[2] { 2, "Test2" });

            return left;
        }

        /// <summary>
        /// This is a simple method to get some rows in a table without any data source
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRightTable()
        {
            DataTable right = new DataTable();
            right.Columns.Add("Id");
            right.Columns.Add("ExtraValue");

            right.Rows.Add(new object[2] { 10, "Extra1-1" });
            right.Rows.Add(new object[2] { 10, "Extra1-2" });
            right.Rows.Add(new object[2] { 10, "Extra1-3" });
            right.Rows.Add(new object[2] { 6, "Extra6-1" });
            right.Rows.Add(new object[2] { 2, "Extra2-1" });
            right.Rows.Add(new object[2] { 2, "Extra2-2" });
            right.Rows.Add(new object[2] { 2, "Extra2-3" });

            return right;
        }
    }
}
