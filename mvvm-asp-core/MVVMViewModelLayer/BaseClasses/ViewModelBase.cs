namespace MVVMViewModelLayer
{
    public class ViewModelBase
    {
        
        public ViewModelBase() 
        {
            EventCommand = string.Empty;
        }
        
        public string EventCommand { get; set; }
        public virtual void HandleRequest() {}
    }
}