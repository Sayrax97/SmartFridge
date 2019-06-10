using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace WcfSmartFridge
{
    public class Service1 : IService1
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["SmartFridge2_0ConnectionString"].ConnectionString.ToString();
        static SqlConnection con = new SqlConnection(connectionString);
        static SqlConnection con1 = new SqlConnection(connectionString);

        static List<PasswordVerification> listPasswordVerificaton = new List<PasswordVerification>();


        public int dbAddGroup(GroupDetails id)
        {
            int a = 0;
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into [Group] (ID) VALUES (@ID)", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id.ID;
            a = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            return a;
        }

        public int dbAddToGroup(string userNickname, string GroupID)
        {
            if (dbGroupExists(GroupID) == true)
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET GroupID=@ID WHERE Nickname=@Nickname", con);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = GroupID;
                cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = userNickname;
                int test = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            return 0;
        }

        public void dbDeleteAvailableGroceries(string Name, string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [AvailableGroceries] WHERE GroceryName=@Name AND GroupID=@id", con);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = Name;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbDeleteGroup(string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Group] WHERE ID=@ID", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void dbDeleteShoppingCart(string Name, string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [ShoppingCart] WHERE GroceryName=@Name AND GroupID=@id", con);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = Name;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbDeleteUser(string userNickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE ID=@ID", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = userNickname;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public UserDetails dbFindUser(string userNickname,string passord)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = userNickname;
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                UserDetails user = new UserDetails();
                user.Name = reader.GetValue(0).ToString();
                user.Surname = reader.GetValue(1).ToString();
                user.Password = reader.GetValue(2).ToString();
                if (CryptoService.VerifyMd5Hash(CryptoService.returnMD5(),passord,user.Password) == false) {
                    user.Password = null;
                }
                user.UserName = reader.GetValue(3).ToString();
                user.Status = reader.GetValue(4).ToString();
                user.Email = reader.GetValue(5).ToString();
                user.MyGroup = reader.GetValue(7).ToString();
                if (reader.GetValue(6) == DBNull.Value)
                    user.Image = null;
                else
                    user.Image = (byte[])reader.GetValue(6);
                reader.Close();
                cmd.Dispose();
                con.Close();
                return user;
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return null;
        }

        public bool dbFindUserBool(string userNickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = userNickname;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                reader.Close();
                cmd.Dispose();
                con.Close();
                return true;
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return false;

        }

        public List<AvailableGroceriesDetails> dbGetAvailableGroceries(string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<AvailableGroceriesDetails> listAvailableGroceries = new List<AvailableGroceriesDetails>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [AvailableGroceries] INNER JOIN [Groceries] ON AvailableGroceries.GroceryName=Groceries.Name WHERE GroupID=@id", con);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                AvailableGroceriesDetails availableGroceries = new AvailableGroceriesDetails();
                GroceryDetails grocery = new GroceryDetails();
                availableGroceries.Amount = float.Parse(reader.GetValue(0).ToString());
                availableGroceries.GroupID = reader.GetValue(2).ToString();
                grocery.Name = reader.GetValue(3).ToString();
                if (reader.GetValue(4) != null)
                    grocery.Image = Convert.FromBase64String(reader.GetValue(4).ToString());
                grocery.Unit = reader.GetValue(5).ToString();
                grocery.Category = reader.GetValue(6).ToString();
                availableGroceries.Grocery = grocery;
                listAvailableGroceries.Add(availableGroceries);
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return listAvailableGroceries;
        }

        public List<ContainsDetails> dbGetContains(int IdRecepta)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<ContainsDetails> listContainsDetails = new List<ContainsDetails>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Contain] INNER JOIN [Groceries] ON Contain.GroceryName=Groceries.Name WHERE RecipeID=@ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = IdRecepta;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                ContainsDetails contains = new ContainsDetails();
                GroceryDetails grocery = new GroceryDetails();
                contains.Amount = float.Parse(reader.GetValue(2).ToString());
                contains.RecipeID = int.Parse(reader.GetValue(1).ToString());
                grocery.Image = null;
                grocery.Name = reader.GetValue(3).ToString();
                grocery.Unit = reader.GetValue(5).ToString();
                grocery.Category = reader.GetValue(6).ToString();
                contains.Grocery = grocery;
                listContainsDetails.Add(contains);
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return listContainsDetails;
        }

        public List<GroceryDetails> dbGetgroceriesName()
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<GroceryDetails> lista = new List<GroceryDetails>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Groceries]", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                GroceryDetails grocery = new GroceryDetails();
                grocery.Name = reader.GetValue(0).ToString();
                grocery.Image = null;
                grocery.Unit = reader.GetValue(2).ToString();
                grocery.Category = reader.GetValue(3).ToString();
                lista.Add(grocery);
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return lista;
        }

        public OptionDetails dbGetOptions(string Nickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            OptionDetails option = new OptionDetails();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Option] WHERE UserNickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = Nickname;
            SqlDataReader reader = cmd.ExecuteReader();
            bool x = reader.Read();
            option.Theme = reader.GetValue(0).ToString();
            option.Font = reader.GetValue(1).ToString();
            option.Notification = bool.Parse(reader.GetValue(2).ToString());
            reader.Close();
            cmd.Dispose();
            con.Close();
            return option;
        }

        public List<ShoppingCartDetails> dbGetShoppingCart(string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<ShoppingCartDetails> listShoppingCartDetails = new List<ShoppingCartDetails>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [ShoppingCart] INNER JOIN [Groceries] ON ShoppingCart.GroceryName=Groceries.Name WHERE GroupID=@id", con);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ShoppingCartDetails shoppingCart = new ShoppingCartDetails();
                GroceryDetails grocery = new GroceryDetails();
                shoppingCart.Amount = float.Parse(reader.GetValue(0).ToString());
                shoppingCart.GroupID = reader.GetValue(2).ToString();
                grocery.Name = reader.GetValue(3).ToString();
                grocery.Image = null;
                grocery.Unit = reader.GetValue(5).ToString();
                grocery.Category = reader.GetValue(6).ToString();
                shoppingCart.Grocery = grocery;
                listShoppingCartDetails.Add(shoppingCart);
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return listShoppingCartDetails;

        }

        public bool dbGroupExists(string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Group] WHERE ID=@ID", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                reader.Close();
                cmd.Dispose();
                con.Close();
                return true;
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return false;
        }

        public List<string> dbInMyGroup(string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<string> listaZaSlanje = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT Nickname FROM [User] WHERE GroupID=@id", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                listaZaSlanje.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return listaZaSlanje;
        }

        public void dbInsertOptions(OptionDetails option)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Option] (Theme,Font,Notification,UserNickname) VALUES(@Theme,@Font,@Notification,@Nickname)", con);
            cmd.Parameters.Add("@Theme", SqlDbType.VarChar).Value = option.Theme;
            cmd.Parameters.Add("@Font", SqlDbType.VarChar).Value = option.Font;
            cmd.Parameters.Add("@Notification", SqlDbType.Bit).Value = option.Notification;
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = option.UserNickname;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void dbInsertShoppingCart(ShoppingCartDetails shoppingCart)
        {
           
            var groceryAmount = dbShopingCartExicst(shoppingCart);
            if (groceryAmount != -1)
            {
                float proslediAmount = shoppingCart.Amount + groceryAmount;
                dbUpdateShoppingCart(proslediAmount, shoppingCart.Grocery.Name, shoppingCart.GroupID);
            }
            else
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [ShoppingCart] (Amount,GroceryName,GroupID) VALUES(@Amount,@GroceryName,@GroupID)", con);
                cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = shoppingCart.Amount;
                cmd.Parameters.Add("@GroceryName", SqlDbType.VarChar).Value = shoppingCart.Grocery.Name;
                cmd.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = shoppingCart.GroupID;
                int test = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

            }
            con.Close();

        }

        public int dbInsertUser(UserDetails user)
        {
            int a = 0;
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            if (dbGroupExists(user.MyGroup))
            {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into [User] (Name, Surname, Password, Nickname, Status, Email, GroupID) VALUES (@Name, @Surname, @Password, @Nickname, @Status, @Email, @GroupID)", con);
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = user.Name;
                cmd.Parameters.Add("@Surname", System.Data.SqlDbType.VarChar).Value = user.Surname;
                string password = CryptoService.EncriptPassword(user.Password);
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = password.ToString();
                cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("@Status", System.Data.SqlDbType.VarChar).Value = user.Status;
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = user.Email;
                cmd.Parameters.Add("@GroupID", System.Data.SqlDbType.VarChar).Value = user.MyGroup;
                a = cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return a;
            }
            else
            {
                con.Close();
                return 0;
            }
            
            
        }
  
        public List<RecipeDetails> dbLoadRecipe()
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            List<RecipeDetails> listrecipeDetails = new List<RecipeDetails>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                RecipeDetails recipe = new RecipeDetails();
                recipe.ID = int.Parse((reader.GetValue(0).ToString()));
                recipe.Name = reader.GetValue(1).ToString();
                recipe.Description = reader.GetValue(2).ToString();
                if (reader.GetValue(3) != DBNull.Value)
                    recipe.Image = (byte[])reader.GetValue(3);
                else
                    recipe.Image = null;
                listrecipeDetails.Add(recipe);
            }
            reader.Close();
            cmd.Dispose();
            con.Close();
            return listrecipeDetails;
        }

        public void dbModifyOptions(OptionDetails option)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Option] SET Font=@Font, Theme=@Theme, Notification=@Notification WHERE UserNickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = option.UserNickname;
            cmd.Parameters.Add("@Font", System.Data.SqlDbType.VarChar).Value = option.Font;
            cmd.Parameters.Add("@Theme", System.Data.SqlDbType.VarChar).Value = option.Theme;
            cmd.Parameters.Add("@Notification", System.Data.SqlDbType.VarChar).Value = option.Notification;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void dbUpdateAvailableGroceries(float amount, string Name, string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [AvailableGroceries] SET Amount=@Amount WHERE GroceryName=@Name AND GroupID=@id", con);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = amount;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbUpdateShoppingCart(float amount, string Name, string id)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [ShoppingCart] SET Amount=@Amount WHERE GroceryName=@Name AND GroupID=@id", con);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = amount;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbUpdateUser(string password, string Nickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET Password=@Password WHERE Nickname=@Nickname", con);
            string password1 = CryptoService.EncriptPassword(password);
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = password1;
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = Nickname;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }

        public void loadGrocerie(GroceryDetails grocery)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into [Groceries](Name,Unit,Category) VALUES(@Name,@Unit,@Category)", con);
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = grocery.Name;
            cmd.Parameters.Add("@Unit", System.Data.SqlDbType.VarChar).Value = grocery.Unit;
            cmd.Parameters.Add("@Category", System.Data.SqlDbType.VarChar).Value = grocery.Category;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void loadRecipe(RecipeDetails recipe)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into [Recipe](ID,Name,Description) VALUES(@ID,@Name,@Description)", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = recipe.ID;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = recipe.Name;
            cmd.Parameters.Add("@Description", System.Data.SqlDbType.VarChar).Value = recipe.Description;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void deleteGrocerie(string Name)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Groceries] WHERE Name=@Name", con);
            
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = Name;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void deleteRecipe(int ID)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Recipe] WHERE ID=@ID", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = ID;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void loadContains(ContainsDetails contains)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into [Contain](RecipeID,GroceryName,Amount) VALUES(@ID,@Name,@Amount)", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = contains.RecipeID;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = contains.Grocery.Name;
            cmd.Parameters.Add("@Amount", System.Data.SqlDbType.VarChar).Value = contains.Amount;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void deleteContains(string Name, int ID)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Contain] WHERE RecipeID=@ID AND GroceryName=@Name", con);
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = ID;
            cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = Name;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbInsertImageUser(byte[] image)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [User](Image)Value(@Image)",con);
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbInsertImageRecipe(byte[] image,int ID)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Recipe] SET Image=@Image WHERE ID=@ID", con);
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbInsertImageGrocerieUser(byte[] image)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [Groceries](Image)Value(@Image)",con);
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbModifyUserImage(byte[] image,string Nickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET Image=@Image WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = Nickname;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbUpdateUserStatus(string status, string Nickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET Status=@Status WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Status", System.Data.SqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = Nickname;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbDeleteUserFromGroup(string UserNickName)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET GroupId=null WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = UserNickName;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public byte[] dbGetUserImage(string Nickname)
        {
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Image FROM [User] WHERE Nickname=@Nickname", con);
                cmd.Parameters.Add("@Nickname", System.Data.SqlDbType.VarChar).Value = Nickname;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                byte[] nizBaytova = (byte[])reader.GetValue(0);
                reader.Close();
                cmd.Dispose();
                con.Close();
                return nizBaytova;
         }

        public void dbModifyUserNickname(string StariNickname, string NoviNickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET Nickname=@NoviNickname WHERE Nickname=@StariNickname", con);
            cmd.Parameters.Add("@NoviNickname", System.Data.SqlDbType.VarChar).Value = NoviNickname;
            cmd.Parameters.Add("@StariNickname", System.Data.SqlDbType.VarChar).Value = StariNickname;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public RecipeDetails dbFindRecepyByID(int ID)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            RecipeDetails recipeDetails = new RecipeDetails();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe WHERE ID=@ID", con);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            recipeDetails.ID = (int)reader.GetValue(0);
            recipeDetails.Name = reader.GetValue(1).ToString();
            recipeDetails.Description = reader.GetValue(2).ToString();
            if (reader.GetValue(3) != DBNull.Value)
                recipeDetails.Image = (byte[])reader.GetValue(3);
            else
                recipeDetails.Image = null;
            reader.Close();
            cmd.Dispose();
            con.Close();
            return recipeDetails;
        }

        public float dbAvailableGroceriesExicst(AvailableGroceriesDetails availableGroceries)
        {
            if (con1.State != System.Data.ConnectionState.Open)
                con1.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [AvailableGroceries] WHERE GroceryName=@GroceryName AND GroupID=@GroupID", con1);
            command.Parameters.Add("@GroceryName", SqlDbType.VarChar).Value = availableGroceries.Grocery.Name;
            command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = availableGroceries.GroupID;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()==true) {
                float prosledi =float.Parse(reader.GetValue(0).ToString());
                reader.Close();
                command.Dispose();
                con1.Close();
                return prosledi;
            }
            
            reader.Close();
            command.Dispose();
            con1.Close();
            return -1;
            
        }

        public float dbShopingCartExicst(ShoppingCartDetails shoppingCart)
        {

            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [ShoppingCart] WHERE GroceryName=@GroceryName AND GroupID=@GroupID", con);
            command.Parameters.Add("@GroceryName", SqlDbType.VarChar).Value = shoppingCart.Grocery.Name;
            command.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = shoppingCart.GroupID;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                float prosledi = float.Parse(reader.GetValue(0).ToString());
                reader.Close();
                command.Dispose();
                con.Close();
                return prosledi;
            }
            
            reader.Close();
            command.Dispose();
            con.Close();
            return -1;

        }

        public void dbAvailableGroceriesExicst1(AvailableGroceriesDetails availableGroceries)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [AvailableGroceries] (Amount,GroceryName,GroupID) VALUES(@Amount,@GroceryName,@GroupID)", con);
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = availableGroceries.Amount;
            cmd.Parameters.Add("@GroceryName", SqlDbType.VarChar).Value = availableGroceries.Grocery.Name;
            cmd.Parameters.Add("@GroupID", SqlDbType.VarChar).Value = availableGroceries.GroupID;
            int test = cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void dbAvailableGroceriesInsert(AvailableGroceriesDetails availableGroceries)
        {
            float proveriNamirnicu = dbAvailableGroceriesExicst(availableGroceries);
            if (proveriNamirnicu != -1)
            {
                proveriNamirnicu += availableGroceries.Amount;
                dbUpdateAvailableGroceries(proveriNamirnicu, availableGroceries.Grocery.Name, availableGroceries.GroupID);
            }
            else {
                dbAvailableGroceriesExicst1(availableGroceries);
            }
        }

        public string dbGetUserStatus(string Nickname)
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Status FROM [User] WHERE Nickname=@Nickname", con);
            cmd.Parameters.Add("@Nickname", SqlDbType.VarChar).Value = Nickname;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string proslediParametar=reader.GetValue(0).ToString();
            reader.Close();
            cmd.Dispose();
            con.Close();
            return proslediParametar;
        }


    }
}



