﻿
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

namespace SupplementMall
{
    internal class DataBaseOperations
    {
        private static readonly SqlCeConnection Connection =
            new SqlCeConnection("Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                Path.DirectorySeparatorChar + "DataBase" + Path.DirectorySeparatorChar + "Database.sdf");

        #region Customers
        public static bool InsertIntoCustomers(string name, string phone, List<byte[]> lstFingerPrints)
        {
            try
            {
                Connection.Open();
                var cmdInsert =
                    new SqlCeCommand(
                        "INSERT INTO Customers(Name,Phone,Date,FingerPrint1,FingerPrint2,FingerPrint3,FingerPrint4,FingerPrint5,FingerPrint6,IsDeleted) " +
                        "VALUES(@name,@phone,@Date,@fingerPrint1,@fingerPrint2,@fingerPrint3,@fingerPrint4,@fingerPrint5,@fingerPrint6,@isDeleted)",
                        Connection);
                cmdInsert.Parameters.AddWithValue("@name", name);
                cmdInsert.Parameters.AddWithValue("@phone", phone);
                cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@fingerPrint1", lstFingerPrints[0]);
                cmdInsert.Parameters.AddWithValue("@fingerPrint2", lstFingerPrints[1]);
                cmdInsert.Parameters.AddWithValue("@fingerPrint3", lstFingerPrints[2]);
                cmdInsert.Parameters.AddWithValue("@fingerPrint4", lstFingerPrints[3]);
                cmdInsert.Parameters.AddWithValue("@fingerPrint5", lstFingerPrints[4]);
                cmdInsert.Parameters.AddWithValue("@fingerPrint6", lstFingerPrints[5]);
                cmdInsert.Parameters.AddWithValue("@isDeleted", false);
                cmdInsert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : inserting into customers failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool UpdateCustomer(int id, string name, string phone, DateTime date)
        {
            try
            {
                Connection.Open();
                var cmdUpdate =
                    new SqlCeCommand("UPDATE Customers SET Name = @name, Phone = @phone, Date = @date WHERE ID=@id", Connection);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.Parameters.AddWithValue("@name", name);
                cmdUpdate.Parameters.AddWithValue("@phone", phone);
                cmdUpdate.Parameters.AddWithValue("@date", date);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : update customer failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteFromCustomers(int id)
        {
            try
            {
                Connection.Open();
                var cmdUpdate = new SqlCeCommand("UPDATE Customers SET IsDeleted = @isDeleted WHERE ID = @id", Connection);
                cmdUpdate.Parameters.AddWithValue("@isDeleted", true);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : Delete customer failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }

        public static DataTable GetAllDataFromCustomers()
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE IsDeleted = '{0}'", false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                const string errorMessage = "database error : get all customers data failed";
                Logger.LogException(exception, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataTable SerachCustomersTableForValue(string field, string fieldValue)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE {0} = '{1}' AND IsDeleted = '{2}'", field, fieldValue, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                var errorMessage = "database error : serach customers data failed were field = " + field + " and Value = " + fieldValue;
                Logger.LogException(exception, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataTable SerachCustomersTableForDate(DateTime from, DateTime to)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE (Date BETWEEN '{0}' AND '{1}') AND IsDeleted = '{2}'", from, to, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                var errorMessage = "database error : serach customers data failed were time from is = " + from + " and time to is = " + to;
                Logger.LogException(exception, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataRow GetCustomerInfo(int id)
        {
            try
            {

                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Customers WHERE ID = '{0}' ", id), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : get customer data failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }
        #endregion

        #region Users
        public static bool InsertIntoUsers(string name, string username, string password, bool isAdmin, string email)
        {
            try
            {
                Connection.Open();
                var cmdInsert =
                    new SqlCeCommand(
                        "INSERT INTO Users(Name,UserName,Password,IsAdmin,Email) VALUES(@name,@username,@password,@isAdmin,@email)",
                        Connection);
                cmdInsert.Parameters.AddWithValue("@name", name);
                cmdInsert.Parameters.AddWithValue("@username", username);
                cmdInsert.Parameters.AddWithValue("@password", password);
                cmdInsert.Parameters.AddWithValue("@isAdmin", isAdmin);
                cmdInsert.Parameters.AddWithValue("@email", email);
                cmdInsert.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : insert into users failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool UpdateUser(int id, string name, string username, string password, bool isAdmin, string email)
        {
            try
            {
                Connection.Open();
                var cmdUpdate =
                    new SqlCeCommand("UPDATE Users SET Name=@name, UserName=@username, " +
                                     "Password=@password, IsAdmin=@isAdmin, Email=@email" +
                                     " WHERE ID=@id", Connection);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.Parameters.AddWithValue("@name", name);
                cmdUpdate.Parameters.AddWithValue("@username", username);
                cmdUpdate.Parameters.AddWithValue("@password", password);
                cmdUpdate.Parameters.AddWithValue("@isAdmin", isAdmin);
                cmdUpdate.Parameters.AddWithValue("@email", email);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : update users failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteFromUsers(int id)
        {
            try
            {
                Connection.Open();
                var cmdDelete = new SqlCeCommand("DELETE FROM Users WHERE ID = @id", Connection);
                cmdDelete.Parameters.AddWithValue("@id", id);
                cmdDelete.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : delete user failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static DataTable GetAllDataFromUsers()
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter("SELECT * FROM Users", Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                const string errorMessage = "database error : get all users failed";
                Logger.LogException(exception, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }

        public static DataRow IsValidUser(string userName, string password)
        {
            try
            {
            
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE UserName = '{0}' AND Password = '{1}'",userName,password), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : validating user failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }

        public static DataRow GetUserInfo(int id)
        {
            try
            {
            
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE ID = '{0}' ",id), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                const string errorMessage = "database error : get user info failed";
                Logger.LogException(ex, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return null;
        }

        public static DataTable SerachUsersTableForValue(string field, string fieldValue)
        {
            try
            {
                Connection.Open();
                var dataAdapter = new SqlCeDataAdapter(string.Format("SELECT * FROM Users WHERE {0} = '{1}'", field, fieldValue, false), Connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (SqlCeException exception)
            {
                var errorMessage = "database error : search users failed where field = " + field + " and value = " + fieldValue;
                Logger.LogException(exception, errorMessage);
                MessageBox.Show(errorMessage, "Error!");
            }
            finally
            {
                Connection.Close();
            }
            return new DataTable();
        }
        #endregion
    }
}
