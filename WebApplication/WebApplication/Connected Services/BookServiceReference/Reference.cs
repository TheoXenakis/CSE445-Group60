﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.BookServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/BookServiceApplication.Models")]
    [System.SerializableAttribute()]
    public partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string YearField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Author {
            get {
                return this.AuthorField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthorField, value) != true)) {
                    this.AuthorField = value;
                    this.RaisePropertyChanged("Author");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Genre {
            get {
                return this.GenreField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreField, value) != true)) {
                    this.GenreField = value;
                    this.RaisePropertyChanged("Genre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Price {
            get {
                return this.PriceField;
            }
            set {
                if ((object.ReferenceEquals(this.PriceField, value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Year {
            get {
                return this.YearField;
            }
            set {
                if ((object.ReferenceEquals(this.YearField, value) != true)) {
                    this.YearField = value;
                    this.RaisePropertyChanged("Year");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BookServiceReference.IBookService")]
    public interface IBookService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/GetAllBooks", ReplyAction="http://tempuri.org/IBookService/GetAllBooksResponse")]
        WebApplication.BookServiceReference.Book[] GetAllBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/GetAllBooks", ReplyAction="http://tempuri.org/IBookService/GetAllBooksResponse")]
        System.Threading.Tasks.Task<WebApplication.BookServiceReference.Book[]> GetAllBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/AddBook", ReplyAction="http://tempuri.org/IBookService/AddBookResponse")]
        void AddBook(WebApplication.BookServiceReference.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/AddBook", ReplyAction="http://tempuri.org/IBookService/AddBookResponse")]
        System.Threading.Tasks.Task AddBookAsync(WebApplication.BookServiceReference.Book book);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/RemoveBook", ReplyAction="http://tempuri.org/IBookService/RemoveBookResponse")]
        void RemoveBook(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookService/RemoveBook", ReplyAction="http://tempuri.org/IBookService/RemoveBookResponse")]
        System.Threading.Tasks.Task RemoveBookAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookServiceChannel : WebApplication.BookServiceReference.IBookService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookServiceClient : System.ServiceModel.ClientBase<WebApplication.BookServiceReference.IBookService>, WebApplication.BookServiceReference.IBookService {
        
        public BookServiceClient() {
        }
        
        public BookServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication.BookServiceReference.Book[] GetAllBooks() {
            return base.Channel.GetAllBooks();
        }
        
        public System.Threading.Tasks.Task<WebApplication.BookServiceReference.Book[]> GetAllBooksAsync() {
            return base.Channel.GetAllBooksAsync();
        }
        
        public void AddBook(WebApplication.BookServiceReference.Book book) {
            base.Channel.AddBook(book);
        }
        
        public System.Threading.Tasks.Task AddBookAsync(WebApplication.BookServiceReference.Book book) {
            return base.Channel.AddBookAsync(book);
        }
        
        public void RemoveBook(int id) {
            base.Channel.RemoveBook(id);
        }
        
        public System.Threading.Tasks.Task RemoveBookAsync(int id) {
            return base.Channel.RemoveBookAsync(id);
        }
    }
}
