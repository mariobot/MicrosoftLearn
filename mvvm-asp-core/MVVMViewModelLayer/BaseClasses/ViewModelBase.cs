namespace MVVMViewModelLayer
{
    public class ViewModelBase
    {
        public string SortDirection { get; set; }
        public string SortExpression { get; set; }
        public string PreviousSortExpression { get; set; }
        
        public ViewModelBase() 
        {
            EventCommand = string.Empty;            
            SortDirection = "asc";
            SortExpression = string.Empty;
            PreviousSortExpression = string.Empty;
        }
        
        public string EventCommand { get; set; }
        public virtual void HandleRequest() {}

        protected virtual void SetSortDirection() 
        {
            if (SortExpression == PreviousSortExpression) {
                // Toggle the sort direction if
                // the field name is the same
                SortDirection = (SortDirection == "asc" ? "desc" : "asc");
            }
            else {
                SortDirection = "asc";
            }
            // Set previous sort expression to new column
            PreviousSortExpression = SortExpression;
        }        
    }
}