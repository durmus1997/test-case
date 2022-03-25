namespace StoreApi.DB{
    public class StoreDatabaseSettings:IStoreDatabaseSettings{
        public string Categories{get;set;}="Categories";
        public string OrderProducts{get;set;}="OrderProducts";
        public string Orders{get;set;}="Orders";
        public string Products{get;set;}="Products";
        public string ConnectionString {get;set;}="mongodb+srv://admin:5f1ywpDUoL0Gnibw@cluster0.n8wz0.mongodb.net/Store?retryWrites=true&w=majority";
        public string DatabaseName {get;set;}="Store";
    }
    
}
