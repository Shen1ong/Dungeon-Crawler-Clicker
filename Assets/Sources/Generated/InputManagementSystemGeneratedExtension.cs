namespace Entitas {
    public partial class Pool {
        public ISystem CreateInputManagementSystem() {
            return this.CreateSystem<InputManagementSystem>();
        }
    }
}