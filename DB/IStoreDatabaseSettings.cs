namespace StoreApi.DB{
    public interface IStoreDatabaseSettings{
        public string Categories{get;set;}
        public string OrderProducts{get;set;}
        public string Orders{get;set;}
        public string Products{get;set;}
        public string ConnectionString {get;set;}
        public string DatabaseName {get;set;}
    }
    
}