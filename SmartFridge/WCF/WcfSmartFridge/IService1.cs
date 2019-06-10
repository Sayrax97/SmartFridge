using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSmartFridge
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        UserDetails dbFindUser(string userNickname,string password);
        [OperationContract]
        List<string> dbInMyGroup(string id);
        [OperationContract]
        int dbInsertUser(UserDetails user);
        [OperationContract]
        bool dbFindUserBool(string userNickname);
        [OperationContract]
        int dbAddGroup(GroupDetails id);
        [OperationContract]
        void dbDeleteUser(string userNickname);
        [OperationContract]
        void dbDeleteGroup(string id);
        [OperationContract]
        int dbAddToGroup(string userNickname, string GroupID);
        [OperationContract]
        bool dbGroupExists(string ID);
        [OperationContract]
        void dbUpdateUser(string password, string Nickname);
        [OperationContract]
        void dbUpdateUserStatus(string status, string Nickname);
        [OperationContract]
        void dbDeleteUserFromGroup(string UserNickName);
        [OperationContract]
        OptionDetails dbGetOptions(string Nickname);
        [OperationContract]
        void dbModifyOptions(OptionDetails option);
        [OperationContract]
        List<AvailableGroceriesDetails> dbGetAvailableGroceries(string id);
        [OperationContract]
        List<ShoppingCartDetails> dbGetShoppingCart(string id);
        [OperationContract]
        void dbUpdateAvailableGroceries(float amount, string Name, string id);
        [OperationContract]
        void dbUpdateShoppingCart(float amoount, string Name, string id);
        [OperationContract]
        void dbDeleteAvailableGroceries(string Name, string id);
        [OperationContract]
        void dbDeleteShoppingCart(string Name, string id);
        [OperationContract]
        void dbAvailableGroceriesInsert(AvailableGroceriesDetails availableGroceries);
        [OperationContract]
        void dbInsertShoppingCart(ShoppingCartDetails shoppingCart);
        [OperationContract]
        List<RecipeDetails> dbLoadRecipe();
        [OperationContract]
        List<GroceryDetails> dbGetgroceriesName();
        [OperationContract]
        List<ContainsDetails> dbGetContains(int IdRecepta);
        [OperationContract]
        void dbInsertOptions(OptionDetails option);
        [OperationContract]
        void loadRecipe(RecipeDetails recipe);
        [OperationContract]
        void loadGrocerie(GroceryDetails grocery);
        [OperationContract]
        void deleteRecipe(int ID);
        [OperationContract]
        void deleteGrocerie(string Name);
        [OperationContract]
        void loadContains(ContainsDetails contains);
        [OperationContract]
        void deleteContains(string Name, int ID);
        [OperationContract]
        void dbInsertImageUser(byte[] image);
        [OperationContract]
        void dbInsertImageRecipe(byte[] image, int ID);
        [OperationContract]
        void dbInsertImageGrocerieUser(byte[] image);
        [OperationContract]
        void dbModifyUserImage(byte[] image, string Nickname);
        [OperationContract]
        byte[] dbGetUserImage(string Nickname);
        [OperationContract]
        void dbModifyUserNickname(string StariNickname, string NoviNickname);
        [OperationContract]
        RecipeDetails dbFindRecepyByID(int ID);
        [OperationContract]
        float dbAvailableGroceriesExicst(AvailableGroceriesDetails availableGroceries);
        [OperationContract]
        float dbShopingCartExicst(ShoppingCartDetails shoppingCart);
        [OperationContract]
        void dbAvailableGroceriesExicst1(AvailableGroceriesDetails availableGroceries);
        [OperationContract]
        string dbGetUserStatus(string Nickname);
    }

    public class PasswordVerification{
        public string NickName { get; set; }
        public byte[] UserSalt { get; set; }
        public byte[] UserHash { get; set; }
    }
    [DataContract]
    public class GroupDetails
    {
        [DataMember]
        public string ID { get; set; }
    }

    [DataContract]
    public class UserDetails {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public string MyGroup { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
   
    [DataContract]
    public class AvailableGroceriesDetails {
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public GroceryDetails Grocery { get; set; }
        [DataMember]
        public string GroupID { get; set; }
    }
    [DataContract]
    public class GroceryDetails {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
    }
    [DataContract]
    public class OptionDetails {
        [DataMember]
        public string Theme { get; set; }
        [DataMember]
        public string Font { get; set; }
        [DataMember]
        public bool Notification { get; set; }
        [DataMember]
        public string UserNickname { get; set; }
    }
    [DataContract]
    public class RecipeDetails {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
    }
    [DataContract]
    public class ShoppingCartDetails {
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public GroceryDetails Grocery { get; set; }
        [DataMember]
        public string GroupID { get; set; }
    }
    [DataContract]
    public class ContainsDetails {
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public GroceryDetails Grocery { get; set; }
        [DataMember]
        public int RecipeID { get; set; }
    }
}
