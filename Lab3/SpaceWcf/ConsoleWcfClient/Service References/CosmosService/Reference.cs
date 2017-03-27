﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleWcfClient.CosmosService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CosmosService.ICosmos")]
    public interface ICosmos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/InitializeGame", ReplyAction="http://tempuri.org/ICosmos/InitializeGameResponse")]
        void InitializeGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/InitializeGame", ReplyAction="http://tempuri.org/ICosmos/InitializeGameResponse")]
        System.Threading.Tasks.Task InitializeGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/SendStarship", ReplyAction="http://tempuri.org/ICosmos/SendStarshipResponse")]
        CosmicAdventureDTO.Spaceship SendStarship(CosmicAdventureDTO.Spaceship spaceship, string systemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/SendStarship", ReplyAction="http://tempuri.org/ICosmos/SendStarshipResponse")]
        System.Threading.Tasks.Task<CosmicAdventureDTO.Spaceship> SendStarshipAsync(CosmicAdventureDTO.Spaceship spaceship, string systemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/GetSystem", ReplyAction="http://tempuri.org/ICosmos/GetSystemResponse")]
        CosmicAdventureDTO.SpaceSystem GetSystem();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/GetSystem", ReplyAction="http://tempuri.org/ICosmos/GetSystemResponse")]
        System.Threading.Tasks.Task<CosmicAdventureDTO.SpaceSystem> GetSystemAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/GetSpaceship", ReplyAction="http://tempuri.org/ICosmos/GetSpaceshipResponse")]
        CosmicAdventureDTO.Spaceship GetSpaceship(int money);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICosmos/GetSpaceship", ReplyAction="http://tempuri.org/ICosmos/GetSpaceshipResponse")]
        System.Threading.Tasks.Task<CosmicAdventureDTO.Spaceship> GetSpaceshipAsync(int money);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICosmosChannel : ConsoleWcfClient.CosmosService.ICosmos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CosmosClient : System.ServiceModel.ClientBase<ConsoleWcfClient.CosmosService.ICosmos>, ConsoleWcfClient.CosmosService.ICosmos {
        
        public CosmosClient() {
        }
        
        public CosmosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CosmosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CosmosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CosmosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void InitializeGame() {
            base.Channel.InitializeGame();
        }
        
        public System.Threading.Tasks.Task InitializeGameAsync() {
            return base.Channel.InitializeGameAsync();
        }
        
        public CosmicAdventureDTO.Spaceship SendStarship(CosmicAdventureDTO.Spaceship spaceship, string systemName) {
            return base.Channel.SendStarship(spaceship, systemName);
        }
        
        public System.Threading.Tasks.Task<CosmicAdventureDTO.Spaceship> SendStarshipAsync(CosmicAdventureDTO.Spaceship spaceship, string systemName) {
            return base.Channel.SendStarshipAsync(spaceship, systemName);
        }
        
        public CosmicAdventureDTO.SpaceSystem GetSystem() {
            return base.Channel.GetSystem();
        }
        
        public System.Threading.Tasks.Task<CosmicAdventureDTO.SpaceSystem> GetSystemAsync() {
            return base.Channel.GetSystemAsync();
        }
        
        public CosmicAdventureDTO.Spaceship GetSpaceship(int money) {
            return base.Channel.GetSpaceship(money);
        }
        
        public System.Threading.Tasks.Task<CosmicAdventureDTO.Spaceship> GetSpaceshipAsync(int money) {
            return base.Channel.GetSpaceshipAsync(money);
        }
    }
}